namespace SudokuBookGenerator;

public interface ISudokuGenerator
{
	int[,] GenerateSudoku(int seed);
}