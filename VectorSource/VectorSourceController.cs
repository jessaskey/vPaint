using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VPaint
{
    public enum VectorHardware
    {
        MajorHavoc
    }

    [Flags]
    public enum VectorExportFlags : int
    {
        None,
        OutputColorChanges = 1,
        ForceLongVectors = 2,
        InvertX = 4,
        InvertY = 8,
        AddRTSL = 16,
        PrependFileNameAsLabel = 32,
        GenerateSubroutines = 64
    }

    public static class VectorSourceController
    {
        private static VectorHardware? _vectorHardware = null;

        public static void SetVectorHardware(VectorHardware vectorHardware)
        {
            _vectorHardware = vectorHardware;
        }

        public static List<VectorSourceCommand> FromDrawing(Drawing drawing, VectorExportFlags exportFlags)
        {
            List<VectorSourceCommand> sourceCommands = new List<VectorSourceCommand>();
            string startLabel = Path.GetFileNameWithoutExtension(drawing.FileName);
            Point lastPoint = Point.Empty;
            Color lastColor = Color.Transparent;

            foreach (Vector v in drawing.Vectors)
            {
                if (v.DisplayColor != lastColor && exportFlags.HasFlag(VectorExportFlags.OutputColorChanges))
                {
                    VectorSourceCommand statCommand = GetStatCommand(v, exportFlags);
                    if (!String.IsNullOrEmpty(startLabel))
                    {
                        statCommand.Label = startLabel;
                        startLabel = "";
                    }
                    sourceCommands.Add(statCommand);
                    lastColor = v.DisplayColor;
                }
                if (lastPoint != Point.Empty && (v.Start.Point.X != lastPoint.X || v.Start.Point.Y != lastPoint.Y))
                {
                    //must draw hidden vector
                    VectorSourceCommand hiddenVector = GetVectorCommand(lastPoint, v.Start.Point, false, exportFlags);
                    if (!String.IsNullOrEmpty(startLabel)){
                        hiddenVector.Label = startLabel;
                        startLabel = "";
                    }
                    sourceCommands.Add(hiddenVector);
                }
                VectorSourceCommand vectorCommand = GetVectorCommand(v.Start.Point, v.End.Point, v.DisplayColor != Color.Transparent, exportFlags);
                if (!String.IsNullOrEmpty(startLabel))
                {
                    vectorCommand.Label = startLabel;
                    startLabel = "";
                }
                sourceCommands.Add(vectorCommand);
                lastPoint = v.End.Point;
            }
            return sourceCommands;
        }

        public static List<VectorSourceCommand> Parse(string source, Point startPoint)
        {
            List<VectorSourceCommand> sourceCommands = new List<VectorSourceCommand>();
            Point lastPoint = startPoint;

            foreach (string line in source.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] parms = GetParms(line);
                string command = GetCommand(line);
                string comment = GetComment(line);
                VectorSourceCommand sourceCommand = new VectorSourceCommand();
                sourceCommand.Command = command;
                sourceCommand.Parameters.AddRange(parms);
                sourceCommand.Comment = comment;
                sourceCommands.Add(sourceCommand);
            }
            return sourceCommands;
        }

        public static List<KeyValuePair<SourceSegment<VectorSourceCommand>,int>> ParseSubroutines(Dictionary<Drawing, List<VectorSourceCommand>> drawingSources)
        {
            List<List<VectorSourceCommand>> outputSource = new List<List<VectorSourceCommand>>();
            return GetOrderedPairs(drawingSources.Select(x => x.Value.Select(y => y).ToList()).ToList());
            
        }

        public static bool InsertSubroutine(List<VectorSourceCommand> vectorSources, SourceSegment<VectorSourceCommand> subroutineSegment, string label)
        {
            bool found = false;
            //check if the sub is in each source list, if so replace it
            for (int i = vectorSources.Count - subroutineSegment.Length; i >= 0; i--) 
            { 
                if (vectorSources.Skip(i).Take(subroutineSegment.Length).SequenceEqual(subroutineSegment.List))
                {
                    vectorSources.RemoveRange(i, subroutineSegment.Length);
                    VectorSourceCommand subroutineCallCommand = GetJsrCommand(label);
                    vectorSources.Insert(i, subroutineCallCommand);
                    found = true;
                }
            }
            return found;
        } 

        public static List<VectorSourceCommand> GetSubroutine(SourceSegment<VectorSourceCommand> sourceCommands, string label)
        {
            List<VectorSourceCommand> subroutineCommands = new List<VectorSourceCommand>();
            foreach (var vs in sourceCommands.List)
            { 
                if (subroutineCommands.Count == 0)
                {
                    vs.Label = label;
                }
                subroutineCommands.Add(vs);
            }
            //subroutineCommands.Add(new VectorSourceCommand("rtsl"));
            return subroutineCommands;
        }

        public static int ParseIntValue(string val)
        {
            //if there is a 'd', just remove it, we assume all plain numbers are base 10
            string cleanVal = val.ToLower().Replace("d", "");
            if (cleanVal.Contains("$"))
            {
                //hex
                return Convert.ToInt32(cleanVal.Replace("$",""), 16);
            }
            return int.Parse(cleanVal);
        }

        private static int GetNumberParameter(string parm)
        {
            int val = 0;
            if (!int.TryParse(parm, out val))
            {
                if (parm.Contains("d"))
                {
                    val = int.Parse(parm.Replace("d", ""));
                }
            }
            return val;
        }

        private static string GetCommand(string line)
        {
            Regex r = new Regex(@"^[ \f\t\v]*(\w*)\(?");
            Match m = r.Match(line);
            if (m.Success)
            {
                if (m.Groups.Count > 1)
                {
                    return m.Groups[1].Value.ToLower();
                }

            }
            return String.Empty;
        }

        private static string GetComment(string line)
        {
            string comment = "";
            if (line.Contains(";"))
            {

            }
            return comment;
        }

        private static string[] GetParms(string line)
        {
            Regex r = new Regex(@"\((.*?)\)");
            Match m = r.Match(line);
           
            if (m.Success)
            {
                if (m.Groups.Count > 1)
                {
                    return m.Groups[1].Value.Split(',').Select(sValue => sValue.Trim()).ToArray();
                }
            }
            return new List<string>().ToArray();
        }

        private static VectorSourceCommand GetStatCommand(Vector v, VectorExportFlags exportFlags)
        {
            bool sparkle = v.Sparkle;
            bool xflip = false;
            int page = v.Page;

            int stat_intensity = v.Brightness;
            if (v.DisplayColor == Color.Transparent)
            {
                stat_intensity = 0;
            }
            int stat_color = VectorColorController.GetColorIndex(v.DisplayColor);

            VectorSourceCommand statCommand = new VectorSourceCommand();
            statCommand.Command = "vstat";
            statCommand.Parameters.Add((sparkle ? "sparkle_on" : "sparkle_off"));
            statCommand.Parameters.Add((xflip ? "xflip_on" : "xflip_off"));
            statCommand.Parameters.Add("vpage" + page.ToString());
            statCommand.Parameters.Add("$" + stat_intensity.ToString("X1").ToUpper());
            statCommand.Parameters.Add(VectorColorController.GetSourceNameByIndex(stat_color));
            return statCommand;
        }

        private static VectorSourceCommand GetJsrCommand(string label)
        {
            VectorSourceCommand jsrlCommand = new VectorSourceCommand();
            jsrlCommand.Command = "jsrl";
            jsrlCommand.Parameters.Add(label);
            return jsrlCommand;
        }

        private static VectorSourceCommand GetVectorCommand(Point start, Point end, bool visible, VectorExportFlags exportFlags)
        {
            string command = "vctr";
            int absX = Math.Abs(end.X - start.X);
            int absY = Math.Abs(end.Y - start.Y);
            if (!exportFlags.HasFlag(VectorExportFlags.ForceLongVectors) && absX <= 32 && absX % 2 == 0 && absY <= 32 && absY % 2 == 0)
            {
                if (exportFlags.HasFlag(VectorExportFlags.ForceLongVectors))
                {
                    command = "vctrl";
                }
            }
            VectorSourceCommand sourceCommand = new VectorSourceCommand();
            sourceCommand.Command = command;
            sourceCommand.Parameters.Add(((end.X - start.X) * (exportFlags.HasFlag(VectorExportFlags.InvertX) ? -1 : 1)).ToString() + "d");
            sourceCommand.Parameters.Add(((end.Y - start.Y) * (exportFlags.HasFlag(VectorExportFlags.InvertY) ? -1 : 1)).ToString() + "d");
            sourceCommand.Parameters.Add((visible ? "visible" : "hidden"));
            return sourceCommand;

            //return new string(' ', _indent) + command + "(" + ((end.X - start.X)).ToString() + "d," + ((end.Y - start.Y) * -1).ToString() + "d," + (visible ? "visible" : "hidden") + ")";
        }

        private static List<KeyValuePair<SourceSegment<VectorSourceCommand>, int>> GetOrderedPairs(List<List<VectorSourceCommand>> data)
        {
            var segmentsDictionary = new Dictionary<SourceSegment<VectorSourceCommand>, int>(SourceSegment<VectorSourceCommand>.DefaultComparator);
            foreach (var list in data)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j <= list.Count; j++)
                    {
                        var segment = new SourceSegment<VectorSourceCommand>
                        {
                            List = list.Skip(i).Take(j-i).ToList(),
                            Length = j - i
                        };
                        if (segmentsDictionary.TryGetValue(segment, out var val))
                        {
                            segmentsDictionary[segment]++;
                        }
                        else
                        {
                            segmentsDictionary[segment] = 1;
                        }
                    }
                }
            }
            return segmentsDictionary.OrderByDescending(pair => pair.Key.Length).ToList();
        }
    }
}
