using EscapeFromTheWoods.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Map
    {
        public Map(int xmin, int xmax, int ymin, int ymax)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.ymin = ymin;
            this.ymax = ymax;
            this.Grid = new Grid(xmin, xmax, ymin, ymax); // Check deze lijn voor initialisatie van de Grid
        }

        public int xmin { get; set; }
        public int xmax { get; set; }
        public int ymin { get; set; }
        public int ymax { get; set; }

        public Grid Grid { get; set; }
    }

}
