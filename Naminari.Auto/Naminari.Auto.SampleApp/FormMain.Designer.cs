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
            btnStart = new Button();
            btnClickMe = new Button();
            lblPosition = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 305);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(116, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Auto Click";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnClickMe
            // 
            btnClickMe.Location = new Point(425, 305);
            btnClickMe.Name = "btnClickMe";
            btnClickMe.RightToLeft = RightToLeft.No;
            btnClickMe.Size = new Size(75, 23);
            btnClickMe.TabIndex = 1;
            btnClickMe.Text = "Click Me!";
            btnClickMe.UseVisualStyleBackColor = true;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(12, 9);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(60, 15);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "X : ? - Y : ?";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 340);
            Controls.Add(lblPosition);
            Controls.Add(btnClickMe);
            Controls.Add(btnStart);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sample";
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnClickMe;
        private Label lblPosition;
    }
}