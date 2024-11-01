using Naminari.Auto.Models;
using System.Runtime.InteropServices;

namespace Naminari.Auto
{
    public static class Mouse
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x2;
        private const int MOUSEEVENTF_LEFTUP = 0x4;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENTF_MIDDLEUP = 0x40;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int SM_SWAPBUTTON = 23;

        public static bool Click(MouseButtons mouseButtons = MouseButtons.Left, ClickTypes clickTypes = ClickTypes.Single)
        {
            return ClickAsync(mouseButtons, clickTypes).Result;
        }

        public static bool Hold(MouseButtons mouseButtons = MouseButtons.Left)
        {
            return HoldAsync(mouseButtons).Result;
        }

        public static bool Release(MouseButtons mouseButtons = MouseButtons.Left)
        {
            return ReleaseAsync(mouseButtons).Result;
        }

        private static uint GetMouseButtonDownFlag(MouseButtons mouseButtons, ActionTypes action)
        {
            // Get Adjusted MouseButton
            mouseButtons = GetAdjustedMouseButton(mouseButtons);

            // Determine the appropriate flag for the specified button
            return (mouseButtons, action) switch
            {
                (MouseButtons.Left, ActionTypes.Hold) => MOUSEEVENTF_LEFTDOWN,
                (MouseButtons.Right, ActionTypes.Hold) => MOUSEEVENTF_RIGHTDOWN,
                (MouseButtons.Middle, ActionTypes.Hold) => MOUSEEVENTF_MIDDLEDOWN,
                (MouseButtons.Left, ActionTypes.Release) => MOUSEEVENTF_LEFTUP,
                (MouseButtons.Right, ActionTypes.Release) => MOUSEEVENTF_RIGHTUP,
                (MouseButtons.Middle, ActionTypes.Release) => MOUSEEVENTF_MIDDLEUP,
                _ => throw new ArgumentException("Unsupported mouse button")
            };
        }

        private static MouseButtons GetAdjustedMouseButton(MouseButtons mouseButtons)
        {
            if (GetSwapButtonThreshold() > 0)
            {
                return mouseButtons == MouseButtons.Left ? MouseButtons.Right :
                       mouseButtons == MouseButtons.Right ? MouseButtons.Left : mouseButtons;
            }
            return mouseButtons;
        }

        public static async Task<bool> HoldAsync(MouseButtons mouseButtons = MouseButtons.Left, ActionTypes action = ActionTypes.Hold)
        {
            uint dwFlags = GetMouseButtonDownFlag(mouseButtons, action);
            INPUT[] inputsDown = new INPUT[1];
            inputsDown[0].type = INPUT_MOUSE;
            inputsDown[0].mi.dwFlags = dwFlags;
            SendInput(1, inputsDown, Marshal.SizeOf(typeof(INPUT)));

            return await Task.FromResult(true);
        }

        public static async Task<bool> ReleaseAsync(MouseButtons mouseButtons = MouseButtons.Left, ActionTypes action = ActionTypes.Release)
        {
            uint dwFlags = GetMouseButtonDownFlag(mouseButtons, action);
            INPUT[] inputsUp = new INPUT[1];
            inputsUp[0].type = INPUT_MOUSE;
            inputsUp[0].mi.dwFlags = dwFlags;
            SendInput(1, inputsUp, Marshal.SizeOf(typeof(INPUT)));

            return await Task.FromResult(true);
        }

        public static async Task<bool> ClickAsync(MouseButtons mouseButtons = MouseButtons.Left, ClickTypes clickTypes = ClickTypes.Single)
        {
            mouseButtons = GetAdjustedMouseButton(mouseButtons);

            if (clickTypes == ClickTypes.Double)
            {
                await PerformClick(mouseButtons);
                await Task.Delay(200);
            }
            else
            {
                await PerformClick(mouseButtons);
            }

            return true;
        }

        private static async Task PerformClick(MouseButtons mouseButtons)
        {
            int downFlag, upFlag;
            switch (mouseButtons)
            {
                case MouseButtons.Left:
                    downFlag = MOUSEEVENTF_LEFTDOWN;
                    upFlag = MOUSEEVENTF_LEFTUP;
                    break;
                case MouseButtons.Right:
                    downFlag = MOUSEEVENTF_RIGHTDOWN;
                    upFlag = MOUSEEVENTF_RIGHTUP;
                    break;
                case MouseButtons.Middle:
                    downFlag = MOUSEEVENTF_MIDDLEDOWN;
                    upFlag = MOUSEEVENTF_MIDDLEUP;
                    break;
                default:
                    throw new ArgumentException("Unsupported mouse button");
            }

            mouse_event(downFlag, 0, 0, 0, 0);
            await Task.Delay(100);
            mouse_event(upFlag, 0, 0, 0, 0);
        }

        public static Point GetPosition()
        {
            var point = new POINT();
            GetCursorPos(out point);
            return point;
        }

        public static bool SetPosition(int X, int Y)
        {
            return SetPositionAsync(X, Y).Result;
        }

        public static async Task<bool> SetPositionAsync(int X, int Y)
        {
            return await Task.Run(() =>
            {
                SetCursorPos(X, Y);
                return true;
            });
        }

        public static Color GetPixelColor(this Point pt)
        {
            var screen = Utils.GetScreenShot();
            using (Graphics gdest = Graphics.FromImage(screen))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, pt.X, pt.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }
            return screen.GetPixel(0, 0);
        }

        public static int GetSwapButtonThreshold()
        {
            return GetSystemMetrics(SM_SWAPBUTTON);
        }

        [DllImport("gdi32.dll")]
        private static extern int BitBlt
        (
            IntPtr hdcDest,     // handle to destination DC (device context)
            int nXDest,         // x-coord of destination upper-left corner
            int nYDest,         // y-coord of destination upper-left corner
            int nWidth,         // width of destination rectangle
            int nHeight,        // height of destination rectangle
            IntPtr hdcSrc,      // handle to source DC
            int nXSrc,          // x-coordinate of source upper-left corner
            int nYSrc,          // y-coordinate of source upper-left corner
            int dwRop  // raster operation code
        );

        [DllImport("User32.dll")]
        private static extern bool GetCursorPos(out POINT lppoint);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int index);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern void SetCursorPos(int X, int Y);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X { get; set; }
            public int Y { get; set; }

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        private const uint INPUT_MOUSE = 0;
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }
    }
}