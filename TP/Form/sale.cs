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
using TP.Entitiy;
using System.Collections.Specialized;

namespace TP
{

    public partial class sale : Form
    {
        private StockController stockController;
        private DataTable dt;
        public sale()
        {
            InitializeComponent();
            stockController = new StockController();
        }
        private void cordButton_Click(object sender, EventArgs e)
        {
            string productCode = productCordTextBox.Text.Trim();
            dt = stockController.GetStock();
            DataRow[] foundRows = dt.Select($"제품번호 = '{productCode}'");

            if (foundRows.Length == 0)
            {
                MessageBox.Show("재고가 존재하지 않습니다.", "제품 등록 실패");
                return;
            }

            DataRow productRow = foundRows[0];
            string productName = productRow["제품명"].ToString();
            int price = Convert.ToInt32(productRow["가격"]);
            int stockQuantity = Convert.ToInt32(productRow["재고량"]);
            bool productExists = false;

            // 제품 코드의 유효성을 확인한 후, 해당 제품 코드가 textBox2에 존재하는지 확인

            if (!productExists)
            {
                int newquantity = 1;
                if (newquantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"\r\n{productCode}\t\t{productName}\t\t\t\t{newquantity}\t\t{price}\t\t{newquantity * price}";
            }
            int quantity = 1;
            foreach (var line in textBox2.Lines)
            {
                if (line.Contains(productCode))
                {
                    productExists = true;
                    quantity = Convert.ToInt32($"{quantity}")+1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    string newLine = $"{productCode}\t\t{productName}\t\t\t\t{quantity}\t\t{price}\t\t{quantity * price}";
                    textBox2.Text = textBox2.Text.Replace(line, newLine);
                    break;
                }
            }
        }
        private void cash_Click(object sender, EventArgs e)
        {

        }
        private void allCancel_Click(object sender, EventArgs e)
        {

        }
        private void chupachups_Click(object sender, EventArgs e)
        {
            string productCode = "501";
            dt = stockController.GetStock();
            DataRow[] foundRows = dt.Select($"제품번호 = '{productCode}'");

            if (foundRows.Length == 0)
            {
                // 제품 번호가 유효하지 않은 경우
                MessageBox.Show("재고가 존재하지 않습니다.", "제품 등록 실패");
                return;
            }

            DataRow productRow = foundRows[0];
            string productName = productRow["제품명"].ToString();
            int price = Convert.ToInt32(productRow["가격"]);
            int stockQuantity = Convert.ToInt32(productRow["재고량"]);
            bool productExists = false;

            if (!productExists)
            {
                int newquantity = 1;
                // 재고 확인
                if (newquantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }

                textBox2.Text += $"\r\n{productCode}\t\t{productName}\t\t\t\t{newquantity}\t\t{price}\t\t{newquantity * price}";
            }

            int quantity = 1;
            foreach (var line in textBox2.Lines)
            {
                if (line.Contains(productCode))
                {
                    productExists = true;
                    quantity = Convert.ToInt32($"{quantity}") + 1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    string newLine = $"{productCode}\t\t{productName}\t\t\t\t{quantity}\t\t{price}\t\t{quantity * price}";
                    textBox2.Text = textBox2.Text.Replace(line, newLine);
                    break;
                }
            }
        }

        private void paperCup_Click(object sender, EventArgs e)
        {
            string productCode = "502";
            dt = stockController.GetStock();
            DataRow[] foundRows = dt.Select($"제품번호 = '{productCode}'");

            if (foundRows.Length == 0)
            {
                // 제품 번호가 유효하지 않은 경우
                MessageBox.Show("재고가 존재하지 않습니다.", "제품 등록 실패");
                return;
            }

            DataRow productRow = foundRows[0];
            string productName = productRow["제품명"].ToString();
            int price = Convert.ToInt32(productRow["가격"]);
            int stockQuantity = Convert.ToInt32(productRow["재고량"]);
            bool productExists = false;

            if (!productExists)
            {
                int newquantity = 1;
                // 재고 확인
                if (newquantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }

                textBox2.Text += $"\r\n{productCode}\t\t{productName}\t\t\t\t{newquantity}\t\t{price}\t\t{newquantity * price}";
            }

            int quantity = 1;
            foreach (var line in textBox2.Lines)
            {
                if (line.Contains(productCode))
                {
                    productExists = true;
                    quantity = Convert.ToInt32($"{quantity}") + 1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    string newLine = $"{productCode}\t\t{productName}\t\t\t\t{quantity}\t\t{price}\t\t{quantity * price}";
                    textBox2.Text = textBox2.Text.Replace(line, newLine);
                    break;
                }
            }
        }
        private void cupOfIce_Click(object sender, EventArgs e)
        {
            string productCode = "503";
            dt = stockController.GetStock();
            DataRow[] foundRows = dt.Select($"제품번호 = '{productCode}'");

            if (foundRows.Length == 0)
            {
                // 제품 번호가 유효하지 않은 경우
                MessageBox.Show("재고가 존재하지 않습니다.", "제품 등록 실패");
                return;
            }

            DataRow productRow = foundRows[0];
            string productName = productRow["제품명"].ToString();
            int price = Convert.ToInt32(productRow["가격"]);
            int stockQuantity = Convert.ToInt32(productRow["재고량"]);
            bool productExists = false;

            if (!productExists)
            {
                int newquantity = 1;
                // 재고 확인
                if (newquantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }

                textBox2.Text += $"\r\n{productCode}\t\t{productName}\t\t\t\t{newquantity}\t\t{price}\t\t{newquantity * price}";
            }

            int quantity = 1;
            foreach (var line in textBox2.Lines)
            {
                if (line.Contains(productCode))
                {
                    productExists = true;
                    quantity = Convert.ToInt32($"{quantity}") + 1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    string newLine = $"{productCode}\t\t{productName}\t\t\t\t{quantity}\t\t{price}\t\t{quantity * price}";
                    textBox2.Text = textBox2.Text.Replace(line, newLine);
                    break;
                }
            }
        }
        private void selectionCancel_Click(object sender, EventArgs e)
        {

        }
        private void plasticBackSmall_Click(object sender, EventArgs e)
        {
            string productCode = "504";
            dt = stockController.GetStock();
            DataRow[] foundRows = dt.Select($"제품번호 = '{productCode}'");

            if (foundRows.Length == 0)
            {
                // 제품 번호가 유효하지 않은 경우
                MessageBox.Show("재고가 존재하지 않습니다.", "제품 등록 실패");
                return;
            }

            DataRow productRow = foundRows[0];
            string productName = productRow["제품명"].ToString();
            int price = Convert.ToInt32(productRow["가격"]);
            int stockQuantity = Convert.ToInt32(productRow["재고량"]);
            bool productExists = false;

            if (!productExists)
            {
                int newquantity = 1;
                // 재고 확인
                if (newquantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }

                textBox2.Text += $"\r\n{productCode}\t\t{productName}\t\t\t\t{newquantity}\t\t{price}\t\t{newquantity * price}";
            }

            int quantity = 1;
            foreach (var line in textBox2.Lines)
            {
                if (line.Contains(productCode))
                {
                    productExists = true;
                    quantity = Convert.ToInt32($"{quantity}") + 1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    string newLine = $"{productCode}\t\t{productName}\t\t\t\t{quantity}\t\t{price}\t\t{quantity * price}";
                    textBox2.Text = textBox2.Text.Replace(line, newLine);
                    break;
                }
            }
        }
        private void plasticBackMedium_Click(object sender, EventArgs e)
        {
            string productCode = "505";
            dt = stockController.GetStock();
            DataRow[] foundRows = dt.Select($"제품번호 = '{productCode}'");

            if (foundRows.Length == 0)
            {
                // 제품 번호가 유효하지 않은 경우
                MessageBox.Show("재고가 존재하지 않습니다.", "제품 등록 실패");
                return;
            }

            DataRow productRow = foundRows[0];
            string productName = productRow["제품명"].ToString();
            int price = Convert.ToInt32(productRow["가격"]);
            int stockQuantity = Convert.ToInt32(productRow["재고량"]);
            bool productExists = false;

            if (!productExists)
            {
                int newquantity = 1;
                // 재고 확인
                if (newquantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }

                textBox2.Text += $"\r\n{productCode}\t\t{productName}\t\t\t\t{newquantity}\t\t{price}\t\t{newquantity * price}";
            }

            int quantity = 1;
            foreach (var line in textBox2.Lines)
            {
                if (line.Contains(productCode))
                {
                    productExists = true;
                    quantity = Convert.ToInt32($"{quantity}") + 1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    string newLine = $"{productCode}\t\t{productName}\t\t\t\t{quantity}\t\t{price}\t\t{quantity * price}";
                    textBox2.Text = textBox2.Text.Replace(line, newLine);
                    break;
                }
            }
        }
        private void pay_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
