using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Automation;


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
            return await Task.Run(() =>
            {
                SendKeys.SendWait(message);
                return true;
            });
        }

        public static async Task<bool> InputAsync(string message)
        {
            return await Task.Run(() =>
            {
                SendKeys.Send(message);
                return true;
            });
        }

        public static async Task<bool> CommandAsync(string commandKeys, string? proccessName = null)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(proccessName))
                {
                    SendKeys.SendWait(commandKeys);
                    return true;
                }

                Process? p = Process.GetProcessesByName(proccessName).FirstOrDefault();
                if (p != null)
                {
                    IntPtr h = p.MainWindowHandle;
                    SetForegroundWindow(h);
                    SendKeys.SendWait(commandKeys);
                    return true;
                }

                return false;
            });
        }

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
