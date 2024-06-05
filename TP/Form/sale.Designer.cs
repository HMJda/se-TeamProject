namespace TP
{
    partial class sale
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
            this.productCordTextBox = new System.Windows.Forms.TextBox();
            this.totalAmountLabel = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // productCordTextBox
            // 
            this.productCordTextBox.Font = new System.Drawing.Font("굴림", 12F);
            this.productCordTextBox.Location = new System.Drawing.Point(53, 275);
            this.productCordTextBox.Name = "productCordTextBox";
            this.productCordTextBox.Size = new System.Drawing.Size(311, 26);
            this.productCordTextBox.TabIndex = 0;
            // 
            // totalAmountLabel
            // 
            this.totalAmountLabel.Font = new System.Drawing.Font("굴림", 15F);
            this.totalAmountLabel.Location = new System.Drawing.Point(416, 104);
            this.totalAmountLabel.Name = "totalAmountLabel";
            this.totalAmountLabel.ReadOnly = true;
            this.totalAmountLabel.Size = new System.Drawing.Size(144, 30);
            this.totalAmountLabel.TabIndex = 1;
            this.totalAmountLabel.Text = "받을 금액";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("굴림", 12F);
            this.textBox4.Location = new System.Drawing.Point(416, 159);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(144, 26);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "결제한 금액";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("굴림", 12F);
            this.textBox5.Location = new System.Drawing.Point(416, 213);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(144, 26);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "거스름돈";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(53, 24);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(337, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "NO           상품명            수량           단가           금액";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(416, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(191, 65);
            this.button6.TabIndex = 7;
            this.button6.Text = "결제";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.pay_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(49, 381);
            this.button10.Name = "button10";
            this.button10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button10.Size = new System.Drawing.Size(182, 42);
            this.button10.TabIndex = 11;
            this.button10.Text = "츄파츕스 12g\r\n250\r\n";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.chupachups_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(237, 381);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(182, 42);
            this.button11.TabIndex = 12;
            this.button11.Text = "종이컵낱개\r\n50\r\n";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.paperCup_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(425, 381);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(182, 42);
            this.button12.TabIndex = 13;
            this.button12.Text = "컵얼음180g\r\n600";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.cupOfIce_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(49, 333);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(182, 42);
            this.button13.TabIndex = 14;
            this.button13.Text = "봉투(소)\r\n50\r\n";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.plasticBackSmall_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(237, 333);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(182, 42);
            this.button14.TabIndex = 15;
            this.button14.Text = "봉투(중)\r\n100";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.plasticBackMedium_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(370, 275);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 29);
            this.button5.TabIndex = 18;
            this.button5.Text = "입력";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.cordButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(53, 43);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(337, 210);
            this.textBox2.TabIndex = 19;
            // 
            // sale
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(638, 451);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.totalAmountLabel);
            this.Controls.Add(this.productCordTextBox);
            this.Controls.Add(this.textBox2);
            this.Name = "sale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "판매";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox productCordTextBox;
        private System.Windows.Forms.TextBox totalAmountLabel;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
    }
}