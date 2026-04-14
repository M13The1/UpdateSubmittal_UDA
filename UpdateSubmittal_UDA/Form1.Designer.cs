namespace UpdateSubmittal_UDA
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.dtSubmittalDate = new System.Windows.Forms.DateTimePicker();
            this.txtSubmittalNumber = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Submittal Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Submittal Transmittal #";
            // 
            // lbl_Type
            // 
            this.lbl_Type.AutoSize = true;
            this.lbl_Type.Location = new System.Drawing.Point(12, 9);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(130, 13);
            this.lbl_Type.TabIndex = 11;
            this.lbl_Type.Text = "Submittal type : OFA / IFC";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 88);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(269, 23);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "Run : Update UDA";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dtSubmittalDate
            // 
            this.dtSubmittalDate.Location = new System.Drawing.Point(147, 57);
            this.dtSubmittalDate.Name = "dtSubmittalDate";
            this.dtSubmittalDate.Size = new System.Drawing.Size(134, 20);
            this.dtSubmittalDate.TabIndex = 9;
            // 
            // txtSubmittalNumber
            // 
            this.txtSubmittalNumber.Location = new System.Drawing.Point(147, 31);
            this.txtSubmittalNumber.Name = "txtSubmittalNumber";
            this.txtSubmittalNumber.Size = new System.Drawing.Size(100, 20);
            this.txtSubmittalNumber.TabIndex = 8;
            this.txtSubmittalNumber.Text = "00";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(147, 5);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 20);
            this.txtType.TabIndex = 7;
            this.txtType.Text = "IFC";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 136);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dtSubmittalDate);
            this.Controls.Add(this.txtSubmittalNumber);
            this.Controls.Add(this.txtType);
            this.Name = "Form1";
            this.Text = "Update Submittal Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DateTimePicker dtSubmittalDate;
        private System.Windows.Forms.TextBox txtSubmittalNumber;
        private System.Windows.Forms.TextBox txtType;
    }
}

