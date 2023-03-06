using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naminari.Auto.Models
{
    public class KeyItems
    {
        public FunctionKeys? FunctionKey { get; set; }
        public List<Keys>? PressedKeys { get; set; }
        public List<Keys>? FollowedKeys { get; set; }
        public Keys? RepeatingKey { get; set; }
        public int? PressTimes { get; set; }

        public KeywordVk[] s_keywords = new KeywordVk[]
      {
            new KeywordVk("ENTER",      Keys.Return),
            new KeywordVk("TAB",        Keys.Tab),
            new KeywordVk("ESC",        Keys.Escape),
            new KeywordVk("ESCAPE",     Keys.Escape),
            new KeywordVk("HOME",       Keys.Home),
            new KeywordVk("END",        Keys.End),
            new KeywordVk("LEFT",       Keys.Left),
            new KeywordVk("RIGHT",      Keys.Right),
            new KeywordVk("UP",         Keys.Up),
            new KeywordVk("DOWN",       Keys.Down),
            new KeywordVk("PGUP",       Keys.Prior),
            new KeywordVk("PGDN",       Keys.Next),
            new KeywordVk("NUMLOCK",    Keys.NumLock),
            new KeywordVk("SCROLLLOCK", Keys.Scroll),
            new KeywordVk("PRTSC",      Keys.PrintScreen),
            new KeywordVk("BREAK",      Keys.Cancel),
            new KeywordVk("BACKSPACE",  Keys.Back),
            new KeywordVk("BKSP",       Keys.Back),
            new KeywordVk("BS",         Keys.Back),
            new KeywordVk("CLEAR",      Keys.Clear),
            new KeywordVk("CAPSLOCK",   Keys.Capital),
            new KeywordVk("INS",        Keys.Insert),
            new KeywordVk("INSERT",     Keys.Insert),
            new KeywordVk("DEL",        Keys.Delete),
            new KeywordVk("DELETE",     Keys.Delete),
            new KeywordVk("HELP",       Keys.Help),
            new KeywordVk("F1",         Keys.F1),
            new KeywordVk("F2",         Keys.F2),
            new KeywordVk("F3",         Keys.F3),
            new KeywordVk("F4",         Keys.F4),
            new KeywordVk("F5",         Keys.F5),
            new KeywordVk("F6",         Keys.F6),
            new KeywordVk("F7",         Keys.F7),
            new KeywordVk("F8",         Keys.F8),
            new KeywordVk("F9",         Keys.F9),
            new KeywordVk("F10",        Keys.F10),
            new KeywordVk("F11",        Keys.F11),
            new KeywordVk("F12",        Keys.F12),
            new KeywordVk("F13",        Keys.F13),
            new KeywordVk("F14",        Keys.F14),
            new KeywordVk("F15",        Keys.F15),
            new KeywordVk("F16",        Keys.F16),
            new KeywordVk("MULTIPLY",   Keys.Multiply),
            new KeywordVk("ADD",        Keys.Add),
            new KeywordVk("SUBTRACT",   Keys.Subtract),
            new KeywordVk("DIVIDE",     Keys.Divide),
            new KeywordVk("+",          Keys.Add),
            new KeywordVk("%",          (Keys.D5 | Keys.Shift)),
            new KeywordVk("^",          (Keys.D6 | Keys.Shift)),
      };
        public class KeywordVk
        {
            public string Keyword;
            public Keys VK;

            public KeywordVk(string keyword, Keys key)
            {
                Keyword = keyword;
                VK = key;
            }
        }
    }

    public enum FunctionKeys
    {
        Shift,
        Ctrl,
        Alt,
    }

  
}
