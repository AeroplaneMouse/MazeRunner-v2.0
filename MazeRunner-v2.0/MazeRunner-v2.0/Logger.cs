using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner_v2._0
{
    interface ILogger
    {
        void Log(string message);
        void Clear();

    }
}
