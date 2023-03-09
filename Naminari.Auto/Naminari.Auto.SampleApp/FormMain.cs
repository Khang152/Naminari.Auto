using Gma.System.MouseKeyHook;
using Naminari.Auto.SampleApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Automation;

namespace Naminari.Auto.SampleApp
{
    public partial class FormMain : Form
    {
        private IKeyboardMouseEvents? m_Events;
        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private List<ActionItem> actionItems = new List<ActionItem>();
        private Keyboard? keyboard;
        private Point startPoint;

        public FormMain()
        {
            InitializeComponent();
            keyboard = new Keyboard();
            keyboard.IsKeepLatestProcess = true;
        }

        private void InitializeLayout()
        {
            lblPosition.Text = Const.LBL_POSITION_TEXT;
            lblTypeButton.Text = Const.LBL_TYPEBUTTON_TEXT;
            lblTypeClick.Text = Const.LBL_TYPECLICK_TEXT;
            lblScreenSelect.Text = string.Empty;

            if (!chkKeepList.Checked)
            {
                actionItems.Clear();
                grvAction.DataSource = actionItems;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeLayout();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.MouseClick += OnMouseClick;
            m_Events.MouseDoubleClick += OnMouseDoubleClick;
            m_Events.MouseMove += HookManager_MouseMove;
            m_Events.MouseDown += OnMouseDown;
            m_Events.MouseUp += OnMouseUp;
        }

        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.MouseClick -= OnMouseClick;
            m_Events.MouseDoubleClick -= OnMouseDoubleClick;
            m_Events.MouseMove -= HookManager_MouseMove;
            m_Events.MouseDown -= OnMouseDown;
            m_Events.MouseUp -= OnMouseUp;
            m_Events.Dispose();
        }

        private void SubscribeImage(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.MouseDown += OnMouseDown;
            m_Events.MouseUp += OnMouseUp;
        }

        private void UnsubscribeImage()
        {
            if (m_Events == null) return;
            m_Events.MouseDown -= OnMouseDown;
            m_Events.MouseUp -= OnMouseUp;
            m_Events.Dispose();
        }

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            if (btnStartImage.Text == Const.BTN_START_TEXT)
            {
                return;
            }

            startPoint = e.Location;
        }

        private void OnMouseUp(object? sender, MouseEventArgs e)
        {
            if (btnStartImage.Text == Const.BTN_START_TEXT)
            {
                return;
            }
            
            Rectangle area = new Rectangle
                (Math.Min(startPoint.X, e.Location.X),
                Math.Min(startPoint.Y, e.Location.Y),
                Math.Abs(startPoint.X - e.Location.X),
                Math.Abs(startPoint.Y - e.Location.Y));

            Bitmap bmp = Naminari.Auto.Utils.GetImageFromSelect(area);
            ptbImage.Image = bmp;

            if (btnStartImage.Text == Const.BTN_STOP_TEXT)
            {
                btnStartImage.PerformClick();
            }
        }

        private void OnMouseClick(object? sender, MouseEventArgs e)
        {
            lblTypeButton.Text = $"Type Button : {e.Button.ToString()}";
            lblTypeClick.Text = Const.LBL_NORMALCLICK_TEXT;

            var position = Mouse.GetPosition();
            actionItems.Insert(0, new ActionItem() { X = position.X, Y = position.Y, Color = position.GetPixelColor().Name, Process = keyboard?.Processes?.FirstOrDefault() ?? string.Empty });

            var bindingList = new BindingList<ActionItem>(actionItems);
            var source = new BindingSource(bindingList, null);
            grvAction.DataSource = source;
        }

        private void OnMouseDoubleClick(object? sender, MouseEventArgs e)
        {
            lblTypeButton.Text = $"Type Button : {e.Button.ToString()}";
            lblTypeClick.Text = Const.LBL_DOUBLECLICK_TEXT;
        }

        private void HookManager_MouseMove(object? sender, MouseEventArgs e)
        {
            lblPosition.Text = $"Position : X : {e.X} - Y : {e.Y}";
        }

        private void btnStartMouse_Click(object sender, EventArgs e)
        {
            if (btnStartMouse.Text == Const.BTN_START_TEXT)
            {
                Subscribe(Hook.GlobalEvents());
            }
            else
            {
                Unsubscribe();
                InitializeLayout();
            }

            btnStartMouse.Text = btnStartMouse.Text == Const.BTN_START_TEXT ? Const.BTN_STOP_TEXT : Const.BTN_START_TEXT;
        }

        private void btnStartImage_Click(object sender, EventArgs e)
        {
            if (btnStartImage.Text == Const.BTN_START_TEXT)
            {
                SubscribeImage(Hook.GlobalEvents());
                lblScreenSelect.Text = Const.LBL_SCREENSELECT_TEXT;
            }
            else
            {
                UnsubscribeImage();
                InitializeLayout();
            }

            btnStartImage.Text = btnStartImage.Text == Const.BTN_START_TEXT ? Const.BTN_STOP_TEXT : Const.BTN_START_TEXT;
        }

        private void btnScreenShot_Click(object sender, EventArgs e)
        {
            var bmp = Utils.GetScreenShot();
            ptbImage.Image = bmp;
        }

        private async void btnFindImage_Click(object sender, EventArgs e)
        {
            if (ptbImage?.Image == null)
            {
                lblScreenSelect.Text = Const.LBL_FINDSCREENSELECT_TEXT;
                return;
            }

            await Task.Run(async () =>
            {
                var source = new Bitmap(ptbImage.Image);
                ptbImage.Image = null;
                await Task.Delay(1000);
                var screenShot = Utils.GetScreenShot();
                var selectedShot = new Bitmap(source);
                var position = Utils.FindImagePosition(selectedShot, screenShot);
                Mouse.SetPosition(position.X, position.Y);
                ptbImage.Image = source;
            });
        }
    }
}