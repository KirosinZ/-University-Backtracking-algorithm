
namespace STRIALG_BACKTRACK
{
    partial class SizePicker
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
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.NumericUpDown();
            this.DoneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InstructionLabel.Location = new System.Drawing.Point(12, 9);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(64, 25);
            this.InstructionLabel.TabIndex = 0;
            this.InstructionLabel.Text = "label1";
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(12, 37);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(272, 22);
            this.SizeBox.TabIndex = 1;
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(108, 65);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 2;
            this.DoneButton.Text = "button1";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // SizePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 95);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.InstructionLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(314, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(314, 140);
            this.Name = "SizePicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SizePicker";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.SizeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.NumericUpDown SizeBox;
        private System.Windows.Forms.Button DoneButton;
    }
}