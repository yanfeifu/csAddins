namespace csAddins
{
    partial class NoteCoordForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoHoriz = new System.Windows.Forms.RadioButton();
            this.rdoVert = new System.Windows.Forms.RadioButton();
            this.rdoXY = new System.Windows.Forms.RadioButton();
            this.rdoEN = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoVert);
            this.groupBox1.Controls.Add(this.rdoHoriz);
            this.groupBox1.Location = new System.Drawing.Point(36, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Direction";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoXY);
            this.groupBox2.Controls.Add(this.rdoEN);
            this.groupBox2.Location = new System.Drawing.Point(36, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 93);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Label";
            // 
            // rdoHoriz
            // 
            this.rdoHoriz.AutoSize = true;
            this.rdoHoriz.Checked = true;
            this.rdoHoriz.Location = new System.Drawing.Point(21, 42);
            this.rdoHoriz.Name = "rdoHoriz";
            this.rdoHoriz.Size = new System.Drawing.Size(83, 16);
            this.rdoHoriz.TabIndex = 0;
            this.rdoHoriz.TabStop = true;
            this.rdoHoriz.Text = "Horizontal";
            this.rdoHoriz.UseVisualStyleBackColor = true;
            // 
            // rdoVert
            // 
            this.rdoVert.AutoSize = true;
            this.rdoVert.Location = new System.Drawing.Point(125, 42);
            this.rdoVert.Name = "rdoVert";
            this.rdoVert.Size = new System.Drawing.Size(71, 16);
            this.rdoVert.TabIndex = 1;
            this.rdoVert.Text = "Vertical";
            this.rdoVert.UseVisualStyleBackColor = true;
            // 
            // rdoXY
            // 
            this.rdoXY.AutoSize = true;
            this.rdoXY.Location = new System.Drawing.Point(137, 43);
            this.rdoXY.Name = "rdoXY";
            this.rdoXY.Size = new System.Drawing.Size(41, 16);
            this.rdoXY.TabIndex = 3;
            this.rdoXY.Text = "XY=";
            this.rdoXY.UseVisualStyleBackColor = true;
            // 
            // rdoEN
            // 
            this.rdoEN.AutoSize = true;
            this.rdoEN.Checked = true;
            this.rdoEN.Location = new System.Drawing.Point(33, 43);
            this.rdoEN.Name = "rdoEN";
            this.rdoEN.Size = new System.Drawing.Size(41, 16);
            this.rdoEN.TabIndex = 2;
            this.rdoEN.TabStop = true;
            this.rdoEN.Text = "EN=";
            this.rdoEN.UseVisualStyleBackColor = true;
            // 
            // NoteCoordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NoteCoordForm";
            this.Text = "NoteCoordForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rdoVert;
        public System.Windows.Forms.RadioButton rdoHoriz;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton rdoXY;
        public System.Windows.Forms.RadioButton rdoEN;
    }
}