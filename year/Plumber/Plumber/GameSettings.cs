using System;
using System.Collections.Generic;
using System.Text;

namespace Plumber
{
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 80;
        public int ConsoleHight { get; set; } = 30;

        public int NumberOfRows { get; set; } = 20;
        public int NumberOfCools { get; set; } = 20;

        public int StartXCoordinate { get; set; } = 10;
        public int StartYCoordinate { get; set; } = 10;

        public char Background { get; set; } = 'x';

    }
}
