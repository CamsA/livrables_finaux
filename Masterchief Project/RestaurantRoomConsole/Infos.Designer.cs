namespace RestaurantRoomConsole
{
    partial class Infos
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbrNapkins = new System.Windows.Forms.Label();
            this.nbrTableclothes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(441, 159);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 209);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(441, 155);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serviettes disponibles :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nappes disponibles :";
            // 
            // nbrNapkins
            // 
            this.nbrNapkins.AutoSize = true;
            this.nbrNapkins.Location = new System.Drawing.Point(142, 18);
            this.nbrNapkins.Name = "nbrNapkins";
            this.nbrNapkins.Size = new System.Drawing.Size(13, 13);
            this.nbrNapkins.TabIndex = 4;
            this.nbrNapkins.Text = "0";
            // 
            // nbrTableclothes
            // 
            this.nbrTableclothes.AutoSize = true;
            this.nbrTableclothes.Location = new System.Drawing.Point(338, 18);
            this.nbrTableclothes.Name = "nbrTableclothes";
            this.nbrTableclothes.Size = new System.Drawing.Size(13, 13);
            this.nbrTableclothes.TabIndex = 5;
            this.nbrTableclothes.Text = "0";
            // 
            // Infos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 373);
            this.Controls.Add(this.nbrTableclothes);
            this.Controls.Add(this.nbrNapkins);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Infos";
            this.Text = "Infos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Infos_FormClosing);
            this.Load += new System.EventHandler(this.Infos_Load);
            this.TextChanged += new System.EventHandler(this.richTextBox1_textChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nbrNapkins;
        private System.Windows.Forms.Label nbrTableclothes;
    }
}