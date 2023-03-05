namespace Naminari.Auto.SampleApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPosition = new Label();
            lblTypeButton = new Label();
            lblTypeClick = new Label();
            btnStart = new Button();
            gbHook = new GroupBox();
            grAction = new GroupBox();
            grvAction = new DataGridView();
            gbHook.SuspendLayout();
            grAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grvAction).BeginInit();
            SuspendLayout();
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(63, 22);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(112, 15);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Position : X : ? - Y : ?";
            // 
            // lblTypeButton
            // 
            lblTypeButton.AutoSize = true;
            lblTypeButton.Location = new Point(43, 46);
            lblTypeButton.Name = "lblTypeButton";
            lblTypeButton.Size = new Size(137, 15);
            lblTypeButton.TabIndex = 3;
            lblTypeButton.Text = "Type Button : Try to Click";
            // 
            // lblTypeClick
            // 
            lblTypeClick.AutoSize = true;
            lblTypeClick.Location = new Point(53, 72);
            lblTypeClick.Name = "lblTypeClick";
            lblTypeClick.Size = new Size(211, 15);
            lblTypeClick.TabIndex = 4;
            lblTypeClick.Text = "Type Click : Try to Click or Double Click";
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.Location = new Point(283, 355);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // gbHook
            // 
            gbHook.Controls.Add(lblTypeButton);
            gbHook.Controls.Add(lblPosition);
            gbHook.Controls.Add(lblTypeClick);
            gbHook.Location = new Point(12, 12);
            gbHook.Name = "gbHook";
            gbHook.Size = new Size(346, 104);
            gbHook.TabIndex = 6;
            gbHook.TabStop = false;
            gbHook.Text = "Hook";
            // 
            // grAction
            // 
            grAction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grAction.Controls.Add(grvAction);
            grAction.Location = new Point(13, 140);
            grAction.Name = "grAction";
            grAction.Size = new Size(345, 209);
            grAction.TabIndex = 7;
            grAction.TabStop = false;
            grAction.Text = "Action";
            // 
            // grvAction
            // 
            grvAction.AllowUserToAddRows = false;
            grvAction.AllowUserToDeleteRows = false;
            grvAction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grvAction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grvAction.Location = new Point(20, 22);
            grvAction.Name = "grvAction";
            grvAction.ReadOnly = true;
            grvAction.RowTemplate.Height = 25;
            grvAction.Size = new Size(308, 168);
            grvAction.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 391);
            Controls.Add(grAction);
            Controls.Add(gbHook);
            Controls.Add(btnStart);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Naminari.Auto.Sample";
            TopMost = true;
            Load += FormMain_Load;
            gbHook.ResumeLayout(false);
            gbHook.PerformLayout();
            grAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grvAction).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblPosition;
        private Label lblTypeButton;
        private Label lblTypeClick;
        private Button btnStart;
        private GroupBox gbHook;
        private GroupBox grAction;
        private DataGridView grvAction;
    }
}