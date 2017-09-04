using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeRunner_v2._0
{
    public partial class Main : Form
    {
        private int[,] array = new int[1000,1000];
        private int width = 0;
        private int height = 0;
        private Bitmap maze;
        private int[] startPos = { 0, 0 };

        public Main()
        {
            InitializeComponent();
        }
        

        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool succed = true;
                try
                {
                    maze = (Bitmap)Image.FromFile(openFileDialog.FileName);
                    width = maze.Width;
                    height = maze.Height;
                }
                catch (Exception)
                {
                    succed = false;
                    MessageBox.Show("Error");
                }
                if (succed)
                {
                    startPos = findOpeningOnSide(1, new int[] { 0, 0 });
                    pictureBox.Image = maze;
                    if (startPos == new int[] { 0, 0 })
                    {
                        MessageBox.Show("Could not find start and end!", "Error");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Image loaded correctly.");
                    }
                }
            }
            
            // Find image
        }

        private int[] findOpeningOnSide(int orientation, int[] startSidePos)
        {
            // Vertical orientation = 1
            // Horiansontal orientation = 0
            int whiteCounter = 0;
            bool whiteHasStarted = false;
            int[] whiteStartPos = { startSidePos[0], 0 };

            if (orientation == 1)
            {
                for (int y = 0; y < height; y++)
                {
                    if (getColor(startSidePos[0], y) == 1)
                    {
                        if (!whiteHasStarted) whiteStartPos[1] = y;
                        array[startSidePos[0], y] = 1;
                        whiteCounter++;
                        whiteHasStarted = true;
                    }
                    else if (whiteHasStarted) break;
                }
                // Returning starting position for maze.
                if (whiteHasStarted && (whiteCounter == 1 || whiteCounter == 2)) return whiteStartPos;
                else if (whiteHasStarted && whiteCounter > 2) return new int[] { startSidePos[0], (whiteCounter / 2 + whiteStartPos[1]) };
                else return new int[] { 0, 0 };
            }
            else
            {
                for (int x = 0; x < width; x++)
                {
                    if (getColor(x, startSidePos[1]) == 1)
                    {
                        if (!whiteHasStarted) whiteStartPos[0] = x;
                        array[x, startSidePos[1]] = 1;
                        whiteCounter++;
                        whiteHasStarted = true;
                    }
                    else if (whiteHasStarted) break;
                }
                // Returning starting position for maze.
                if (whiteHasStarted && (whiteCounter == 1 || whiteCounter == 2)) return whiteStartPos;
                else if (whiteHasStarted && whiteCounter > 2) return new int[] { (whiteCounter / 2 + whiteStartPos[0]), startSidePos[1] };
                else return new int[] { 0, 0 };
            }
        }

        private int getColor(int x, int y)
        {
            Color color = maze.GetPixel(x,y);
            if (color.R < 10 && color.G < 10 && color.B < 10) return 0;
            else return 1;
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txt_x.Text);
            int y = Convert.ToInt32(txt_y.Text);
            Bitmap image = (Bitmap)Image.FromFile(@"C:\Users\danie\GitHub\MazeRunner-v2.0\maze.png", true);
            Color pixelColor = image.GetPixel(x, y);

            int r = pixelColor.R;
            int g = pixelColor.G;
            int b = pixelColor.B;
            MessageBox.Show(r + ":" + g + ":" + b);



            // Convert image to array
            // Find shortest route
            // Draw path to image
            // Create new image with shortest path
            // Message "Maze solved" 

        }
    }
}
