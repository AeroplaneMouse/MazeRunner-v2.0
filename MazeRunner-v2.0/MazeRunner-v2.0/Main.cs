using System;
using System.Windows.Forms;

namespace MazeRunner_v2._0
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                }
            }
            
            // Find image
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {
            // Convert image to array
            // Find shortest route
            // Draw path to image
            // Create new image with shortest path
            // Message "Maze solved" 

        }
    }
}
