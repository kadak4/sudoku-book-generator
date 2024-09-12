using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace SudokuBookGenerator;

public class PdfSharpSudokuBookGenerator : IPdfGenerator
{
    private readonly PdfDocument document = new();

    public void AddSudokuPage(List<int[,]> sudokus)
    {
        var page = document.AddPage();
        var gfx = XGraphics.FromPdfPage(page);
        var sudokuCount = sudokus.Count;

        // Define the grid dimensions for each Sudoku
        var margin = 40d;
        var gridSize = (page.Width - 2 * margin) / 2; // Two Sudoku per row
        var cellSize = gridSize / 9;

        // Add padding between Sudokus
        var horizontalSpacing = 20d;  // Space between two Sudoku horizontally
        var verticalSpacing = 40d;    // Space between two Sudoku vertically

        // Define pen thickness
        var regularPen = new XPen(XColors.Black, 0.5);  // Regular grid lines
        var thickPen = new XPen(XColors.Black, 2);      // Thicker lines for quadrant borders

        for (var i = 0; i < sudokuCount; i++)
        {
            var sudoku = sudokus[i];

            // Calculate the top-left position for the Sudoku grid
            var xOffset = margin + (i % 2) * (gridSize + horizontalSpacing); // Adjust for horizontal spacing
            var yOffset = margin + (i / 2) * (gridSize + verticalSpacing);   // Adjust for vertical spacing

            // Draw Sudoku grid
            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    var rect = new XRect(xOffset + col * cellSize, yOffset + row * cellSize, cellSize, cellSize);

                    // Draw the grid cell
                    gfx.DrawRectangle(regularPen, rect);

                    // Draw numbers inside the grid if they exist
                    if (sudoku[row, col] != 0)
                    {
                        var font = new XFont("Arial", 12, XFontStyle.Regular);
                        gfx.DrawString(sudoku[row, col].ToString(), font, XBrushes.Black, rect, XStringFormats.Center);
                    }
                }
            }

            // Draw thick lines for 3x3 quadrant borders
            for (var row = 0; row < 10; row++)
            {
                if (row % 3 == 0)
                {
                    // Draw thick horizontal lines for 3x3 borders
                    var yLine = yOffset + row * cellSize;
                    gfx.DrawLine(thickPen, xOffset, yLine, xOffset + gridSize, yLine);
                }
            }

            for (var col = 0; col < 10; col++)
            {
                if (col % 3 == 0)
                {
                    // Draw thick vertical lines for 3x3 borders
                    var xLine = xOffset + col * cellSize;
                    gfx.DrawLine(thickPen, xLine, yOffset, xLine, yOffset + gridSize);
                }
            }

            // Draw outer thick border around the entire 9x9 grid
            gfx.DrawRectangle(thickPen, new XRect(xOffset, yOffset, gridSize, gridSize));
        }
    }

    public void SavePdf(string filePath)
    {
        document.Save(filePath);
    }
}
