using System;

namespace Sample.BackTracking
{
    public class SearchWord
    {
        public static SearchWord Instance = new SearchWord();

        char[][] board;
        string word;
        int R,C;
        int[] ROWS = new int[] {-1,0,0,1};
        int[] COLS = new int[] {0,-1,1,0};

        private void Read()
        {
            word = "ABCB";
            board = Utility.Convert2DArray<char>("[[A,B,C,E],[S,F,C,S],[A,D,E,E]]",4);
        }

        public void Do()
        {
            Read();
            var val = Exist(board, word);
        }

        private bool Exist(char[][] board, string word)
        {
            R = board.Length;

            if(R > 0)
                C= board[0].Length;
            
            bool[,] visited = new bool[R,C];

            for(int i=0; i<R; i++)
            {
                for(int j=0; j<C; j++)
                {
                    if(DFS(board, word, visited, 0, i,j))
                        return true;
                }
            }
            
            return false;
        }

        private bool DFS(char[][] board, string word, bool[,] visited, int index, int r, int c)
        {
            visited[r,c] = true;

            if(word[index] == board[r][c])
            {
                index++;
                if(index == word.Length)
                    return true;
                
                for(int i=0; i<4; i++)
                {
                    int r1 = r + ROWS[i];
                    int c1 = c+ COLS[i];

                    if(r1>=0 && c1>=0 && r1<R && c1<C && !visited[r1,c1])
                    {
                        if(DFS(board, word, visited, index, r1, c1))
                            return true;
                    }
                }
            }

            visited[r,c] = false;
            return false;
        }
    }
}