namespace TP
{
    partial class receipt
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
            this.영수증조회 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.검색 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.영수증번호 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.환불등록 = new System.Windows.Forms.Button();
            this.영수증출력 = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.영수증조회)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // 영수증조회
            // 
            this.영수증조회.AllowUserToOrderColumns = true;
            this.영수증조회.AllowUserToResizeRows = false;
            this.영수증조회.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.영수증조회.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.영수증조회.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.영수증조회.Location = new System.Drawing.Point(474, 89);
            this.영수증조회.Name = "영수증조회";
            this.영수증조회.RowHeadersVisible = false;
            this.영수증조회.RowTemplate.Height = 23;
            this.영수증조회.Size = new System.Drawing.Size(393, 471);
            this.영수증조회.TabIndex = 0;
            this.영수증조회.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.영수증조회_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "거래시간";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "거래 형태";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "금 액";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(474, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(169, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // 검색
            // 
            this.검색.Location = new System.Drawing.Point(827, 42);
            this.검색.Name = "검색";
            this.검색.Size = new System.Drawing.Size(40, 21);
            this.검색.TabIndex = 3;
            this.검색.Text = "검색";
            this.검색.UseVisualStyleBackColor = true;
            this.검색.Click += new System.EventHandler(this.검색_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(737, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 21);
            this.textBox2.TabIndex = 4;
            // 
            // 영수증번호
            // 
            this.영수증번호.AutoSize = true;
            this.영수증번호.Font = new System.Drawing.Font("굴림", 10F);
            this.영수증번호.Location = new System.Drawing.Point(649, 47);
            this.영수증번호.Name = "영수증번호";
            this.영수증번호.Size = new System.Drawing.Size(82, 14);
            this.영수증번호.TabIndex = 7;
            this.영수증번호.Text = "영수증 번호";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView2.Location = new System.Drawing.Point(34, 89);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(354, 417);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(30, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "영수증 조회";
            // 
            // 환불등록
            // 
            this.환불등록.Font = new System.Drawing.Font("굴림", 12F);
            this.환불등록.Location = new System.Drawing.Point(34, 512);
            this.환불등록.Name = "환불등록";
            this.환불등록.Size = new System.Drawing.Size(96, 48);
            this.환불등록.TabIndex = 10;
            this.환불등록.Text = "환불";
            this.환불등록.UseVisualStyleBackColor = true;
            this.환불등록.Click += new System.EventHandler(this.환불_Click);
            // 
            // 영수증출력
            // 
            this.영수증출력.Font = new System.Drawing.Font("굴림", 12F);
            this.영수증출력.Location = new System.Drawing.Point(271, 512);
            this.영수증출력.Name = "영수증출력";
            this.영수증출력.Size = new System.Drawing.Size(117, 48);
            this.영수증출력.TabIndex = 11;
            this.영수증출력.Text = "영수증 출력";
            this.영수증출력.UseVisualStyleBackColor = true;
            this.영수증출력.Click += new System.EventHandler(this.영수증출력_Click);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "상품명";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "단가";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "수량";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "가격";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // receipt
            // 
            this.ClientSize = new System.Drawing.Size(936, 583);
            this.Controls.Add(this.영수증출력);
            this.Controls.Add(this.환불등록);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.영수증번호);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.검색);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.영수증조회);
            this.Name = "receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "영수증";
            this.Load += new System.EventHandler(this.receipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.영수증조회)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView 영수증조회;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button 검색;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label 영수증번호;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button 환불등록;
        private System.Windows.Forms.Button 영수증출력;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}