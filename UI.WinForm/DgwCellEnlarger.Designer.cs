namespace UI.WinForm
{
    partial class DgwCellEnlarger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHover = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbHover
            // 
            this.tbHover.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHover.Enabled = false;
            this.tbHover.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbHover.HideSelection = false;
            this.tbHover.Location = new System.Drawing.Point(0, 0);
            this.tbHover.Margin = new System.Windows.Forms.Padding(0);
            this.tbHover.MaxLength = 255;
            this.tbHover.Multiline = true;
            this.tbHover.Name = "tbHover";
            this.tbHover.ReadOnly = true;
            this.tbHover.Size = new System.Drawing.Size(286, 249);
            this.tbHover.TabIndex = 54;
            // 
            // DgwCellEnlarger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(286, 249);
            this.ControlBox = false;
            this.Controls.Add(this.tbHover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DgwCellEnlarger";
            this.Opacity = 0.95D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.TextBox tbHover;
    }
}