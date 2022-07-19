using System;


public class Matrix
{
    static public int [,] matrix = new int [Constants.ROWS + 2, Constants.COLUMNS + 2];
    int count;

    // Point initial param v
    public Matrix()
    {
        Random randX = new Random();
        Random randY = new Random();
        
        // randomly assigns tiles value of -1 (bombs)
        for (int i = 0; i < Constants.BOMBS;)
        {
            int x = randX.Next(0, Constants.COLUMNS) + 1;
            int y = randY.Next(0, Constants.ROWS) + 1;

            if (matrix[y, x] == 0)
            {
                matrix[y, x] = -1;
                i++;
            }
        }

        // assign every non -1 tile a value per adjacent -1 values (assign each tile its value)
        for (int x = 1; x <= Constants.COLUMNS; x++)
        {
            for (int y = 1; y <= Constants.ROWS; y++)
            {
                if (matrix[y, x] == 0)
                {
                    count = 0;
                    count += (matrix[y-1, x-1] - Math.Abs(matrix[y-1, x-1])) / -2;
                    count += (matrix[y-1, x] - Math.Abs(matrix[y-1, x])) / -2;
                    count += (matrix[y-1, x+1] - Math.Abs(matrix[y-1, x+1])) / -2;
                    count += (matrix[y, x+1] - Math.Abs(matrix[y, x+1])) / -2;
                    count += (matrix[y+1, x+1] - Math.Abs(matrix[y+1, x+1])) / -2;
                    count += (matrix[y+1, x] - Math.Abs(matrix[y+1, x])) / -2;
                    count += (matrix[y+1, x-1] - Math.Abs(matrix[y+1, x-1])) / -2;
                    count += (matrix[y, x-1] - Math.Abs(matrix[y, x-1])) / -2;
                    matrix[y, x] = count;
                }
            }
        }
    }

    /// <summary>
    /// sets given matrix position value of 0
    /// </summary> 
    public void SetZero(int x, int y)
    {
        matrix[y, x] = 0;
    }
}
