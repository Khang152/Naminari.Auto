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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            lblPosition = new Label();
            lblTypeButton = new Label();
            lblTypeClick = new Label();
            btnStartMouse = new Button();
            gbHook = new GroupBox();
            grAction = new GroupBox();
            chkKeepList = new CheckBox();
            grvAction = new DataGridView();
            groupBox1 = new GroupBox();
            btnFindImage = new Button();
            btnScreenShot = new Button();
            lblScreenSelect = new Label();
            btnStartImage = new Button();
            ptbImage = new PictureBox();
            gbHook.SuspendLayout();
            grAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grvAction).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbImage).BeginInit();
            SuspendLayout();
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(91, 29);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(112, 15);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Position : X : ? - Y : ?";
            // 
            // lblTypeButton
            // 
            lblTypeButton.AutoSize = true;
            lblTypeButton.Location = new Point(91, 48);
            lblTypeButton.Name = "lblTypeButton";
            lblTypeButton.Size = new Size(137, 15);
            lblTypeButton.TabIndex = 3;
            lblTypeButton.Text = "Type Button : Try to Click";
            // 
            // lblTypeClick
            // 
            lblTypeClick.AutoSize = true;
            lblTypeClick.Location = new Point(91, 69);
            lblTypeClick.Name = "lblTypeClick";
            lblTypeClick.Size = new Size(211, 15);
            lblTypeClick.TabIndex = 4;
            lblTypeClick.Text = "Type Click : Try to Click or Double Click";
            // 
            // btnStartMouse
            // 
            btnStartMouse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStartMouse.Location = new Point(296, 202);
            btnStartMouse.Name = "btnStartMouse";
            btnStartMouse.Size = new Size(75, 23);
            btnStartMouse.TabIndex = 5;
            btnStartMouse.Text = "Start";
            btnStartMouse.UseVisualStyleBackColor = true;
            btnStartMouse.Click += btnStartMouse_Click;
            // 
            // gbHook
            // 
            gbHook.Controls.Add(lblTypeButton);
            gbHook.Controls.Add(lblPosition);
            gbHook.Controls.Add(lblTypeClick);
            gbHook.Location = new Point(12, 12);
            gbHook.Name = "gbHook";
            gbHook.Size = new Size(389, 104);
            gbHook.TabIndex = 6;
            gbHook.TabStop = false;
            gbHook.Text = "Mouse Hook";
            // 
            // grAction
            // 
            grAction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grAction.Controls.Add(chkKeepList);
            grAction.Controls.Add(grvAction);
            grAction.Controls.Add(btnStartMouse);
            grAction.Location = new Point(13, 140);
            grAction.Name = "grAction";
            grAction.Size = new Size(388, 239);
            grAction.TabIndex = 7;
            grAction.TabStop = false;
            grAction.Text = "Mouse Action";
            // 
            // chkKeepList
            // 
            chkKeepList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chkKeepList.AutoSize = true;
            chkKeepList.Location = new Point(20, 204);
            chkKeepList.Name = "chkKeepList";
            chkKeepList.Size = new Size(70, 19);
            chkKeepList.TabIndex = 6;
            chkKeepList.Text = "Keep list";
            chkKeepList.UseVisualStyleBackColor = true;
            // 
            // grvAction
            // 
            grvAction.AllowUserToAddRows = false;
            grvAction.AllowUserToDeleteRows = false;
            grvAction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grvAction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grvAction.Location = new Point(20, 22);
            grvAction.Name = "grvAction";
            grvAction.ReadOnly = true;
            grvAction.RowTemplate.Height = 25;
            grvAction.Size = new Size(351, 168);
            grvAction.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnFindImage);
            groupBox1.Controls.Add(btnScreenShot);
            groupBox1.Controls.Add(lblScreenSelect);
            groupBox1.Controls.Add(btnStartImage);
            groupBox1.Controls.Add(ptbImage);
            groupBox1.Location = new Point(419, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(431, 364);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Image";
            // 
            // btnFindImage
            // 
            btnFindImage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFindImage.Location = new Point(348, 58);
            btnFindImage.Name = "btnFindImage";
            btnFindImage.Size = new Size(75, 23);
            btnFindImage.TabIndex = 9;
            btnFindImage.Text = "Find";
            btnFindImage.UseVisualStyleBackColor = true;
            btnFindImage.Click += btnFindImage_Click;
            // 
            // btnScreenShot
            // 
            btnScreenShot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScreenShot.Location = new Point(348, 26);
            btnScreenShot.Name = "btnScreenShot";
            btnScreenShot.Size = new Size(75, 23);
            btnScreenShot.TabIndex = 8;
            btnScreenShot.Text = "ScreenShot";
            btnScreenShot.UseVisualStyleBackColor = true;
            btnScreenShot.Click += btnScreenShot_Click;
            // 
            // lblScreenSelect
            // 
            lblScreenSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblScreenSelect.AutoSize = true;
            lblScreenSelect.Location = new Point(15, 329);
            lblScreenSelect.Name = "lblScreenSelect";
            lblScreenSelect.Size = new Size(244, 15);
            lblScreenSelect.TabIndex = 7;
            lblScreenSelect.Text = "Select an area on the screen using the mouse";
            // 
            // btnStartImage
            // 
            btnStartImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStartImage.Location = new Point(264, 325);
            btnStartImage.Name = "btnStartImage";
            btnStartImage.Size = new Size(75, 23);
            btnStartImage.TabIndex = 6;
            btnStartImage.Text = "Start";
            btnStartImage.UseVisualStyleBackColor = true;
            btnStartImage.Click += btnStartImage_Click;
            // 
            // ptbImage
            // 
            ptbImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ptbImage.BorderStyle = BorderStyle.FixedSingle;
            ptbImage.Location = new Point(18, 26);
            ptbImage.Name = "ptbImage";
            ptbImage.Size = new Size(321, 289);
            ptbImage.TabIndex = 0;
            ptbImage.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 391);
            Controls.Add(groupBox1);
            Controls.Add(grAction);
            Controls.Add(gbHook);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Naminari.Auto.Sample";
            TopMost = true;
            Load += FormMain_Load;
            gbHook.ResumeLayout(false);
            gbHook.PerformLayout();
            grAction.ResumeLayout(false);
            grAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grvAction).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblPosition;
        private Label lblTypeButton;
        private Label lblTypeClick;
        private Button btnStartMouse;
        private GroupBox gbHook;
        private GroupBox grAction;
        private DataGridView grvAction;
        private GroupBox groupBox1;
        private Button btnStartImage;
        private PictureBox ptbImage;
        private Label lblScreenSelect;
        private Button btnScreenShot;
        private Button btnFindImage;
        private CheckBox chkKeepList;
    }
}