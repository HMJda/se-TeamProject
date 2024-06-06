using System;
using System.Data;
using System.Windows.Forms;
using TP.control;

namespace TP
{
    public partial class showReceipt : Form
    {
        private Label label4;
        private DataGridView receiptDetailGridView;

        public showReceipt() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.receiptDetailGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // receiptDetailGridView
            // 
            this.receiptDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDetailGridView.Location = new System.Drawing.Point(33, 125);
            this.receiptDetailGridView.Name = "receiptDetailGridView";
            this.receiptDetailGridView.ReadOnly = true;
            this.receiptDetailGridView.RowHeadersVisible = false;
            this.receiptDetailGridView.RowHeadersWidth = 51;
            this.receiptDetailGridView.RowTemplate.Height = 23;
            this.receiptDetailGridView.Size = new System.Drawing.Size(568, 437);
            this.receiptDetailGridView.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(134, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 64);
            this.label4.TabIndex = 3;
            this.label4.Text = "영수증 출력";
            // 
            // NewForm
            // 
            this.ClientSize = new System.Drawing.Size(642, 589);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.receiptDetailGridView);
            this.Name = "NewForm";
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void ShowReceiptDetails(DataTable receiptDetails)
        {
            if (receiptDetails != null && receiptDetails.Rows.Count > 0)
            {
                receiptDetailGridView.DataSource = receiptDetails;
            }
        }
    }
}