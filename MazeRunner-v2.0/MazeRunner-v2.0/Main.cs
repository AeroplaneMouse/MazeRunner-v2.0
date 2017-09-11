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
         * 1 = visited from field above
         * 2 = visited from field below
         * 3 = visited from field left
         * 4 = visited from field right
         * 
         */


        private int[,] array = new int[20, 20];
        private int width = 0;
        private int height = 0;
        private Bitmap maze;
        private int[] startPos = { 0, 0 };
        private int[] endPos = { 0, 0 };
        private byte orientation = 0;
        private ArrayList nodes = new ArrayList();

        public Main()
        {
            InitializeComponent();
            //nodes.Add(1);
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
                    int[][] openings = findOpeningOnSides(1);
                    startPos = openings[0];
                    endPos = openings[1];

                    if (startPos == new int[] { 0, 0 })
                    {
                        openings = findOpeningOnSides(0);
                        startPos = openings[0];
                        endPos = openings[1];

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

        private void btn_solve_Click(object sender, EventArgs e)
        {
            nodes.Clear();
            if (startPos != new int[] { 0, 0 } && endPos != new int[] { 0, 0 })
            {
                if (!addNodesAround(startPos)) return;
                int i = 0;
                int[] test = { 0, 0 };
                while (true)
                {
                    if (i < nodes.Count)
                    {
                        test = nodes[i] as int[];
                        if (test[0] == endPos[0] && test[1] == endPos[1])
                        {
                            MessageBox.Show("Maze solved!");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("i = nodes.Count", "Error");
                        break;
                    }

                    try
                    {
                        if (i < nodes.Count)
                        {
                            if (!addNodesAround(nodes[i] as int[]))
                            {
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Arraylist - out of range.", "Error");
                        return;
                    }
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Invalid start position. (0,0)", "Error");
                return;
            }





            // Convert image to array
            // Find shortest route
            // Draw path to image
            // Create new image with shortest path
            // Message "Maze solved" 

        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txt_x.Text);
            int y = Convert.ToInt32(txt_y.Text);

            txt_test.Text = Convert.ToString(getColor(x, y));
        }


        private int[][] findOpeningOnSides(int orientation)
        {
            /* 
             * Vertical orientation = 1
             * Horizontal orientation = 0
             */

            int whiteCounter = 0;
            bool whiteHasStarted = false;
            int[] whiteStartPos = { 0, 0 };
            int[] whiteEndPos = { 0, 0 };

            if (orientation == 1)
            {
                // Finding start position.
                for (int y = 0; y < height; y++)
                {
                    if (getColor(0, y) == 1)
                    {
                        if (!whiteHasStarted) whiteStartPos[1] = y;
                        array[0, y] = 5;
                        whiteCounter++;
                        whiteHasStarted = true;
                    }
                    else if (whiteHasStarted) break;
                }
                if (whiteHasStarted && whiteCounter > 2) whiteStartPos = new int[] { 0, (whiteCounter / 2 + whiteStartPos[1]) };

                // Finding end position.
                whiteCounter = 0;
                whiteHasStarted = false;
                int x = width - 1;

                for (int y = 0; y < height; y++)
                {
                    if (getColor(x, y) == 1)
                    {
                        if (!whiteHasStarted)
                        {
                            whiteEndPos[0] = x;
                            whiteEndPos[1] = y;
                        }
                        array[x, y] = 6;
                        whiteCounter++;
                        whiteHasStarted = true;
                    }
                    else if (whiteHasStarted) break;
                }
                if (whiteHasStarted && whiteCounter > 2) whiteEndPos = new int[] { x, (whiteCounter / 2 + whiteEndPos[1]) };
            }
            else
            {
                // Finding start position.
                for (int x = 0; x < width; x++)
                {
                    if (getColor(x, 0) == 1)
                    {
                        if (!whiteHasStarted) whiteStartPos[0] = x;
                        array[x, 0] = 5;
                        whiteCounter++;
                        whiteHasStarted = true;
                    }
                    else if (whiteHasStarted) break;
                }
                if (whiteHasStarted && whiteCounter > 2) whiteStartPos = new int[] { (whiteCounter / 2 + whiteStartPos[0]), 0 };

                // Finding end position.
                whiteCounter = 0;
                whiteHasStarted = false;
                int y = height - 1;
                for (int x = 0; x < width; x++)
                {
                    if (getColor(x, y) == 1)
                    {
                        if (!whiteHasStarted)
                        {
                            whiteEndPos[0] = x;
                            whiteEndPos[1] = y;
                        }
                        array[x, y] = 6;
                        whiteCounter++;
                        whiteHasStarted = true;
                    }
                    else if (whiteHasStarted) break;
                }

                if (whiteHasStarted && whiteCounter > 2) whiteEndPos = new int[] { (whiteCounter / 2 + whiteEndPos[0]), y };
            }

            return new int[][] { whiteStartPos, whiteEndPos };
        }

        private int getColor(int x, int y)
        {
            /*
             * 0 = black
             * 1 = white
             */
            Color color = maze.GetPixel(x, y);
            if (color.R < 10 && color.G < 10 && color.B < 10) return 0;
            else return 1;
        }

        private void setColor(int x, int y, int _color)
        {
            //Color color;

            //if (_color == 1) color = { 255, 255, 255

 
            //maze.SetPixel(x, y, color);
        }

        private void drawPath()
        {
            int x = endPos[0];
            int y = endPos[1];



        }

        private bool addNodesAround(int[] pos)
        {
            try
            {
                int x = pos[0];
                int y = pos[1];

                // Adding node over.
                if (y > 0)
                {
                    if (array[x, y - 1] == 0 && getColor(x, y - 1) == 1)
                    {
                        nodes.Add(new int[] { x, y - 1 });
                        array[x, y - 1] = 2;
                    }
                }

                // Adding node under.
                if (y < height)
                {
                    if (array[x, y + 1] == 0 && getColor(x, y + 1) == 1)
                    {
                        nodes.Add(new int[] { x, y + 1 });
                        array[x, y + 1] = 1;
                    }
                }

                // Adding node left
                if (x > 0)
                {
                    if (array[x - 1, y] == 0 && getColor(x - 1, y) == 1)
                    {
                        nodes.Add(new int[] { x - 1, y });
                        array[x - 1, y] = 4;
                    }
                }

                // Adding node right.
                if (x < width)
                {
                    if ((array[x + 1, y] == 0 || array[x + 1, y] == 5 || array[x + 1, y] == 6) && getColor(x + 1, y) == 1)
                    {
                        nodes.Add(new int[] { x + 1, y });
                        array[x + 1, y] = 3;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding nodes around.", "Error");
                return false;
            }
            return true;
        }
    }
}
