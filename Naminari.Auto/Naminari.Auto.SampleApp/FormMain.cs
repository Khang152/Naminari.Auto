using Naminari.Auto;

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
            this.lblPosition.Text = $"X : {pos.X} - Y : {pos.Y}";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}