using SudokuSharp;

namespace SudokuBookGenerator;

public class SudokuSharpGenerator(int quadsToCut, int pairsToCut, int singlesToCut) : ISudokuGenerator
{
	public int[,] GenerateSudoku(int seed)
	{
		var rnd = new Random(seed);

		var solution = Factory.Solution(rnd);
		var board = Factory.Puzzle(solution, rnd, quadsToCut, pairsToCut, singlesToCut);
		
		Console.WriteLine(board.ToString());
		
		var grid = new int[9, 9];
		
		foreach (var location in Location.All)
		{
			// Fill the grid with the value from the generated Sudoku puzzle
			grid[location.Row, location.Column] = board[location];
		}
		
		return grid;
	}
}