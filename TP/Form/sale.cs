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
using static System.TimeZoneInfo;

namespace TP
{

    public partial class sale : Form
    {
        private StockController stockController;
        private SaleController saleController;
        private ReceiptList receiptList;
        private DataTable dt;
        public sale()
        {
            InitializeComponent();
            stockController = new StockController();
            receiptList = new ReceiptList();
            saleController = new SaleController();
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
                    UpdateTotalPrice();
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
                UpdateTotalPrice();
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
                    UpdateTotalPrice();
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
                UpdateTotalPrice();
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
                    UpdateTotalPrice();
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
                UpdateTotalPrice();
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
                    UpdateTotalPrice();
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
                UpdateTotalPrice();
            }
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
                    UpdateTotalPrice();
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
                UpdateTotalPrice();
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
                    UpdateTotalPrice();
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
                UpdateTotalPrice();
            }
        }
        private void pay_Click(object sender, EventArgs e)
        {
            // 영수증 번호 생성
            string receiptNumber = Guid.NewGuid().ToString(); // 예시로 GUID를 사용; 실제로는 다른 방법을 사용할 수 있습니다.
            DateTime transactionTime = DateTime.Now;
            string transactionType = "현금";
            string[] lines = priceTextBox.Lines;
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split('\t');
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("영수증번호", receiptNumber),
                        new OracleParameter("거래시간", transactionTime.ToString("yyyy-MM-dd HH:mm:ss")),
                        new OracleParameter("거래형태", transactionType),
                        new OracleParameter("총가격", UpdateTotalPrice()),
                    };
                    string sqltxt = "INSERT INTO ReceiptTable (영수증번호, 거래시간, 거래형태, 총가격) VALUES (:영수증번호, :거래시간, :거래형태, :총가격)";
                    // 영수증 테이블에 각 제품 정보 저장
                    saleController.SetReceipt(sqltxt, parameters);          
                    MessageBox.Show("영수증 정보가 성공적으로 저장되었습니다.", "저장 성공");
                }
            }
        }

        private int UpdateTotalPrice()
        {
            int totalPrice = 0;
            foreach (string line in textBox2.Lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split('\t');
                    if (parts.Length == 5)
                    {
                        totalPrice += int.Parse(parts[4]); // decimal.Parse 대신 int.Parse를 사용
                    }
                }
            }
            priceTextBox.Text = totalPrice.ToString("C"); // 숫자를 통화 형식으로 변환하여 표시
            return totalPrice;
        }
    }
}
