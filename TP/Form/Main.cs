using System;
using System.Windows.Forms;

namespace TP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Form form = new Login(this);
            form.ShowDialog();
        }

        private void Order_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.

            LoginController loginController = new LoginController();
            string position = loginController.GetUserDetail(Properties.Settings.Default.LoginIDSave.ToString(), "직책").Trim();
            if (position == "점장")
            {
                this.Hide();
                // 발주 폼을 생성하고 표시합니다
                using (Form form = new Order())
                {
                    // ShowDialog()를 사용해 발주 폼을 모달로 표시합니다.
                    form.ShowDialog();

                    // 발주 폼이 닫히면 메인 폼을 다시 표시합니다.
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("점장이 아닙니다.", "경고");
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 반품 폼을 생성하고 표시합니다
            using (Form form = new Return())
            {
                // ShowDialog()를 사용해 반품 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 반품 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void Stock_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 재고 폼을 생성하고 표시합니다
            using (Form form = new Stock())
            {
                // ShowDialog()를 사용해 재고 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 재고 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void setting_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 판매 폼을 생성하고 표시합니다
            using (Form form = new setting(this))
            {
                // ShowDialog()를 사용해 판매 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 판매 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void sale_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 판매 폼을 생성하고 표시합니다
            using (Form form = new sale())
            {
                // ShowDialog()를 사용해 판매 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 판매 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void receipt_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 영수증 조회 폼을 생성하고 표시합니다
            using (Form form = new receipt())
            {
                // ShowDialog()를 사용해 영수증 조회 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 영수증 조회 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void productinformation_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 물품상세조회 폼을 생성하고 표시합니다
            using (Form form = new productinformation())
            {
                // ShowDialog()를 사용해 물품상세조회 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 물품상세조회 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void salesfigures_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 판매실적조회 폼을 생성하고 표시합니다
            using (Form form = new salesfigures())
            {
                // ShowDialog()를 사용해 판매실적조회 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 판매실적조회 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void finish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rateofreturn_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 이익률조회 폼을 생성하고 표시합니다
            using (Form form = new rateofreturn())
            {
                // ShowDialog()를 사용해 이익률조회 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 이익률조회 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }

        private void addInven_Click(object sender, EventArgs e)
        {
            // 메인 폼을 숨깁니다.
            this.Hide();

            // 판매 폼을 생성하고 표시합니다
            using (Form form = new AddInvenUI())
            {
                // ShowDialog()를 사용해 판매 폼을 모달로 표시합니다.
                form.ShowDialog();

                // 판매 폼이 닫히면 메인 폼을 다시 표시합니다.
                this.Show();
            }
        }
    }
}
