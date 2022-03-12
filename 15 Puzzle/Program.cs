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



Random random = new Random();

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
    System.Console.WriteLine("+----+----+----+----+");
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (board[i, j] != 0)
            {
                Console.Write("| " + board[i, j].ToString("00") + " ");
            }
            else
            {
                Console.Write("|    ");
            }
        }
        System.Console.Write("|\n");
        System.Console.WriteLine("+----+----+----+----+");
    }
}

InitBoard();
PrintBoard();
