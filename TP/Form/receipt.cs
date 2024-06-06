using System;
using System.Data;
using System.Windows.Forms;
using TP.control;

namespace TP
{

    public partial class receipt : Form
    {
        private RefundController refundController;

        public receipt(string dbServerInfo)
        {
            InitializeComponent();
            refundController = new RefundController(dbServerInfo, dateTime, receiptNumberTextBox);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = refundController.GetReceipt();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                ReceiptDataGridView.DataSource = dataTable;
            }
            else
            {
            }
        }

        private void RefundButton_Click_1(object sender, EventArgs e)
        {
            if (receiptDetailGridView.DataSource == null)
            {
                if (receiptDetailGridView.DataSource == null || receiptDetailGridView.Rows.Count == 0)
                {
                    MessageBox.Show("환불할 영수증을 선택하세요.");
                    return;
                }

                else
                { 

                    DialogResult result = MessageBox.Show("환불 처리를 하시겠습니까?", "환불", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int receiptNo = Convert.ToInt32(receiptDetailGridView.Rows[0].Cells["ReceiptNo"].Value);
                        bool isRefunded = refundController.ProcessRefund(receiptNo);


                        if (isRefunded)
                        {
                            MessageBox.Show("환불 처리가 완료되었습니다.");
                        }
                        else
                        {
                            this.Close();
                        }
                    
                    }
                }
            }
        }

        private void ReceiptDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int receiptNo = Convert.ToInt32(ReceiptDataGridView.Rows[e.RowIndex].Cells["No"].Value);
                DataTable dataTable = refundController.GetReceiptDetails(receiptNo);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    receiptDetailGridView.DataSource = dataTable;
                }
            }
        }
    }
}