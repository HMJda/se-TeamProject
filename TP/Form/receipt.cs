using System;
using System.Data;
using System.Windows.Forms;
using TP.control;

namespace TP
{

    public partial class receipt : Form
    {
        private ReceiptControl receiptControl;

        public receipt()
        {
            InitializeComponent();
            receiptControl = new ReceiptControl();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchTextbox.Text;
            DateTime searchDate = dateTime.Value;

            int receiptNo = 0;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                int.TryParse(searchText, out receiptNo);
            }

            DataTable dataTable = receiptControl.GetReceipt(searchDate, receiptNo);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                receiptDataGridView.DataSource = dataTable;
            }
            else
            {
                receiptDataGridView.DataSource = null;
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    MessageBox.Show("해당 날짜에 영수증이 없습니다.");
                }
                else
                {
                    MessageBox.Show("해당 번호의 영수증이 없습니다.");
                }
            }
        }

        private void receiptDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = receiptDataGridView.Rows[e.RowIndex];
                int receiptNo = Convert.ToInt32(row.Cells["No"].Value);

                DataTable dataTable = receiptControl.GetReceiptDetails(receiptNo);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    receiptDetailGridView.DataSource = dataTable;
                }
            }
        }

        private void refundButton_Click(object sender, EventArgs e)
        {
            if (receiptDetailGridView.DataSource == null)
            {
                MessageBox.Show("환불할 영수증을 선택하세요.");
                return;
            }

            DialogResult result = MessageBox.Show("환불 처리를 하시겠습니까?", "환불", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string paymentMethod = ""; // 체크박스 또는 라디오 버튼을 통해 결제 방법을 받음
                bool isRefunded = receiptControl.ProcessRefund(Convert.ToInt32(receiptDetailGridView.Rows[0].Cells["ReceiptNo"].Value), paymentMethod);

                if (isRefunded)
                {
                    MessageBox.Show("환불 처리가 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show("결제 정보가 일치하지 않습니다.");
                }
            }
        }
    }
}