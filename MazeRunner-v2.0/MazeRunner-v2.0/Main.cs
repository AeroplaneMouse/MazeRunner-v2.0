using System;
using System.Drawing;
using System.Diagnostics;
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


        private int[,] array = new int[10000, 10000];
        private int width = 0;
        private int height = 0;
        private Bitmap maze;
        private int[] startPos = { 0, 0 };
        private int[] endPos = { 0, 0 };
        private ArrayList nodes = new ArrayList();
        private OpenFileDialog openFileDialog;

        public Main()
        {
            InitializeComponent();
            //nodes.Add(1);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
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
                        else MessageBox.Show("Maze loaded correctly.");
                    }
                    else MessageBox.Show("Maze loaded correctly.");
                }
            }
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {
            nodes.Clear();

            if (startPos != new int[] { 0, 0 } && endPos != new int[] { 0, 0 })
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
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
                            stopwatch.Stop();
                            MessageBox.Show("Maze solved!");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("i = nodes.Count", "Error");
                        stopwatch.Stop();
                        return;
                    }

                    try
                    {
                        if (!addNodesAround(nodes[i] as int[]))
                        {
                            stopwatch.Stop();
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        stopwatch.Stop();
                        MessageBox.Show("Arraylist - out of range.", "Error");
                        return;
                    }
                    i++;
                }

                drawPath();
                string filePath_raw = openFileDialog.FileName;
                string[] filePath_splited = filePath_raw.Split('.');
                string newFilePath = "";
                for (i = 0; i < filePath_splited.Length-2; i++)
                {
                    newFilePath += filePath_splited[i] + ".";
                }
                newFilePath += filePath_splited[filePath_splited.Length - 2] + "_solved." + filePath_splited[filePath_splited.Length - 1];
                maze.Save(newFilePath);
                pictureBox.Image = maze;
                MessageBox.Show("It took: " + Convert.ToString(stopwatch.ElapsedMilliseconds) + " milliseconds.", "Time");
            }
            else
            {
                MessageBox.Show("Invalid start position. (0,0)", "Error");
                return;
            }
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
                        array[x, y] = 0;
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
                        array[x, y] = 0;
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
            if (color.R < 50 && color.G < 50 && color.B < 50) return 0;
            else return 1;
        }

        private void setColor(int x, int y, string _color)
        {
            Color color = Color.FromName(_color);
            maze.SetPixel(x, y, color);
        }

        private void drawPath()
        {
            int x = endPos[0];
            int y = endPos[1];

            while (true)
            {
                setColor(x, y, "Green");

                if (array[x, y] == 1) y--;
                else if (array[x, y] == 2) y++;
                else if (array[x, y] == 3) x--;
                else if (array[x, y] == 4) x++;
                else if (array[x, y] == 5) break;
            }
            MessageBox.Show("Path has been drawn!");
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
                if (x < width - 1)
                {
                    if ((array[x + 1, y] == 0 || array[x + 1, y] == 5) && getColor(x + 1, y) == 1)
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
