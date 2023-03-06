using Naminari.Auto.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Automation;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;


namespace Naminari.Auto.Libraries
{
    public class Keyboard
    {
        private bool isKeepLastestProccess;
        public bool IsKeepLastestProccess { get => isKeepLastestProccess; set => isKeepLastestProccess = value; }
        public List<string> proccesses { get; set; } = new List<string>();

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
                    if (IsKeepLastestProccess == true)
                    {
                        proccesses.Clear();
                    }

                    proccesses.Insert(0, process.ProcessName);
                    Debug.WriteLine(process.ProcessName);
                }
            }
        }

        public static async Task<bool> TypingAsync(string message)
        {
            var sb = new StringBuilder();
            foreach (var c in message)
            {
                switch (c)
                {
                    case '+':
                    case '^':
                    case '%':
                    case '~':
                    case '(':
                    case ')':
                    case '[':
                    case ']':
                    case '{':
                    case '}':
                        sb.Append('{');
                        sb.Append(c);
                        sb.Append('}');
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            SendKeys.SendWait(sb.ToString());
            return await Task.FromResult(true);
        }

        public static async Task<bool> CommandAsync(string commandKeys, string? proccessName = null)
        {
            if (string.IsNullOrEmpty(proccessName))
            {
                SendKeys.SendWait(commandKeys);
                return await Task.FromResult(true);
            }

            Process? p = Process.GetProcessesByName(proccessName).FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait(commandKeys);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public static async Task<bool> CommandAsync(KeyItems keyItems, string? proccessName = null)
        {
            var commandKeys = string.Empty;

            var sb = new StringBuilder();
            switch (keyItems.FunctionKey)
            {
                case FunctionKeys.Shift:
                    sb.Append('+');
                    break;
                case FunctionKeys.Ctrl:
                    sb.Append('^');
                    break;
                case FunctionKeys.Alt:
                    sb.Append('%');
                    break;
                default:
                    break;
            }

            keyItems.PressedKeys ??= new List<Keys>();
            keyItems.FollowedKeys ??= new List<Keys>();

            foreach (var key in keyItems.PressedKeys)
            {
                var sbm = new StringBuilder();
                var IsKey = keyItems.s_keywords.Where(o => o.VK == key);
                if (IsKey.Any())
                {

                    sbm.Append('{');
                    sbm.Append(IsKey?.FirstOrDefault()?.Keyword);
                    sbm.Append('}');
                }
                else
                {
                    sbm.Append(key.ToString());
                }

                if (!keyItems.FollowedKeys.Any())
                {
                    sb.Append('(');
                    sb.Append(sbm);
                    sb.Append(')');

                    commandKeys = sb.ToString();
                    return await CommandAsync(commandKeys.ToLower(), proccessName);
                }
            }

            foreach (var key in keyItems.FollowedKeys)
            {
                var IsKey = keyItems.s_keywords.Where(o => o.VK == key);
                if (IsKey.Any())
                {
                    sb.Append('{');
                    sb.Append(IsKey?.FirstOrDefault()?.Keyword);
                    sb.Append('}');
                }
                else
                {
                    sb.Append(key.ToString());
                }

                commandKeys = sb.ToString();
                return await CommandAsync(commandKeys.ToLower(), proccessName);
            }

            commandKeys = sb.ToString();
            return await CommandAsync(commandKeys.ToLower(), proccessName);
        }

        public static KeyItems KeysCombined(FunctionKeys functionKeys)
        {
            var keyItems = new KeyItems();
            keyItems.FunctionKey = functionKeys;
            return keyItems;
        }

        public static KeyItems KeysRepeating(Keys key)
        {
            var keyItems = new KeyItems();
            keyItems.RepeatingKey = key;
            return keyItems;
        }

        // Activate an application window.
        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
