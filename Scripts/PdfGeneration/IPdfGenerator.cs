namespace SudokuBookGenerator;

public interface IPdfGenerator
{
	void AddSudokuPage(List<int[,]> sudokus);
	void SavePdf(string filePath);
}