using System;
using System.Data;
using System.Windows.Forms;
using TP.control;

namespace TP
{
    public partial class showReceipt : Form
    {
        private DataGridView receiptDetailGridView;
        private Label label1;

        public showReceipt()
        {
            InitializeComponent();
        }

        // 영수증 상세 내역 데이터를 표시할 메소드
        public void ShowReceiptDetails(DataTable receiptDetails)
        {
            if (receiptDetails != null && receiptDetails.Rows.Count > 0)
            {
                receiptDetailGridView.DataSource = receiptDetails;
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.receiptDetailGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(89, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "영수증 출력";
            // 
            // receiptDetailGridView
            // 
            this.receiptDetailGridView.AllowUserToAddRows = false;
            this.receiptDetailGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.receiptDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDetailGridView.Location = new System.Drawing.Point(36, 123);
            this.receiptDetailGridView.Name = "receiptDetailGridView";
            this.receiptDetailGridView.ReadOnly = true;
            this.receiptDetailGridView.RowHeadersVisible = false;
            this.receiptDetailGridView.RowHeadersWidth = 51;
            this.receiptDetailGridView.RowTemplate.Height = 23;
            this.receiptDetailGridView.Size = new System.Drawing.Size(539, 330);
            this.receiptDetailGridView.TabIndex = 2;
            // 
            // showReceipt
            // 
            this.ClientSize = new System.Drawing.Size(630, 486);
            this.Controls.Add(this.receiptDetailGridView);
            this.Controls.Add(this.label1);
            this.Name = "showReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}