using FiguresArea.Figures;

namespace FiguresArea.Tests;

public class TriangleTests
{
    [Theory]
    [MemberData(nameof(TrianglesOkData))]
    public void GetFigureArea_SetupOkParams_ShouldBeSameAreas(Triangle triangle, double expected)
    {
        var figureArea = new FigureArea();
        Assert.Equal(expected, figureArea.GetFigureArea(triangle));
    }

    [Theory]
    [MemberData(nameof(TrianglesBadData))]
    public void GetFigureArea_SetupBadParams_ThrowArgumentException(Triangle triangle)
    {
        var figureArea = new FigureArea();
        Assert.Throws<ArgumentException>(() => figureArea.GetFigureArea(triangle));
    }

    [Fact]
    public void GetFigureArea_SetupTriangleAsRectangular_PropertyIsRectangularEqualTrue() 
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsRectangular);
    }

    [Fact]
    public void GetFigureArea_SetupTriangleAsNotRectangular_PropertyIsRectangularEqualFalse()
    {
        var triangle = new Triangle(5, 7, 10);
        Assert.False(triangle.IsRectangular);
    }

    public static IEnumerable<object[]> TrianglesOkData()
    {
        yield return new object[] { new Triangle(5, 7, 10), 16.25 };
        yield return new object[] { new Triangle(7.5, 10.1, 12.9), 37.82 };
        yield return new object[] { new Triangle(10, 17.2, 8), 22.66 };
    }

    public static IEnumerable<object[]> TrianglesBadData()
    {
        yield return new object[] { new Triangle(1, 2, 3) };
        yield return new object[] { new Triangle(11, 15, 30.5) };
        yield return new object[] { new Triangle(-3, -4, -8) };
    }
}