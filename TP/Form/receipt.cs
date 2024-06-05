using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.IO;
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = refundController.GetReceipt();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                receiptDataGridView.DataSource = dataTable;
            }
            else
            {
                receiptDataGridView.DataSource = null;
            }
        }

        private void ReceiptDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int receiptNo = Convert.ToInt32(receiptDataGridView.Rows[e.RowIndex].Cells["No"].Value);
                DataTable dataTable = refundController.GetReceiptDetails(receiptNo);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    receiptDetailGridView.DataSource = dataTable;
                }
            }
        }

        private void RefundButton_Click(object sender, EventArgs e)
        {
            if (receiptDetailGridView.DataSource == null || receiptDetailGridView.Rows.Count == 0)
            {
                MessageBox.Show("환불할 영수증을 선택하세요.");
                return;
            }

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