namespace lab1
{
    partial class changeForm
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
            this.cardNumber_txtBox = new System.Windows.Forms.TextBox();
            this.name_txtBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.agreeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.cardNumber = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cardNumber_txtBox
            // 
            this.cardNumber_txtBox.Location = new System.Drawing.Point(33, 76);
            this.cardNumber_txtBox.Name = "cardNumber_txtBox";
            this.cardNumber_txtBox.Size = new System.Drawing.Size(180, 31);
            this.cardNumber_txtBox.TabIndex = 0;
            this.cardNumber_txtBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // name_txtBox
            // 
            this.name_txtBox.Location = new System.Drawing.Point(571, 76);
            this.name_txtBox.Name = "name_txtBox";
            this.name_txtBox.Size = new System.Drawing.Size(180, 31);
            this.name_txtBox.TabIndex = 1;
            this.name_txtBox.TextChanged += new System.EventHandler(this.name_txtBox_TextChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(278, 76);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(230, 31);
            this.dateTimePicker.TabIndex = 2;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // agreeButton
            // 
            this.agreeButton.Location = new System.Drawing.Point(66, 301);
            this.agreeButton.Name = "agreeButton";
            this.agreeButton.Size = new System.Drawing.Size(230, 100);
            this.agreeButton.TabIndex = 3;
            this.agreeButton.Text = "принять";
            this.agreeButton.UseVisualStyleBackColor = true;
            this.agreeButton.Click += new System.EventHandler(this.agreeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(460, 301);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(230, 100);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "отменить";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // cardNumber
            // 
            this.cardNumber.AutoSize = true;
            this.cardNumber.Location = new System.Drawing.Point(46, 124);
            this.cardNumber.Name = "cardNumber";
            this.cardNumber.Size = new System.Drawing.Size(144, 25);
            this.cardNumber.TabIndex = 5;
            this.cardNumber.Text = "Номер карты";
            this.cardNumber.Click += new System.EventHandler(this.label1_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(594, 124);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(130, 25);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Ввод имени";
            this.nameLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // changeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(782, 479);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.cardNumber);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.agreeButton);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.name_txtBox);
            this.Controls.Add(this.cardNumber_txtBox);
            this.Name = "changeForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.changeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.changeForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cardNumber_txtBox;
        private System.Windows.Forms.TextBox name_txtBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button agreeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label cardNumber;
        private System.Windows.Forms.Label nameLabel;
    }
}