using FiguresArea.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresArea
{
    public class FigureArea
    {
        public double GetFigureArea<T>(T figure) where T : Figure
        {
            return figure.GetArea();
        }
    }
}
