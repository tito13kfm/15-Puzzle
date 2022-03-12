int[,] board = new int[4, 4] {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12},
    {13, 14, 15, 0}
};

int[,] winningBoard = new int[4, 4] {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12},
    {13, 14, 15, 0}
};
int blankRow=0, blankCol=0;


Random random = new Random();
InitBoard();
GetMove();

void CheckWin()
{
    int correct = 0;
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (board[i, j] == winningBoard[i, j])
            {
                correct++;
            }
        }
    }
    if (correct == 16)
    {
        Console.WriteLine("You Win!!!!!");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
    else { GetMove(); }
}

void InitBoard()
{
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            int k = random.Next(4);
            int l = random.Next(4);
            int tmp = board[i, j];
            board[i, j] = board[k, l];
            board[k, l] = tmp;
        }
    }
}

void PrintBoard()
{
    Console.Clear();
    System.Console.WriteLine("    1     2    3    4  ");
    System.Console.WriteLine("  +----+----+----+----+");
    for (int i = 0; i < 4; i++)
    {
        System.Console.Write((i + 1) + " ");
        for (int j = 0; j < 4; j++)
        {
            Console.Write("| " + displayValue(board[i,j]) + " ");
            if (board[i, j] == 0)
            {
                blankRow = i;
                blankCol = j;
            }
        }
        System.Console.Write("|\n");
        System.Console.WriteLine("  +----+----+----+----+");
    }
    return;
}

void GetMove()
{
    PrintBoard();
    int targetRow = 0;
    int targetCol = 0;
    ConsoleKeyInfo move = Console.ReadKey();
    switch (move.Key)
    {
        case ConsoleKey.W: 
        case ConsoleKey.UpArrow:
            targetRow = blankRow + 1;
            targetCol = blankCol;
            break;
        case ConsoleKey.A:
        case ConsoleKey.LeftArrow:
            targetRow = blankRow;
            targetCol = blankCol + 1;
            break;
        case ConsoleKey.S:
        case ConsoleKey.DownArrow:
            targetRow = blankRow - 1;
            targetCol = blankCol;
            break;
        case ConsoleKey.D:
        case ConsoleKey.RightArrow:
            targetRow = blankRow;
            targetCol = blankCol - 1;
            break;
        default:
            return;
    }
    if (targetRow < 0 || targetCol < 0) { GetMove(); }
    if (targetRow > 3 || targetCol > 3) { GetMove(); }
    int piece = board[targetRow, targetCol];
    board[blankRow, blankCol] = piece;
    board[targetRow, targetCol] = 0;
    CheckWin();

}

string displayValue(int i)
{
    if (i == 0) { return "  "; }
    if (i < 10) { return " " + i.ToString(); }
    return i.ToString();
}



