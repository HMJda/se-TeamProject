using System;
using System.Data;
using System.Windows.Forms;
using TP.control;

namespace TP
{

    public partial class receipt : Form
    {
        private ReceiptControl receiptControl;
        private RefundController refundController;

        public receipt()
        {
            InitializeComponent();
            receiptControl = new ReceiptControl();
            refundController = new RefundController(dateTime, receiptNumberTextBox);
            ReceiptDataGridView.AllowUserToAddRows = false; // 빈 레코드 표시x
            receiptDetailGridView.AllowUserToAddRows = false; // 빈 레코드 표시x
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTime.Value.Date; // 선택된 날짜를 가져옴
            ReceiptDataGridView.AllowUserToAddRows = false; // 빈 레코드 표시x

            if (string.IsNullOrEmpty(receiptNumberTextBox.Text.Trim()))
            {
                // 영수증 번호가 없는 경우 해당 날짜에 있는 모든 정보를 불러옴
                DataTable dataTable = receiptControl.GetReceipt(selectedDate);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    ReceiptDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("해당 날짜에 영수증이 없습니다.");
                }
            }
            else
            {
                string receiptNumber = receiptNumberTextBox.Text.Trim(); // 영수증 번호를 가져옴

                DataTable dataTable = receiptControl.GetReceipt(selectedDate, receiptNumber);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    ReceiptDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("해당 번호의 영수증을 찾을 수 없습니다.");
                }
            }
        }

        private void RefundButton_Click_1(object sender, EventArgs e)
        {
            if (ReceiptDataGridView.CurrentCell == null && ReceiptDataGridView.CurrentCell.Selected)
            {
                MessageBox.Show("환불할 영수증을 선택하세요.");
                return;
            }

            // DataGridView에서 선택된 행의 "영수증번호" 셀의 값을 가져옴
            string receiptNo = ReceiptDataGridView.SelectedRows[0].Cells["영수증번호"].Value.ToString();

            DialogResult result = MessageBox.Show("환불 처리를 하시겠습니까?", "환불", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isRefunded = refundController.ProcessRefund(receiptNo);

                if (isRefunded)
                {
                    MessageBox.Show("환불 처리가 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show("환불 처리 중 오류가 발생했습니다.");
                }
            }
        }

        private void ReceiptDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string receiptNo = ReceiptDataGridView.Rows[e.RowIndex].Cells["영수증번호"].Value.ToString();
                DataTable dataTable = receiptControl.GetReceiptDetails(receiptNo);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    receiptDetailGridView.DataSource = dataTable;
                }
            }
        }
    }
}