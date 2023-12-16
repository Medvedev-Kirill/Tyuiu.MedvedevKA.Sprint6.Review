using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.MedvedevKA.Sprint6.Review.V19.Lib
{
    public class DataService
    {
        public int[,] GenerationMatrix(int n1, int n2, int n, int m)
        {
            Random random = new Random();
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (((i > 2) && ((i - 1) % 3 == 0)) || (i == 3))
                    {
                        matrix[i, j] = matrix[i - 3, j] - matrix[i - 2, j] - matrix[i - 1, j];
                    }
                    else
                    {
                        matrix[i, j] = random.Next(n1, n2 + 1);
                    }
                }
            }
            return matrix;
        }
        public int GetMatrix(int[,] matrix, int r, int k, int l)
        {
            int sum = 0;
            while (k <= l)
            {
                if (k % 2 == 0)
                {
                    sum += matrix[r, k];
                }
                k++;
            }
            return sum;
        }

    }
}
