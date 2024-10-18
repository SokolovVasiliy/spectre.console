namespace Spectre.Console.Tests.Unit;
[ExpectationPath("WidgetsCustom/ProgressBarCustom")]
public sealed class ProgressBarCustomTest
{
    public sealed class TheAddColumnMethod
    {
        [Fact]
        public void Should_Add_Empty_Items_If_User_Provides_Less_Row_Items_Than_Columns()
        {
            ProgressBarCustom barCustom = new ProgressBarCustom("test", "0");
            RenderOptions o = new RenderOptions(null, new Size(200, 100));
            var d = barCustom.Render(o, 50);
            // Given
            var grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();

            // When
            grid.AddRow("Foo");

            // Then
            grid.Rows.Count.ShouldBe(1);
        }

    }
}
