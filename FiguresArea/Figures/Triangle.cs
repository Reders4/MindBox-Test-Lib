using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresArea.Figures
{
    public class Triangle : Figure
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;
        public Triangle(double sideA, double sideB, double sideC)
        {
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            CheckIsRectangular();
        }

        public bool IsRectangular { get; private set; }

        internal override double GetArea()
        {
            SideValidation();
            var semiPerimeter = GetSemiPerimeter();
            var result = Math.Sqrt(semiPerimeter * 
                (semiPerimeter - _sideA) * 
                (semiPerimeter - _sideB) * 
                (semiPerimeter - _sideC));

            return Math.Round(result, 2);
        }

        private double GetSemiPerimeter() => (_sideA + _sideB + _sideC)/2;
        
        private void SideValidation()
        {
            if (_sideA <= 0 || _sideB <= 0 || _sideC <= 0)
            {
                throw new ArgumentException("One of the sides less then 0 or equal, it must be greater then 0");
            }

            if (_sideA >= _sideB + _sideC ||
                _sideB >= _sideA + _sideC ||
                _sideC >= _sideA + _sideB)
            {
                throw new ArgumentException("One of the sides is greater than the sum of the other sides, this triangle cannot be constructed");
            }
        }

        private void CheckIsRectangular()
        {
            var powA = Math.Pow( _sideA, 2 );
            var powB = Math.Pow( _sideB, 2 );
            var powC = Math.Pow( _sideC, 2 );

            //Поскольку мы не знаем точное расположение сторон треугольника,
            //может выйти так что квадрат гипотенузы суммируется с квадратом катета,
            //что даст не верный результат.
            //Получилась такая проверка, в одном из трёх случаев равенство выполнится
            //если треугольник действительно прямоугольный
            if (powA + powB == powC ||
                powA + powC == powB ||
                powB + powC == powA)
            {
                IsRectangular = true;
            }
        }
    }
}
