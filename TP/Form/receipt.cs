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

namespace TP
{

    public partial class receipt : Form
    {
        public receipt()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 검색_Click(object sender, EventArgs e)
        {

        }

        private void 영수증조회_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void receipt_Load(object sender, EventArgs e)
        {

        }

        private void 환불_Click(object sender, EventArgs e)
        {
            // 다이얼로그 창을 통해 메시지를 표시하고 사용자의 선택에 따라 처리합니다.
            DialogResult result = MessageBox.Show("환불 처리를 하겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 사용자가 '예'를 선택한 경우
            if (result == DialogResult.Yes)
            {
                // 여기에 영수증 출력 코드를 작성합니다.
                MessageBox.Show("환불 처리");
            }
            // 사용자가 '아니오'를 선택한 경우
            else if (result == DialogResult.No)
            {

            }
        }

        private void 영수증출력_Click(object sender, EventArgs e)
        {
            // 다이얼로그 창을 통해 메시지를 표시하고 사용자의 선택에 따라 처리합니다.
            DialogResult result = MessageBox.Show("영수증을 출력하겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 사용자가 '예'를 선택한 경우
            if (result == DialogResult.Yes)
            {
                // 여기에 영수증 출력 코드를 작성합니다.
                MessageBox.Show("영수증을 출력합니다.");
            }
            // 사용자가 '아니오'를 선택한 경우
            else if (result == DialogResult.No)
            {
 
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
