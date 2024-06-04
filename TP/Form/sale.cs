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

namespace TP
{

    public partial class sale : Form
    {
        private string cord;
        SaleController saleController = new SaleController();
        ProductInfoEntity productInfoEntity = new ProductInfoEntity();
        private List<ProductInfo> productInfos = new List<ProductInfo>();

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
                var productInfo = productInfoEntity.GetProductInfo(cord);
                MessageBox.Show("제품이 등록되었습니다.", "제품 등록");

                // 제품을 추가하거나 업데이트하는 메서드 호출
                AddOrUpdateProduct(productInfo.Item1, productInfo.Item2, productInfo.Item3);

                // 제품 목록과 총 가격을 업데이트하는 메서드 호출
                UpdateProductListAndTotal();
            }
            else
            {
                MessageBox.Show("잘못된 제품 번호입니다.", "제품 등록 실패");
            }
        }
        private void AddOrUpdateProduct(string cord, string name, decimal price)
        {
            var existingProduct = productInfos.Find(p => p.Cord == cord);
            if (existingProduct != null)
            {
                existingProduct.Quantity += 1;
            }
            else
            {
                productInfos.Add(new ProductInfo { Cord = cord, Name = name, Price = price, Quantity = 1 });
            }
        }
        private void UpdateProductListAndTotal()
        {
            textBox6.Clear();
            decimal total = 0;
            foreach (var product in productInfos)
            {
                decimal productTotalPrice = product.Price * product.Quantity;
                textBox6.Text += $"{product.Name}\t{product.Price}\t\t{product.Quantity}\t{productTotalPrice}\r\n";
                total += productTotalPrice;
            }
            // 총 가격을 표시하는 Label이 있다고 가정하고 호출
            totalAmountLabel.Text = $"총 가격: {total}";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public class ProductInfo
        {
            public string Cord { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
