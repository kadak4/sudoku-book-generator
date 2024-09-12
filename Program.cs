using SudokuBookGenerator;

var pages = 10;
var outputFilePath = "sudoku_book.pdf";

var sudokuGenerator = new SudokuSharpGenerator(20, 20, 20);
var pdfGenerator = new PdfSharpSudokuBookGenerator();

var bookGenerator = new BookGenerator(sudokuGenerator, pdfGenerator);
bookGenerator.GenerateSudokuBook(pages, outputFilePath);

Console.WriteLine($"Sudoku book generated with {pages} pages at {outputFilePath}");