namespace SudokuBookGenerator;

public class BookGenerator(ISudokuGenerator sudokuGenerator, IPdfGenerator pdfGenerator)
{
	private const int SUDOKUS_PER_PAGE = 4;
	
	public void GenerateSudokuBook(int pages, string outputPath)
	{
		var rnd = new Random();
		
		for (var i = 0; i < pages; i++)
		{
			var sudokus = new List<int[,]>();
			for (var j = 0; j < SUDOKUS_PER_PAGE; j++)
			{
				var sudoku = sudokuGenerator.GenerateSudoku(rnd.Next(0, 9999999));
				sudokus.Add(sudoku);
			}
			pdfGenerator.AddSudokuPage(sudokus);
		}

		pdfGenerator.SavePdf(outputPath);
	}
}