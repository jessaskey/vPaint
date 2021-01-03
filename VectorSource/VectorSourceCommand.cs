using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class VectorSourceCommand
    {
        public VectorSourceCommand()
        {
            Parameters = new List<string>();
        }

        public VectorSourceCommand(string command)
        {
            Parameters = new List<string>();
            Command = command;
        }

        public string Label { get; set; }
        public string Command { get; set; }
        public List<string> Parameters { get; set; }
        public string Comment { get; set; }
        public string ParserError { get; set; }

        public string CommandString
        {
            get
            {
                return (Command + "(" + String.Join(",", Parameters.ToArray()) + ")").ToLower();
            }
        }

        public override string ToString()
        {
            return CommandString; // ToString(10, 50);
        }

        public override bool Equals(object obj)
        {
            return CommandString.ToLower() == ((VectorSourceCommand)obj).CommandString.ToLower();
        }

        public string ToSourceString(int indentSource, int indentComment)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(Label))
            {
                sb.Append(Label);
            }
            if (indentSource >= 0)
            {
                //need to indent
                if (sb.ToString().Length >= indentSource - 1)
                {
                    //label was too long, just add a new line now
                    sb.AppendLine("");
                }
                else
                {
                    //pad spaces
                    while (sb.ToString().Length < indentSource)
                    {
                        sb.Append(" ");
                    }
                }
            }
            sb.Append(Command);
            if (Parameters.Count > 0)
            {
                sb.Append("(");
                sb.Append(String.Join(",", Parameters.ToArray()));
                sb.Append(")");
            }
            if (!String.IsNullOrEmpty(Comment))
            {
                if (sb.ToString().Length >= indentComment)
                {
                    //already past comment indent, just add a single space
                    sb.Append(" ");
                }
                else
                {
                    //normal comment formatting, pad with spaces
                    while (sb.ToString().Length < indentComment)
                    {
                        sb.Append(" ");
                    }
                }
                sb.Append(";");
                sb.Append(Comment);
            }
            return sb.ToString();
        }
    }
}
