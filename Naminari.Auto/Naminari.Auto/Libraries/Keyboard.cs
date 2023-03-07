using Naminari.Auto.Models;
using OpenCvSharp.ML;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Automation;


namespace Naminari.Auto.Libraries
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

        public static async Task<bool> TypingAsync(string message)
        {
            string filteredText = Regex.Replace(message, @"[\{\}\(\)\+\^\%~\[\]]", "{$0}");
            SendKeys.SendWait(filteredText);
            return await Task.FromResult(true);
        }

        public static async Task<bool> CommandAsync(string commandKeys, string? processName = null)
        {
            if (string.IsNullOrWhiteSpace(processName))
            {
                SendKeys.SendWait(commandKeys);
                return await Task.FromResult(true);
            }

            Process? process = Process.GetProcessesByName(processName).FirstOrDefault();
            if (process != null)
            {
                try
                {
                    IntPtr handle = process.MainWindowHandle;
                    SetForegroundWindow(handle);
                    SendKeys.SendWait(commandKeys);
                    return await Task.FromResult(true);
                }
                finally
                {
                    process.Dispose();
                }
            }

            return await Task.FromResult(false);
        }

        public static async Task<bool> CommandAsync(KeyItems keyItems, string? processName = null)
        {
            var commandKeys = "";

            var keyStringBuilder = new StringBuilder();
            switch (keyItems.FunctionKey)
            {
                case FunctionKeys.Shift:
                    keyStringBuilder.Append('+');
                    break;
                case FunctionKeys.Ctrl:
                    keyStringBuilder.Append('^');
                    break;
                case FunctionKeys.Alt:
                    keyStringBuilder.Append('%');
                    break;
            }

            if (keyItems.PressedKeys != null && keyItems.PressedKeys.Any())
            {
                var pressedKeysString = string.Join("", keyItems.PressedKeys.Select(GetKey));
                if (keyItems.FollowedKeys != null && keyItems.FollowedKeys.Any())
                {
                    keyStringBuilder.Append(pressedKeysString);
                    keyStringBuilder.Append(string.Join("", keyItems.FollowedKeys.Select(GetKey)));
                }
                else
                {
                    keyStringBuilder.Append($"({pressedKeysString})");
                }
            }

            if (keyItems.RepeatingKey != null && keyItems.PressTimes > 0)
            {
                keyStringBuilder.Append($"{{{GetKey(keyItems.RepeatingKey.Value)} {keyItems.PressTimes}}}");
            }

            commandKeys = keyStringBuilder.ToString().ToLower();
            return await CommandAsync(commandKeys, processName);
        }

        private static string GetKey(Keys key)
        {
            var keyData = KeyAll.Data.FirstOrDefault(o => o.VK == key);
            return keyData?.Keyword ?? key.ToString();
        }

        public static KeyItems KeysCombined(FunctionKeys functionKeys) => new KeyItems { FunctionKey = functionKeys };

        public static KeyItems KeysRepeating(Keys key) => new KeyItems { RepeatingKey = key };

        // Activate an application window.
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
