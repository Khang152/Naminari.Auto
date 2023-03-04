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
            SuspendLayout();
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(37, 18);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(112, 15);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Position : X : ? - Y : ?";
            // 
            // lblTypeButton
            // 
            lblTypeButton.AutoSize = true;
            lblTypeButton.Location = new Point(17, 42);
            lblTypeButton.Name = "lblTypeButton";
            lblTypeButton.Size = new Size(82, 15);
            lblTypeButton.TabIndex = 3;
            lblTypeButton.Text = "Type Button :  ";
            // 
            // lblTypeClick
            // 
            lblTypeClick.AutoSize = true;
            lblTypeClick.Location = new Point(27, 68);
            lblTypeClick.Name = "lblTypeClick";
            lblTypeClick.Size = new Size(72, 15);
            lblTypeClick.TabIndex = 4;
            lblTypeClick.Text = "Type Click :  ";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 399);
            Controls.Add(lblTypeClick);
            Controls.Add(lblTypeButton);
            Controls.Add(lblPosition);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sample";
            TopMost = true;
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPosition;
        private Label lblTypeButton;
        private Label lblTypeClick;
    }
}