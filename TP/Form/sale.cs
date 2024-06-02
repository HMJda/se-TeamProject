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

    public partial class sale : Form
    {
        public sale()
        {
            InitializeComponent();
        }

        private void cash_Click(object sender, EventArgs e)
        {

        }
        private void allCancel_Click(object sender, EventArgs e)
        {

        }
        private void chupachups_Click(object sender, EventArgs e)
        {

        }

        private void paperCup_Click(object sender, EventArgs e)
        {

        }

        private void cupOfIce_Click(object sender, EventArgs e)
        {

        }

        private void selectionCancel_Click(object sender, EventArgs e)
        {

        }

        private void plasticBackSmall_Click(object sender, EventArgs e)
        {

        }

        private void plasticBackMedium_Click(object sender, EventArgs e)
        {

        }

        private void productList_Click(object sender, EventArgs e)
        {
            // 판매 폼을 생성하고 표시합니다
            using (Form form = new Stock())
            {
                // ShowDialog()를 사용해 판매 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 판매 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void pay_Click(object sender, EventArgs e)
        {

        }
    }
}
