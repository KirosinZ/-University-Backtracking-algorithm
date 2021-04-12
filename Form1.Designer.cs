
namespace STRIALG_BACKTRACK
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BoardStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateBoardStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.BackTrackStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.QueenBackTrackStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.RookBackTrackStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.BoardBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BoardStrip,
            this.BackTrackStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BoardStrip
            // 
            this.BoardStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateBoardStrip});
            this.BoardStrip.Name = "BoardStrip";
            this.BoardStrip.Size = new System.Drawing.Size(64, 24);
            this.BoardStrip.Text = "Доска";
            // 
            // CreateBoardStrip
            // 
            this.CreateBoardStrip.Image = ((System.Drawing.Image)(resources.GetObject("CreateBoardStrip.Image")));
            this.CreateBoardStrip.Name = "CreateBoardStrip";
            this.CreateBoardStrip.Size = new System.Drawing.Size(224, 26);
            this.CreateBoardStrip.Text = "Создать";
            // 
            // BackTrackStrip
            // 
            this.BackTrackStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QueenBackTrackStrip,
            this.RookBackTrackStrip});
            this.BackTrackStrip.Enabled = false;
            this.BackTrackStrip.Name = "BackTrackStrip";
            this.BackTrackStrip.Size = new System.Drawing.Size(77, 24);
            this.BackTrackStrip.Text = "Бектрек";
            // 
            // QueenBackTrackStrip
            // 
            this.QueenBackTrackStrip.Name = "QueenBackTrackStrip";
            this.QueenBackTrackStrip.Size = new System.Drawing.Size(224, 26);
            this.QueenBackTrackStrip.Text = "Ферзи";
            // 
            // RookBackTrackStrip
            // 
            this.RookBackTrackStrip.Name = "RookBackTrackStrip";
            this.RookBackTrackStrip.Size = new System.Drawing.Size(224, 26);
            this.RookBackTrackStrip.Text = "Ладьи";
            // 
            // BoardBox
            // 
            this.BoardBox.Location = new System.Drawing.Point(12, 31);
            this.BoardBox.Name = "BoardBox";
            this.BoardBox.Size = new System.Drawing.Size(600, 600);
            this.BoardBox.TabIndex = 1;
            this.BoardBox.TabStop = false;
            this.BoardBox.Text = "Доска";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 640);
            this.Controls.Add(this.BoardBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 685);
            this.MinimumSize = new System.Drawing.Size(640, 685);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Бектрекинг";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BoardStrip;
        private System.Windows.Forms.ToolStripMenuItem CreateBoardStrip;
        private System.Windows.Forms.ToolStripMenuItem BackTrackStrip;
        private System.Windows.Forms.ToolStripMenuItem QueenBackTrackStrip;
        private System.Windows.Forms.ToolStripMenuItem RookBackTrackStrip;
        private System.Windows.Forms.GroupBox BoardBox;
    }
}

