﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public enum VectorTool : int
    {
        Selecting,
        Drawing,
        Scissors
    }

    public enum DragShape : int
    {
        Line,
        Rectangle
    }
}
