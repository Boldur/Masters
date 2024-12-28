using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerchAlgorthmsPrototypes
{
    public class MatrixVisualizer : Form
    {
        int[,] matrix;  

        private const int CellSize = 40; // Size of each cell in pixels

        public MatrixVisualizer(int[,] matrix)
        {   
            this.matrix = matrix;
            this.Text = "Matrix Visualizer";
            this.Size = new Size(1000, 1000);
            this.DoubleBuffered = true; // Prevent flickering
            this.Paint += MatrixVisualizer_Paint;
        }

        private void MatrixVisualizer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Color cellColor;

                    switch (matrix[row, col])
                    {
                        case 9:
                            cellColor = Color.Black; // Wall
                            break;
                        case 0:
                            cellColor = Color.White; // Free space
                            break;
                        case 1:
                            cellColor = Color.Blue; // Start
                            break;
                        case 2:
                            cellColor = Color.Red; // Goal
                            break;
                        case 3:
                            cellColor = Color.Yellow; // searched
                            break;
                        case 4:
                            cellColor = Color.Green; // searched
                            break;
                        case 5:
                            cellColor = Color.Gold;
                            break;
                        default:
                            cellColor = Color.Gray; // Default (if unexpected values exist)
                            break;
                    }

                    using (Brush brush = new SolidBrush(cellColor))
                    {
                        int x = col * CellSize;
                        int y = row * CellSize;
                        g.FillRectangle(brush, x, y, CellSize, CellSize);
                    }

                    // Draw cell borders
                    using (Pen pen = new Pen(Color.Black))
                    {
                        g.DrawRectangle(pen, col * CellSize, row * CellSize, CellSize, CellSize);
                    }
                }
            }
        }      
    }
}