using SudokuBookGenerator;

var pages = 100;
var outputFilePath = "sudoku_book.pdf";

var sudokuGenerator = new SudokuSharpGenerator(15, 15, 15);
var pdfGenerator = new PdfSharpSudokuBookGenerator();

var bookGenerator = new BookGenerator(sudokuGenerator, pdfGenerator);
bookGenerator.GenerateSudokuBook(pages, outputFilePath);

Console.WriteLine($"Sudoku book generated with {pages} pages at {outputFilePath}");