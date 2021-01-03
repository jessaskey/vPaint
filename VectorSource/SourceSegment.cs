using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class SourceSegment<T>
    {
        private sealed class SourceSegmentEqualityComparer : IEqualityComparer<SourceSegment<T>>
        {
            public bool Equals(SourceSegment<T> x, SourceSegment<T> y)
            {
                if (x.Length != y.Length)
                {
                    return false;
                }
                return x.List.SequenceEqual(y.List);
            }

            public int GetHashCode(SourceSegment<T> obj)
            {
                unchecked
                {
                    return obj.ToString().GetHashCode();
                    //int hash = 17;
                   
                    //for (int i = 0; i < obj.Length; i++)
                    //{
                    //    hash = hash * 31 + obj.List[i].GetHashCode();
                    //}
                    //return hash;
                }
            }
        }

        private class VectorSourceCommandComparer : IEqualityComparer<VectorSourceCommand>
        {
            public bool Equals(VectorSourceCommand x, VectorSourceCommand y)
            {
                if (x.Command == y.Command)
                {
                    if (x.Parameters.Count == y.Parameters.Count)
                    {
                        for(int i = 0; i < x.Parameters.Count; i++)
                        {
                            if (x.Parameters[i] != y.Parameters[i])
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                }
                return false;
            }

            public int GetHashCode(VectorSourceCommand obj)
            {
                return obj.CommandString.GetHashCode();
            }
        }

        public static IEqualityComparer<SourceSegment<T>> DefaultComparator { get; } = new SourceSegmentEqualityComparer();

        public List<T> List { get; set; }
        //public int Offset { get; set; }
        public int Length { get; set; }

        //public IEnumerable<T> GetEnumerable()
        //{
        //    return List;
        //}

        public List<T> GetSegments()
        {
            return List;
        }

        public override string ToString()
        {
            return string.Join("->", List);
        }
    }
}
