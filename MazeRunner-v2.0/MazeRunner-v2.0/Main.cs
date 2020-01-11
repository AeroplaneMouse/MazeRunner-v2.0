using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

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
         */


        private int[,] array = new int[200, 200];
        private int width = 0;
        private int height = 0;
        private Bitmap maze;
        private int[] startPos = { 0, 0 };
        private int[] endPos = { 0, 0 };
        private ArrayList nodes = new ArrayList();
        private OpenFileDialog openFileDialog;
        private bool slowMode = false;

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose a loaded image opon closing
        /// </summary>
        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (maze != null)
                maze.Dispose();
        }

        /// <summary>
        /// Close the application
        /// </summary>
        private void btn_closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool succeeded = true;
                try
                {
                    maze = new Bitmap((Bitmap)Image.FromFile(openFileDialog.FileName));
                    width = maze.Width;
                    height = maze.Height;
                }
                catch (Exception)
                {
                    succeeded = false;
                    updateLog("Error loading maze!");
                }
                if (succeeded)
                {
                    pictureBox.Image = maze;
                    int[][] openings = findOpeningOnSides(1);
                    startPos = openings[0];
                    endPos = openings[1];

                    if ((startPos[0] == 0 && startPos[1] == 0))
                    {
                        openings = findOpeningOnSides(0);
                        startPos = openings[0];
                        endPos = openings[1];

                        if (startPos[0] == 0 && startPos[1] == 0)
                        {
                            updateLog("Could not find start and end!");
                            return;
                        }
                        else updateLog("Maze loaded correctly.");
                    }
                    else updateLog("Maze loaded correctly.");
                }
            }
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {
            // Start the solving algorithm 
            if (!slowMode)
            {
                nodes.Clear();
                if ((startPos[0] != 0 && startPos[1] != 0) || (endPos[0] != 0 && endPos[1] != 0))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    if (!addNodesAround(maze, startPos)) return;

                    int i = 0;
                    int[] test = { 0, 0 };
                    bool noError = true;
                    while (true)
                    {
                        if (i < nodes.Count)
                        {
                            test = nodes[i] as int[];
                            if (test[0] == endPos[0] && test[1] == endPos[1])
                            {
                                stopwatch.Stop();
                                updateLog("Maze solved!");
                                break;
                            }
                        }
                        else
                        {
                            updateLog("i = nodes.Count");
                            noError = false;
                            break;
                        }

                        try
                        {
                            if (!addNodesAround(maze, nodes[i] as int[]))
                            {
                                noError = false;
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            noError = false;
                            updateLog("Arraylist - out of range.");
                            break;
                        }
                        i++;
                    }
                    if (noError)
                    {
                        updateLog("Nodes = " + nodes.Count);
                        drawPath();
                        string filePath_raw = openFileDialog.FileName;
                        string[] filePath_splited = filePath_raw.Split('.');
                        string newFilePath = "";
                        for (i = 0; i < filePath_splited.Length - 2; i++)
                        {
                            newFilePath += filePath_splited[i] + ".";
                        }
                        newFilePath += filePath_splited[filePath_splited.Length - 2] + "_solved." + filePath_splited[filePath_splited.Length - 1];
                        maze.Save(newFilePath);
                        pictureBox.Image = maze;
                        btn_load.Enabled = true;
                        btn_solve.Enabled = true;
                        btn_slowMode.Enabled = true;
                        updateLog("It took: " + Convert.ToString(stopwatch.ElapsedMilliseconds) + " milliseconds.");
                    }
                    else
                    {
                        stopwatch.Stop();
                    }
                }
                else
                {
                    updateLog("Invalid start position or end position. (0,0)");
                    return;
                }
            }
            else
            {
                Bitmap mazeClone = (Bitmap)maze.Clone();
                backgroundWorker.RunWorkerAsync(mazeClone);
                btn_load.Enabled = false;
                btn_solve.Enabled = false;
                btn_slowMode.Enabled = false;
            }
        }

        private void btn_slowMode_Click(object sender, EventArgs e)
        {
            // Activate or deactivate slow mode when pushed.
            if (!slowMode)
            {
                btn_slowMode.ForeColor = Color.FromName("Green");
                slowMode = true;
            }
            else
            {
                btn_slowMode.ForeColor = Color.FromName("Red");
                slowMode = false;
            }
        }

        private void btn_clearLog_Click(object sender, EventArgs e)
        {
            txt_log.Text = "";
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
                    if (getColor(maze, 0, y) == 1)
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
                    if (getColor(maze, x, y) == 1)
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
                    if (getColor(maze, x, 0) == 1)
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
                    if (getColor(maze, x, y) == 1)
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

        private int getColor(Bitmap mazeImport, int x, int y)
        {
            /*
             * 0 = black
             * 1 = white
             */
            Color color = mazeImport.GetPixel(x, y);
            if (color.R < 50 && color.G < 50 && color.B < 50) return 0;
            else return 1;
        }

        private object[] setColor(Bitmap mazeImport, int x, int y, string _color)
        {
            Color color = Color.FromName(_color);
            try
            {
                mazeImport.SetPixel(x, y, color);
            }
            catch
            {
                return new object[] { mazeImport, false };
            }
            return new object[] { mazeImport, true };
        }

        private void drawPath()
        {
            int x = endPos[0];
            int y = endPos[1];
            int[] pos = { x, y };
            int counter = 0;
            while (true)
            {
                pos[0] = x;
                pos[1] = y;
                if (slowMode)
                {
                    backgroundWorker.ReportProgress(1, pos);
                    if (counter%2== 0) Thread.Sleep(1);
                }
                else setColor(maze, x, y, "Green");

                if (array[x, y] == 1) y--;
                else if (array[x, y] == 2) y++;
                else if (array[x, y] == 3) x--;
                else if (array[x, y] == 4) x++;
                else if (array[x, y] == 5) break;
            }
            appendTextBox_log("Path has been drawn!");
        }

        private bool addNodesAround(Bitmap mazeImport, int[] pos)
        {
            try
            {
                int x = pos[0];
                int y = pos[1];

                // Adding node over.
                if (y > 0)
                {
                    if (array[x, y - 1] == 0 && getColor(mazeImport, x, y - 1) == 1)
                    {
                        nodes.Add(new int[] { x, y - 1 });
                        array[x, y - 1] = 2;
                    }
                }

                // Adding node under.
                if (y < height - 1)
                {
                    if (array[x, y + 1] == 0 && getColor(mazeImport, x, y + 1) == 1)
                    {
                        nodes.Add(new int[] { x, y + 1 });
                        array[x, y + 1] = 1;
                    }
                }

                // Adding node left
                if (x > 0)
                {
                    if (array[x - 1, y] == 0 && getColor(mazeImport, x - 1, y) == 1)
                    {
                        nodes.Add(new int[] { x - 1, y });
                        array[x - 1, y] = 4;
                    }
                }

                // Adding node right.
                if (x < width - 1)
                {
                    if ((array[x + 1, y] == 0 || array[x + 1, y] == 5) && getColor(mazeImport, x + 1, y) == 1)
                    {
                        nodes.Add(new int[] { x + 1, y });
                        array[x + 1, y] = 3;
                    }
                }
            }
            catch (Exception)
            {
                appendTextBox_log("Error adding nodes around.");
                return false;
            }
            return true;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            nodes.Clear();
            Bitmap mazeClone = (Bitmap)e.Argument;

            if ((startPos[0] != 0 && startPos[1] != 0) || (endPos[0] != 0 && endPos[1] != 0))
            {
                if (!addNodesAround(mazeClone, startPos)) return;
                int i = 0;
                int[] test = { 0, 0 };
                while (true)
                {
                    if (i < nodes.Count)
                    {
                        test = nodes[i] as int[];
                        if (test[0] == endPos[0] && test[1] == endPos[1])
                        {
                            appendTextBox_log("Maze solved!");
                            break;
                        }
                        backgroundWorker.ReportProgress(0, test);
                    }
                    else
                    {
                        appendTextBox_log("i = nodes.Count");
                        e.Cancel = true;
                        return;
                    }

                    try
                    {
                        if (!addNodesAround(mazeClone, nodes[i] as int[])) return;
                    }
                    catch (Exception)
                    {
                        appendTextBox_log("Arraylist - out of range.");
                        return;
                    }
                    if (i%9 == 0) Thread.Sleep(1);
                    i++;
                }
                drawPath();
            }
            else
            {
                appendTextBox_log("Invalid start position or end position. (0,0)");
                return;
            }
            mazeClone.Dispose();
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                int[] data = e.UserState as int[];
                int x = data[0];
                int y = data[1];
                setColor(maze, x, y, "Red");
                pictureBox.Image = maze;
            }
            else if(e.ProgressPercentage == 1)
            {
                int[] data = e.UserState as int[];
                int x = data[0];
                int y = data[1];
                setColor(maze, x, y, "Green");
                pictureBox.Image = maze;
            }
            else
            {
                updateLog("Error. Wrong progress value.");
            }
        }

        private void appendTextBox_log(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(appendTextBox_log), new object[] { value });
                return;
            }
            if (txt_log.Text == "") txt_log.Text = value + Environment.NewLine;
            else txt_log.Text = value + Environment.NewLine + txt_log.Text;
        }

        private void updateLog(string value)
        {
            if (txt_log.Text == "") txt_log.Text = value + Environment.NewLine;
            else txt_log.Text = value + Environment.NewLine + txt_log.Text;
        }

        private void workCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                updateLog("Nodes = " + nodes.Count);
                string filePath_raw = openFileDialog.FileName;
                string[] filePath_splited = filePath_raw.Split('.');
                string newFilePath = "";
                for (int i = 0; i < filePath_splited.Length - 2; i++)
                {
                    newFilePath += filePath_splited[i] + ".";
                }
                newFilePath += filePath_splited[filePath_splited.Length - 2] + "_solved." + filePath_splited[filePath_splited.Length - 1];
                maze.Save(newFilePath);
                pictureBox.Image = maze;
                btn_load.Enabled = true;
                btn_solve.Enabled = true;
                btn_slowMode.Enabled = true;
            }
            else
            {
                updateLog("Error. workCompleted()");
            }
        }
    }
}
