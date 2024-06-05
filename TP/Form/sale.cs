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
            int quantity = 1;
            bool productExists = false;

            // 제품 코드의 유효성을 확인한 후, 해당 제품 코드가 textBox2에 존재하는지 확인
            string[] lines = textBox2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(productCode))
                {
                    productExists = true;
                    var parts = lines[i].Split('\t');
                    int existingQuantity = int.Parse(parts[2]);
                    quantity = existingQuantity + 1;
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    lines[i] = $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}";
                    textBox2.Lines = lines;
                    break;
                }
            }
            if (!productExists)
            {
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}\r\n";
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
            int quantity = 1;
            bool productExists = false;

            string[] lines = textBox2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(productCode))
                {
                    productExists = true;
                    var parts = lines[i].Split('\t');
                    int existingQuantity = int.Parse(parts[2]);
                    quantity = existingQuantity + 1;
                    // 재고 확인
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    lines[i] = $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}";
                    textBox2.Lines = lines;
                    break;
                }
            }
            if (!productExists)
            {
                // 재고 확인
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}\r\n";
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
            int quantity = 1;
            bool productExists = false;

            string[] lines = textBox2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(productCode))
                {
                    productExists = true;
                    var parts = lines[i].Split('\t');
                    int existingQuantity = int.Parse(parts[2]);
                    quantity = existingQuantity + 1;
                    // 재고 확인
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    lines[i] = $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}";
                    textBox2.Lines = lines;
                    break;
                }
            }
            if (!productExists)
            {
                // 재고 확인
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}\r\n";
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
            int quantity = 1;
            bool productExists = false;

            string[] lines = textBox2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(productCode))
                {
                    productExists = true;
                    var parts = lines[i].Split('\t');
                    int existingQuantity = int.Parse(parts[2]);
                    quantity = existingQuantity + 1;
                    // 재고 확인
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    lines[i] = $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}";
                    textBox2.Lines = lines;
                    break;
                }
            }
            if (!productExists)
            {
                // 재고 확인
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}\r\n";
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
            int quantity = 1;
            bool productExists = false;

            string[] lines = textBox2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(productCode))
                {
                    productExists = true;
                    var parts = lines[i].Split('\t');
                    int existingQuantity = int.Parse(parts[2]);
                    quantity = existingQuantity + 1;
                    // 재고 확인
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    lines[i] = $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}";
                    textBox2.Lines = lines;
                    break;
                }
            }
            if (!productExists)
            {
                // 재고 확인
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}\r\n";
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
            int quantity = 1;
            bool productExists = false;

            string[] lines = textBox2.Lines;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(productCode))
                {
                    productExists = true;
                    var parts = lines[i].Split('\t');
                    int existingQuantity = int.Parse(parts[2]);
                    quantity = existingQuantity + 1;
                    // 재고 확인
                    if (quantity > stockQuantity)
                    {
                        MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                        return;
                    }
                    lines[i] = $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}";
                    textBox2.Lines = lines;
                    break;
                }
            }
            if (!productExists)
            {
                // 재고 확인
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("재고 수량을 초과했습니다.", "제품 등록 실패");
                    return;
                }
                textBox2.Text += $"{productCode}\t{productName}\t{quantity}\t{price}\t{quantity * price}\r\n";
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
