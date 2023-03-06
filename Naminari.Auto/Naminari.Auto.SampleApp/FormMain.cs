using Gma.System.MouseKeyHook;
using Naminari.Auto.SampleApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using Naminari.Auto.Libraries;
using System.Diagnostics;
using System.Windows.Automation;

namespace Naminari.Auto.SampleApp
{
    public partial class FormMain : Form
    {
        private IKeyboardMouseEvents? m_Events;
        private static System.Windows.Forms.Timer? timer;
        private List<ActionItem> actionItems = new List<ActionItem>();
        private Keyboard? keyboard;

        public FormMain()
        {
            InitializeComponent();
            keyboard = new Keyboard();
        }

        private void InitializeLayout()
        {
            lblPosition.Text = Const.LBL_POSITION_TEXT;
            lblTypeButton.Text = Const.LBL_TYPEBUTTON_TEXT;
            lblTypeClick.Text = Const.LBL_TYPECLICK_TEXT;

            actionItems.Clear();
            grvAction.DataSource = actionItems;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeLayout();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            //timer.Enabled = true;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
        }

        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.MouseClick += OnMouseClick;
            m_Events.MouseDoubleClick += OnMouseDoubleClick;
            m_Events.MouseMove += HookManager_MouseMove;
        }

        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.MouseClick -= OnMouseClick;
            m_Events.MouseDoubleClick -= OnMouseDoubleClick;
            m_Events.MouseMove -= HookManager_MouseMove;
            m_Events.Dispose();
        }

        private void OnMouseClick(object? sender, MouseEventArgs e)
        {
            lblTypeButton.Text = $"Type Button : {e.Button.ToString()}";
            lblTypeClick.Text = $"Type Click : Normal Click";

            var position = Mouse.GetPosition();
            actionItems.Add(new ActionItem() { X = position.X, Y = position.Y, Color = position.GetPixelColor().Name });

            var bindingList = new BindingList<ActionItem>(actionItems);
            var source = new BindingSource(bindingList, null);
            grvAction.DataSource = source;
        }

        private void OnMouseDoubleClick(object? sender, MouseEventArgs e)
        {
            lblTypeButton.Text = $"Type Button : {e.Button.ToString()}";
            lblTypeClick.Text = $"Type Click : Double Click";
        }

        private void HookManager_MouseMove(object? sender, MouseEventArgs e)
        {
            lblPosition.Text = $"Position : X : {e.X} - Y : {e.Y}";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                Subscribe(Hook.GlobalEvents());
            }
            else
            {
                Unsubscribe();
                InitializeLayout();
            }

            btnStart.Text = btnStart.Text == "Start" ? "Stop" : "Start";
        }
    }
}