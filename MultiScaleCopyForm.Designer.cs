namespace csAddins
{
    partial class MultiScaleCopyForm
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
            this.btnDefault = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYOffset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXOffset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtZOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(77, 273);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(140, 23);
            this.btnDefault.TabIndex = 0;
            this.btnDefault.Text = "Load Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scale";
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(141, 38);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(96, 21);
            this.txtScale.TabIndex = 2;
            this.txtScale.Tag = "0.95";
            this.txtScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScale_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y Offset";
            // 
            // txtYOffset
            // 
            this.txtYOffset.Location = new System.Drawing.Point(141, 118);
            this.txtYOffset.Name = "txtYOffset";
            this.txtYOffset.Size = new System.Drawing.Size(96, 21);
            this.txtYOffset.TabIndex = 4;
            this.txtYOffset.Tag = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "X Offset";
            // 
            // txtXOffset
            // 
            this.txtXOffset.Location = new System.Drawing.Point(141, 78);
            this.txtXOffset.Name = "txtXOffset";
            this.txtXOffset.Size = new System.Drawing.Size(96, 21);
            this.txtXOffset.TabIndex = 6;
            this.txtXOffset.Tag = "4";
            this.txtXOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXOffset_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Z Offset";
            // 
            // txtZOffset
            // 
            this.txtZOffset.Location = new System.Drawing.Point(141, 161);
            this.txtZOffset.Name = "txtZOffset";
            this.txtZOffset.Size = new System.Drawing.Size(96, 21);
            this.txtZOffset.TabIndex = 8;
            this.txtZOffset.Tag = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Copies";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(141, 205);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(96, 21);
            this.txtCopies.TabIndex = 10;
            this.txtCopies.Tag = "10";
            this.txtCopies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCopies_KeyPress);
            // 
            // MultiScaleCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 313);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtZOffset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXOffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYOffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.btnDefault);
            this.Name = "MultiScaleCopyForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MultiScaleCopyForm_FormClosed);
            this.Load += new System.EventHandler(this.MultiScaleCopyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtYOffset;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtXOffset;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtZOffset;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCopies;
    }
}