using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.MedvedevKA.Sprint6.Review.V19.Lib;

namespace Tyuiu.MedvedevKA.Sprint6.Review.V19
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        int[,] matrix;
        private void buttonDone_MKA_Click(object sender, EventArgs e)
        {
            try
            {
                DataService ds = new DataService();
                Random random = new Random();

                int rows = Convert.ToInt32(textBoxRows_MKA.Text);
                int columns = Convert.ToInt32(textBoxColumns_MKA.Text);
                int min = Convert.ToInt32(textBoxMin_MKA.Text);
                int max = Convert.ToInt32(textBoxMax_MKA.Text);

                dataGridViewOutPutMatrix_MKA.ColumnCount = columns;
                dataGridViewOutPutMatrix_MKA.RowCount = rows;

                for (int i = 0; i < columns; i++)
                {
                    dataGridViewOutPutMatrix_MKA.Columns[i].Width = 40;
                }

                matrix = new int[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (j % 3 == 0 && j != 0)
                        {
                            matrix[i, j] = matrix[i, j - 3] - matrix[i, j - 2] - matrix[i, j - 1];
                        }
                        else
                        {
                            matrix[i, j] = random.Next(min, max);
                        }
                    }
                }
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        dataGridViewOutPutMatrix_MKA.Rows[r].Cells[c].Value = matrix[r, c];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введите верные размеры массива и диапозон чисел для рандома", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCalculate_MKA_Click(object sender, EventArgs e)
        {
            try
            {
                DataService ds = new DataService();
                int k = Convert.ToInt32(textBoxStartElement_MKA.Text);
                int l = Convert.ToInt32(textBoxStopElement_MKA.Text);
                int R = Convert.ToInt32(textBoxLine_MKA.Text);

                int sum = ds.GetMatrix(matrix, R, k, l);
                textBoxRes_MKA.Text = Convert.ToString(sum);
            }
            catch
            {

                MessageBox.Show("Введите валидный номер строки и индексы элементов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxMin_MKA_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
