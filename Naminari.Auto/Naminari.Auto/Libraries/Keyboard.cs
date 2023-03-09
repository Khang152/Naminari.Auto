using Naminari.Auto.Models;
using OpenCvSharp.ML;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Windows.Input;


namespace Naminari.Auto
{
    public class Keyboard
    {
        private bool isKeepLatestProcess;
        public bool IsKeepLatestProcess { get => isKeepLatestProcess; set => isKeepLatestProcess = value; }

        private List<string> processes = new List<string>();
        public List<string> Processes { get => processes; set => processes = value; }

        public Keyboard()
        {
            AutomationFocusChangedEventHandler focusHandler = OnFocusChanged;
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }

        private void OnFocusChanged(object sender, AutomationFocusChangedEventArgs e)
        {
            AutomationElement? focusedElement = sender as AutomationElement;
            if (focusedElement != null)
            {
                int processId = focusedElement.Current.ProcessId;
                using (Process process = Process.GetProcessById(processId))
                {
                    if (isKeepLatestProcess == true)
                    {
                        Processes.Clear();
                    }

                    Processes.Insert(0, process.ProcessName);
                    Debug.WriteLine(process.ProcessName);
                }
            }
        }

        public static async Task<bool> TypingAsync(string message, string? processName = null)
        {
            Process? process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process != null)
            {
                try
                {
                    string filteredText = Regex.Replace(message, @"[\{\}\(\)\+\^\%~\[\]]", "{$0}");
                    IntPtr handle = process.MainWindowHandle;
                    SetForegroundWindow(handle);
                    SendKeys.SendWait(filteredText);
                    return await Task.FromResult(true);
                }
                finally
                {
                    process.Dispose();
                }
            }

            return await Task.FromResult(false);
        }

        public static async Task<bool> CommandAsync(string commandKeys, string? processName = null)
        {
            if (string.IsNullOrWhiteSpace(processName))
            {             
                return await SendKeysCombination(commandKeys);
            }

            Process? process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process != null)
            {
                try
                {
                    IntPtr handle = process.MainWindowHandle;
                    SetForegroundWindow(handle);
                    return await SendKeysCombination(commandKeys);
                }
                finally
                {
                    process.Dispose();
                }
            }

            return await Task.FromResult(false);
        }

        public static Task<bool> SendKeysCombination(string keysCombination)
        {
            // Split the keys combination string into individual keys
            string[] keysRelease = keysCombination.Split(',');
            string[] keysPress = new string[0];

            string keyRelease = string.Empty;
            if (keysRelease.Length > 1)
            {
                keysPress = keysRelease[0].Split('+');
                keyRelease = keysRelease[1];
            }
            else
            {
                keysPress = keysCombination.Split('+');
            }

            // Convert each key to the corresponding SendKeys format
            string formattedKeys = "";
            foreach (string key in keysPress)
            {
                formattedKeys += ConvertKeyToFormat(key);
            }

            // Simulate the key press using SendKeys.SendWait
            SendKeys.SendWait(formattedKeys.ToLower());
            if (!string.IsNullOrWhiteSpace(keyRelease))
            {
                SendKeys.SendWait(ConvertKeyToFormat(keyRelease));
            }

            return Task.FromResult(true);
        }

        public static string ConvertKeyToFormat(string key)
        {
            // Convert the key string to the corresponding SendKeys format
            switch (key.ToLower())
            {
                case "ctrl":
                    return "^";
                case "alt":
                    return "%";
                case "shift":
                    return "+";
                case "enter":
                    return "{ENTER}";
                case "tab":
                    return "{TAB}";
                case "esc":
                case "escape":
                    return "{ESC}";
                case "home":
                    return "{HOME}";
                case "end":
                    return "{END}";
                case "left":
                    return "{LEFT}";
                case "right":
                    return "{RIGHT}";
                case "up":
                    return "{UP}";
                case "down":
                    return "{DOWN}";
                case "pgup":
                    return "{PGUP}";
                case "pgdn":
                    return "{PGDN}";
                case "numlock":
                    return "{NUMLOCK}";
                case "scrolllock":
                    return "{SCROLLLOCK}";
                case "prtsc":
                    return "{PRTSC}";
                case "break":
                    return "{BREAK}";
                case "backspace":
                case "bksp":
                case "bs":
                    return "{BACKSPACE}";
                case "clear":
                    return "{CLEAR}";
                case "capslock":
                    return "{CAPSLOCK}";
                case "ins":
                case "insert":
                    return "{INSERT}";
                case "del":
                case "delete":
                    return "{DELETE}";
                case "help":
                    return "{HELP}";
                case "f1":
                    return "{F1}";
                case "f2":
                    return "{F2}";
                case "f3":
                    return "{F3}";
                case "f4":
                    return "{F4}";
                case "f5":
                    return "{F5}";
                case "f6":
                    return "{F6}";
                case "f7":
                    return "{F7}";
                case "f8":
                    return "{F8}";
                case "f9":
                    return "{F9}";
                case "f10":
                    return "{F10}";
                case "f11":
                    return "{F11}";
                case "f12":
                    return "{F12}";
                case "f13":
                    return "{F13}";
                case "f14":
                    return "{F14}";
                case "f15":
                    return "{F15}";
                case "f16":
                    return "{F16}";
                case "multiply":
                    return "{MULTIPLY}";
                case "add":
                    return "{ADD}";
                case "subtract":
                    return "{SUBTRACT}";
                case "divide":
                    return "{DIVIDE}";
                default:
                    return key.ToLower();
            }
        }

        // Activate an application window.
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
