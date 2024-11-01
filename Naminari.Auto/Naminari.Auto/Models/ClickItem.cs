using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naminari.Auto.Models
{
    public class ClickItem
    {
        public Point? Position { get; set; }
        public Bitmap? Bitmap { get; set; }
        public MouseButtons? Button { get; set; }
        public Color? Color { get; set; }
    }

    public enum ClickTypes
    {
        Single = 0,
        Double = 1
    }

    public enum ActionTypes
    {
        None = 0,
        Hold = 1,
        Release = 2
    }
}
