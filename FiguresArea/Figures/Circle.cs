using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresArea.Figures
{
    public class Circle : Figure
    {
        private readonly double _radius;
        public Circle(double radius)
        {
            _radius= radius;
        }
        internal override double GetArea()
        {
            RaduisValidation();
            return Math.Round(Math.PI * Math.Pow(_radius, 2), 2);
        }

        private void RaduisValidation()
        {
            if (_radius <= 0) 
            {
                throw new ArgumentException("Radius cannot be less then 0 or equal");
            }
        }
    }
}
