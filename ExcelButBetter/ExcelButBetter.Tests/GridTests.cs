using Xunit;
using ExcelButBetter.Logic;

namespace ExcelButBetter.Tests
{
    public class GridTests
    {
        [Fact]
        public void TestSimpleValueAssignment()
        {
            var grid = new GridManager();
            grid.SetDimensions(5, 5);

            grid.UpdateCell("A1", "100");
            grid.RecalculateAll();

            var cell = grid.GetOrCreateCell("A1");
            Assert.Equal(100, cell.Value);
        }

        [Fact]
        public void TestBasicFormulaCalculation()
        {
            var grid = new GridManager();
            grid.SetDimensions(5, 5);

            grid.UpdateCell("A1", "10");
            grid.UpdateCell("B1", "=A1*2");
            grid.RecalculateAll();

            var cell = grid.GetOrCreateCell("B1");
            Assert.Equal(20, cell.Value);
        }

        [Fact]
        public void TestIncFunctionLogic()
        {
            var grid = new GridManager();
            grid.SetDimensions(5, 5);

            grid.UpdateCell("C1", "5");
            grid.UpdateCell("C2", "=inc(C1)");
            grid.RecalculateAll();

            var cell = grid.GetOrCreateCell("C2");
            Assert.Equal(6, cell.Value);
        }
    }
}