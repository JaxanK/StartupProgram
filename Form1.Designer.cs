namespace ThrawnStartupScreen
{
    partial class LoadingScreen
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
            CancelLoadButton = new Button();
            LoadingDots = new Label();
            SuspendLayout();
            // 
            // CancelLoadButton
            // 
            CancelLoadButton.BackColor = Color.Red;
            CancelLoadButton.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            CancelLoadButton.Location = new Point(12, 386);
            CancelLoadButton.Name = "CancelLoadButton";
            CancelLoadButton.Size = new Size(100, 52);
            CancelLoadButton.TabIndex = 0;
            CancelLoadButton.Text = "Cancel";
            CancelLoadButton.UseVisualStyleBackColor = false;
            CancelLoadButton.Click += CancelLoadButton_Click;
            // 
            // LoadingDots
            // 
            LoadingDots.AutoSize = true;
            LoadingDots.BackColor = Color.Transparent;
            LoadingDots.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point);
            LoadingDots.Location = new Point(354, 256);
            LoadingDots.Name = "LoadingDots";
            LoadingDots.Size = new Size(117, 128);
            LoadingDots.TabIndex = 1;
            LoadingDots.Text = "...";
            // 
            // LoadingScreen
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(LoadingDots);
            Controls.Add(CancelLoadButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingScreen";
            Text = "Thrawn Loading...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelLoadButton;
        private Label LoadingDots;
    }
}