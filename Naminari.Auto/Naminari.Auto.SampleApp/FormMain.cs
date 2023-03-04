using Naminari.Auto.SampleApp.Library;
using Naminari.Auto.SampleApp.Models;
using System.Runtime.InteropServices;

namespace Naminari.Auto.SampleApp
{
    public partial class FormMain : Form
    {
        private static System.Windows.Forms.Timer? timer;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var pos = Mouse.GetPosition();
            lblPosition.Text = $"Position : X : {pos.X} - Y : {pos.Y}";
        }

        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                case (int)Messages.WM_LBUTTONDOWN:
                    lblTypeButton.Text = GetSwapButtonThreshold() > 0 ? $"Type Button : {Messages.WM_RBUTTONDOWN.GetDescription()}" : $"Type Button : {Messages.WM_LBUTTONDOWN.GetDescription()}";
                    lblTypeClick.Text = $"Type Click : Normal Click";
                    break;

                case (int)Messages.WM_RBUTTONDOWN:
                    lblTypeButton.Text = GetSwapButtonThreshold() > 0 ? $"Type Button : {Messages.WM_LBUTTONDOWN.GetDescription()}" : $"Type Button : {Messages.WM_RBUTTONDOWN.GetDescription()}";
                    lblTypeClick.Text = $"Type Click : Normal Click";
                    break;

                case (int)Messages.WM_MBUTTONDOWN:
                    lblTypeButton.Text = $"Type Button : {Messages.WM_MBUTTONDOWN.GetDescription()}";
                    lblTypeClick.Text = $"Type Click : Normal Click";
                    break;

                case (int)Messages.WM_LBUTTONDBLCLK:
                    lblTypeClick.Text = $"Type Click : Double Click";
                    break;

                case (int)Messages.WM_RBUTTONDBLCLK:
                    lblTypeClick.Text = $"Type Click : Double Click";
                    break;

                case (int)Messages.WM_MBUTTONDBLCLK:
                    lblTypeClick.Text = $"Type Click : Double Click";
                    break;
            }
            base.WndProc(ref m);
        }

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int index);
        private const int SM_SWAPBUTTON = 23;
        public static int GetSwapButtonThreshold()
        {
            return GetSystemMetrics(SM_SWAPBUTTON);
        }
    }
}