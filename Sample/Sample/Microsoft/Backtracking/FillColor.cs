using System;

namespace Sample.Microsoft.Backtracking
{
    public class FillColor
    {
        public static FillColor Instance = new FillColor();

        int[][] _image;
        int _newColor;
        int Row;
        int Col;

        int _sr, _sc;

        int[] R = new int[] { -1, 0, 0, 1 };
        int[] C = new int[] { 0, -1, 1, 0 };

        public void Do()
        {
            Read();
            FloodFill(_image, _sr, _sc, _newColor);
        }

        private void Read()
        {
            _image = new int[3][];

            _image[0] = new int[] {1,1,1};
            _image[1] = new int[] {1,1,0};
            _image[2] = new int[] {1,0,1};

            _newColor = 2;
            _sr=1;
            _sc=1;
        }

        private int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            Row = image.Length;
            Col = 0;

            if(Row != 0)
                Col = image[0].Length;

            bool[][] visited = new bool[Row][];

            for(int i=0; i<Row; i++)
            {
                visited[i] = new bool[Col];

                for(int j = 0; j<Col; j++)
                    visited[i][j] = false;
            }

            int oldColor = image[sr][sc];
            image[sr][sc] = newColor;
            DFS(image, sr, sc, newColor, oldColor, visited);

            return image;
        }

        private void DFS(int[][] image, int row, int col, int newColor, int oldColor, bool[][] visited)
        {
            visited[row][col] = true;

            for(int i=0; i<4; i++)
            {
                int r1 = row + R[i];
                int c1 = col + C[i];

                if(CanFill(image, r1, c1, oldColor, visited))
                {
                    image[r1][c1] = newColor;
                    DFS(image, r1, c1, newColor, oldColor, visited);
                }
            }
        }

        private bool CanFill(int[][] image, int row, int col, int oldColor, bool[][] visited)
        {
            return (row < Row && row >= 0 && col <Col && col >= 0 && !visited[row][col] && image[row][col] == oldColor);
        }
    }
}