using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace MazeRunner_v2._0
{
    public partial class Main : Form
    {
        /* Array information:
         * 0 = not visited
         * 1 = 
         * 
         * 
         * 
         * 
         */


        private int[,] array = new int[1000,1000];
        private int width = 0;
        private int height = 0;
        private Bitmap maze;
        private int[] startPos = { 0, 0 };
        private byte orientation = 0;
        private ArrayList nodes = new ArrayList();

        public Main()
        {
            InitializeComponent();
        }
        
        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool succeeded = true;
                try
                {
                    maze = (Bitmap)Image.FromFile(openFileDialog.FileName);
                    width = maze.Width;
                    height = maze.Height;
                }
                catch (Exception)
                {
                    succeeded = false;
                    MessageBox.Show("Error loading maze!", "Error");
                }
                if (succeeded)
                {
                    pictureBox.Image = maze;
                    
                    startPos = findOpeningOnSide(1, new int[] { 0, 0 });
                    if (startPos == new int[] { 0, 0 })
                    {
                        startPos = findOpeningOnSide(0, new int[] { 0, 0 });
                        if (startPos == new int[] { 0, 0 })
                        {
                            MessageBox.Show("Could not find start and end!", "Error");
                            return;
                        }
                        else
                        {
                            orientation = 0;
                            MessageBox.Show("Maze loaded correctly.");
                        }
                    }
                    else
                    {
                        orientation = 1;
                        MessageBox.Show("Maze loaded correctly.");
                    }
                }
            }
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
            if (startPos != new int[] { 0,0})
            {

            }

            



            // Convert image to array
            // Find shortest route
            // Draw path to image
            // Create new image with shortest path
            // Message "Maze solved" 

        }

        private void addNodesAround(int[] pos)
        {
            int x = pos[0];
            int y = pos[1];

            // Adding node over.
            if (y > 0)
            {
                if (array[x,y] != )
            }

            // Adding node under.


            // Adding node right


            // Adding node left.
        }
    }
}
