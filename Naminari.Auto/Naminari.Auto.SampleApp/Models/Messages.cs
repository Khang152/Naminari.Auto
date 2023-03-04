using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naminari.Auto.SampleApp.Models
{
    public enum Messages
    {
        [Description("Left Mouse")]
        WM_LBUTTONDOWN = 0x201,

        [Description("Right Mouse")]
        WM_RBUTTONDOWN = 0x204,

        [Description("Middle Mouse")]
        WM_MBUTTONDOWN = 0x207,

        [Description("Left Mouse - Double Click")]
        WM_LBUTTONDBLCLK = 0x203,

        [Description("Right Mouse - Double Click")]
        WM_RBUTTONDBLCLK = 0x206,

        [Description("Middle Mouse - Double Click")]
        WM_MBUTTONDBLCLK = 0x209,
    }
}
