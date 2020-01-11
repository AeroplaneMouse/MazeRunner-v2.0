using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRunner_v2._0
{
    class TextBoxLogger : ILogger
    {
        private TextBox _box;

        public TextBoxLogger(TextBox textBox)
        {
            _box = textBox;
        }

        /// <summary>
        /// Clear the contents of the textBox
        /// </summary>
        public void Clear()
        {
            _box.Text = "";
        }

        /// <summary>
        /// Log a string to the TextBox
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            _box.Text += message + Environment.NewLine;
        }
    }
}
