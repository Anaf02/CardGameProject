namespace CardGameProject.Forms
{
    partial class ConnectionScreen
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
            this.IP_txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmIP_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IP_txtbx
            // 
            this.IP_txtbx.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.IP_txtbx.Location = new System.Drawing.Point(377, 369);
            this.IP_txtbx.Name = "IP_txtbx";
            this.IP_txtbx.Size = new System.Drawing.Size(304, 26);
            this.IP_txtbx.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please type the IP address:";
            // 
            // confirmIP_btn
            // 
            this.confirmIP_btn.Location = new System.Drawing.Point(606, 400);
            this.confirmIP_btn.Name = "confirmIP_btn";
            this.confirmIP_btn.Size = new System.Drawing.Size(75, 38);
            this.confirmIP_btn.TabIndex = 2;
            this.confirmIP_btn.Text = "Confirm";
            this.confirmIP_btn.UseVisualStyleBackColor = true;
            // 
            // ConnectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardGameProject.Properties.Resources.lobby;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(778, 544);
            this.Controls.Add(this.confirmIP_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP_txtbx);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionScreen";
            this.Text = "Network Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP_txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmIP_btn;
    }
}