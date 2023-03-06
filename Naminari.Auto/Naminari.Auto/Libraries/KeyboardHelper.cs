using Naminari.Auto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naminari.Auto.Libraries
{
    public static class KeyboardHelper
    {
        public static KeyItems Pressed(this KeyItems keyItems, params Keys[] keys)
        {
            keyItems ??= new KeyItems();
            keyItems.PressedKeys = keys.ToList();
            return keyItems;
        }

        public static KeyItems Followed(this KeyItems keyItems, params Keys[] keys)
        {
            keyItems ??= new KeyItems();
            keyItems.FollowedKeys = keys.ToList();
            return keyItems;
        }

        public static KeyItems Press(this KeyItems keyItems, int times)
        {
            keyItems ??= new KeyItems();
            keyItems.PressTimes = times;
            return keyItems;
        }
    }
}
