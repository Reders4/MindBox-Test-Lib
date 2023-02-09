using FiguresArea.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresArea.Tests
{
    public class CircleTests
    {
        [Theory]
        [MemberData(nameof(CircleOkData))]
        public void GetFigureArea_SetupOkParams_ShouldBeSameAreas(Circle circle, double expected)
        {
            var figureArea = new FigureArea();
            Assert.Equal(expected, figureArea.GetFigureArea(circle));
        }

        [Theory]
        [MemberData(nameof(CircleBadData))]
        public void GetFigureArea_SetupBadParams_ThrowArgumenException(Circle circle)
        {
            var figureArea = new FigureArea();
            Assert.Throws<ArgumentException>(() => figureArea.GetFigureArea(circle));
        }
        public static IEnumerable<object[]> CircleOkData()
        {
            yield return new object[] { new Circle(5), 78.54  };
            yield return new object[] { new Circle(8.8), 243.28 };
        }

        public static IEnumerable<object[]> CircleBadData()
        {
            yield return new object[] { new Circle(0) };
            yield return new object[] { new Circle(-8.8) };
        }
    }
}
