namespace CardGameProject.Forms
{
    partial class BetDialog
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
            this.trackBarBet = new System.Windows.Forms.TrackBar();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numericUpDownBet = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBet)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarBet
            // 
            this.trackBarBet.Location = new System.Drawing.Point(56, 133);
            this.trackBarBet.Maximum = 5000;
            this.trackBarBet.Minimum = 1;
            this.trackBarBet.Name = "trackBarBet";
            this.trackBarBet.Size = new System.Drawing.Size(293, 69);
            this.trackBarBet.TabIndex = 0;
            this.trackBarBet.TickFrequency = 50;
            this.trackBarBet.Value = 1;
            this.trackBarBet.Scroll += new System.EventHandler(this.trackBarBet_Scroll);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(77, 231);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(101, 44);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numericUpDownBet
            // 
            this.numericUpDownBet.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBet.Location = new System.Drawing.Point(56, 67);
            this.numericUpDownBet.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownBet.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBet.Name = "numericUpDownBet";
            this.numericUpDownBet.Size = new System.Drawing.Size(293, 26);
            this.numericUpDownBet.TabIndex = 3;
            this.numericUpDownBet.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBet.ValueChanged += new System.EventHandler(this.numericUpDownBet_ValueChanged);
            // 
            // BetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 311);
            this.Controls.Add(this.numericUpDownBet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.trackBarBet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BetDialog";
            this.Text = "BetDialog";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarBet;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownBet;
    }
}