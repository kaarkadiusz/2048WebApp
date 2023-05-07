using _2048WebApp.Models;

namespace _2048WebApp.Services
{
    public class _2048GameService
    {
        public int[][] Board { get; private set; }
        public int MaxTile { get; private set; }
        public Moves AvailableMoves { get; private set; }
        public bool Winner { get; private set; }
        public _2048GameService()
        {
            Board = CreateBoard();
            AvailableMoves = CheckMoves(Board);
            Winner = false;
        }
        public static void MoveUp(ref int[][] board)
        {
            int curtil = -1;
            bool currTileSet = false;
            int boardSize = board.Length;
            int k = 0;
            for (int j = 0; j < boardSize; j++)
            {
                k = 0;
                currTileSet = false;
                for (int i = 0; i < boardSize; i++)
                {
                    if (!currTileSet)
                    {
                        if (board[i][j] != 0)
                        {
                            board[k][j] = board[i][j];
                            if (k != i)
                            {
                                board[i][j] = 0;
                            }
                            curtil = board[k][j];
                            currTileSet = true;
                        }
                    }
                    else if (board[i][j] != 0)
                    {
                        if (board[i][j] == curtil)
                        {
                            board[k++][j] *= 2;
                            board[i][j] = 0;
                            currTileSet = false;
                        }
                        else
                        {
                            board[++k][j] = board[i][j];
                            if (k != i)
                            {
                                board[i][j] = 0;
                            }
                            curtil = board[k][j];
                        }
                    }
                }
            }
        }
        public static void MoveRight(ref int[][] board)
        {
            int curtil = -1;
            bool currTileSet = false;
            int boardSize = board.Length;
            int k = boardSize - 1;
            for (int i = 0; i < boardSize; i++)
            {
                k = boardSize - 1;
                currTileSet = false;
                for (int j = boardSize - 1; j >= 0; j--)
                {
                    if (!currTileSet)
                    {
                        if (board[i][j] != 0)
                        {
                            board[i][k] = board[i][j];
                            if (k != j)
                            {
                                board[i][j] = 0;
                            }
                            // currTile.setTile(board[i][k], k);
                            curtil = board[i][k];
                            currTileSet = true;
                        }
                    }
                    else if (board[i][j] != 0)
                    {
                        if (board[i][j] == curtil)
                        {
                            board[i][k--] *= 2;
                            board[i][j] = 0;
                            currTileSet = false;
                        }
                        else
                        {
                            board[i][--k] = board[i][j];
                            if (k != j)
                            {
                                board[i][j] = 0;
                            }
                            curtil = board[i][k];
                        }
                    }
                }
            }
        }
        public static void MoveDown(ref int[][] board)
        {
            int curtil = -1;
            bool currTileSet = false;
            int boardSize = board.Length;
            int k = boardSize - 1;
            for (int j = 0; j < boardSize; j++)
            {
                k = boardSize - 1;
                currTileSet = false;
                for (int i = boardSize - 1; i >= 0; i--)
                {
                    if (!currTileSet)
                    {
                        if (board[i][j] != 0)
                        {
                            board[k][j] = board[i][j];
                            if (k != i)
                            {
                                board[i][j] = 0;
                            }
                            curtil = board[k][j];
                            currTileSet = true;
                        }
                    }
                    else if (board[i][j] != 0)
                    {
                        if (board[i][j] == curtil)
                        {
                            board[k--][j] *= 2;
                            board[i][j] = 0;
                            currTileSet = false;
                        }
                        else
                        {
                            board[--k][j] = board[i][j];
                            if (k != i)
                            {
                                board[i][j] = 0;
                            }
                            curtil = board[k][j];
                        }
                    }
                }
            }
        }
        public static void MoveLeft(ref int[][] board)
        {
            int curtil = -1;
            bool currTileSet = false;
            int boardSize = board.Length;
            int k = 0;
            for (int i = 0; i < boardSize; i++)
            {
                k = 0;
                currTileSet = false;
                for (int j = 0; j < boardSize; j++)
                {
                    if (!currTileSet)
                    {
                        if (board[i][j] != 0)
                        {
                            board[i][k] = board[i][j];
                            if (k != j)
                            {
                                board[i][j] = 0;
                            }
                            // currTile.setTile(board[i][k], k);
                            curtil = board[i][k];
                            currTileSet = true;
                        }
                    }
                    else if (board[i][j] != 0)
                    {
                        if (board[i][j] == curtil)
                        {
                            board[i][k++] *= 2;

                            board[i][j] = 0;
                            currTileSet = false;
                        }
                        else
                        {
                            board[i][++k] = board[i][j];
                            if (k != j)
                            {
                                board[i][j] = 0;
                            }
                            curtil = board[i][k];
                        }
                    }
                }
            }
        }
        public void Move(ref int[][] board, Moves playerMove)
        {
            switch (playerMove)
            {
                case Moves.Up:
                    MoveUp(ref board);
                    break;
                case Moves.Right:
                    MoveRight(ref board);
                    break;
                case Moves.Down:
                    MoveDown(ref board);
                    break;
                case Moves.Left:
                    MoveLeft(ref board);
                    break;
            }
        }
        public void Move(Moves playerMove)
        {
            var board = Board;
            switch (playerMove)
            {
                case Moves.Up:
                    MoveUp(ref board);
                    break;
                case Moves.Right:
                    MoveRight(ref board);
                    break;
                case Moves.Down:
                    MoveDown(ref board);
                    break;
                case Moves.Left:
                    MoveLeft(ref board);
                    break;
            }
        }
        public Moves CheckMoves(int[][] board)
        {
            Moves result = Moves.None;
            int boardSize = board.Length;
            bool breakTheLoop = false;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i][j] != 0)
                    {
                        if ((result & Moves.Down) != Moves.Down && i < boardSize - 1)
                        {
                            if (board[i + 1][j] == 0)
                                result |= Moves.Down;
                            else if (board[i + 1][j] == board[i][j])
                                result |= Moves.Up | Moves.Down;
                        }
                        if ((result & Moves.Right) != Moves.Right && j < boardSize - 1)
                        {
                            if (board[i][j + 1] == 0)
                                result |= Moves.Right;
                            else if (board[i][j + 1] == board[i][j])
                                result |= Moves.Right | Moves.Left;
                        }
                        if ((result & Moves.Up) != Moves.Up && i > 0)
                        {
                            if (board[i - 1][j] == 0)
                                result |= Moves.Up;
                            else if (board[i - 1][j] == board[i][j])
                                result |= Moves.Up | Moves.Down;
                        }
                        if ((result & Moves.Left) != Moves.Left && j > 0)
                        {
                            if (board[i][j - 1] == 0)
                                result |= Moves.Left;
                            else if (board[i][j - 1] == board[i][j])
                                result |= Moves.Left | Moves.Right;
                        }
                        if (result == (Moves.Up | Moves.Right | Moves.Down | Moves.Left))
                        {
                            breakTheLoop = true;
                            break;
                        }
                    }
                }
                if (breakTheLoop)
                {
                    break;
                }
            }
            return result;
        }
        public void SpawnTile(ref int[][] board)
        {
            int boardSize = board.Length;
            int maxTile = 0;
            List<Tuple<int, int>> indices = new List<Tuple<int, int>>();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i][j] == 0)
                    {
                        indices.Add(new Tuple<int, int>(i, j));
                    }
                }
                maxTile = Math.Max(maxTile, board[i].Max());
            }
            Random random = new Random();
            if (indices.Count > 0)
            {
                Tuple<int, int> randomTile = indices[random.Next(indices.Count)];
                board[randomTile.Item1][randomTile.Item2] = random.Next(1, 11) <= 8 ? 2 : 4;
            }
            if (maxTile == 2048)
            {
                Winner = true;
            }
        }
        public int[][] CreateBoard(int boardSize = 4)
        {
            int[][] board = new int[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                board[i] = new int[boardSize];
            }
            HashSet<Tuple<int, int>> tuples = new HashSet<Tuple<int, int>>();
            Random random = new Random();
            while (tuples.Count < 2)
            {
                if (tuples.Add(new Tuple<int, int>(random.Next(boardSize), random.Next(boardSize))))
                {
                    board[tuples.Last().Item1][tuples.Last().Item2] = random.Next(1, 11) <= 8 ? 2 : 4;
                }
            }
            return board;
        }
        public void NewBoard(int boardSize = 4)
        {
            int[][] board = CreateBoard(boardSize);
            MaxTile = 0;
            Board = board;
            AvailableMoves = CheckMoves(board);
            Winner = false;
        }
        public void PostMove(Moves playerMove)
        {
            var board = Board;
            Move(ref board, playerMove);
            SpawnTile(ref board);
            AvailableMoves = CheckMoves(board);
        }
    }
}
