using System;

namespace Sample.BackTracking
{
    public class FindAndFlipRegion
    {
        public static FindAndFlipRegion Instance = new FindAndFlipRegion();

        int[] ROWS = new int[] {-1, 0, 0, 1};
        int[] COLS = new int[] {0,-1, 1, 0};
        int R,C;
        char[][] _arr;

        private void Read()
        {
            _arr = Utility.Convert2DArray<char>("[[X,O,O,X,X,X,O,X,O,O],[X,O,X,X,X,X,X,X,X,X],[X,X,X,X,O,X,X,X,X,X],[X,O,X,X,X,O,X,X,X,O],[O,X,X,X,O,X,O,X,O,X],[X,X,O,X,X,O,O,X,X,X],[O,X,X,O,O,X,O,X,X,O],[O,X,X,X,X,X,O,X,X,X],[X,O,O,X,X,O,X,X,O,O],[X,X,X,O,O,X,O,X,X,O]]",10);
        }

        public void Do()
        {
            Read();
            FlipRegion(_arr);
        }

        private void FlipRegion(char[][] board)
        {
            FlipRegion1(board, false);
            FlipRegion1(board, true);
        }

        private void FlipRegion1(char[][] board, bool canReplace = false)
        {
            R = board.Length;

            if(R > 0)
                C = board[0].Length;
            
            bool[][] visited = new bool[R][];

            for(int i=0; i<R; i++)
                visited[i] = new bool[C];
            
            char c = canReplace ? 'R' : 'O';
            
            for(int i=0; i<R; i++)
            {
                for(int j=0; j<C; j++)
                {
                    if(board[i][j] == c && !visited[i][j])
                    {
                        if(DFS(board, visited, i , j, canReplace))
                        {
                            if(!canReplace)
                                board[i][j] = 'R';
                            else
                                board[i][j] = 'X';
                        }
                    }
                }
            }
        }

        private bool DFS(char[][] board, bool[][] visited, int row, int col, bool canReplace)
        {
            bool validRegion = true;
            visited[row][col] = true;

            if(row == R-1 || row == 0 ||col == C-1|| col == 0) validRegion = false;

            for(int i=0; i<4; i++)
            {
                int r = row + ROWS[i];
                int c = col + COLS[i];
                if(Check(board, visited, r, c))
                {
                    if(canReplace) board[r][c] = 'X';

                    if(!DFS(board, visited, r, c, canReplace))
                        validRegion = false;
                }
            }

            return validRegion;
        }

        private bool Check(char[][] board, bool[][] visited, int row, int col)
        {
            return (row < R && row >= 0 && col < C && col >=0 && !visited[row][col] && board[row][col] == 'O');
        }
    }
}