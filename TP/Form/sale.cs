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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using TP.control;

namespace TP
{

    public partial class sale : Form
    {
        private string cord;
        SaleController saleController = new SaleController();

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


        private void pay_Click(object sender, EventArgs e)
        {

        }

        private void cordButton_Click(object sender, EventArgs e)
        {
            cord = productCordTextBox.Text;

            if (saleController.checkProductCord(cord))
            {
                MessageBox.Show("로그인에 성공했습니다.", "로그인 성공");

            }
            else
            {
                MessageBox.Show("잘못된 아이디 또는 비밀번호 입니다.", "로그인 실패");
            }
        }
    }
}
