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
using TP.control;

namespace TP
{

    public partial class Order : Form
    {
        private string DB_Server_Info = "Data Source = localhost;" +
           "User ID = DEU; Password = 1234;";
        private string categori = null;
        private string label = "제품명";
        private bool saveSuccess = false; //저장 성공
        private bool selectsusses = false; //검색 성공 
        private StockController stckcontroller;
        private ProductInfoController productInfoController;
        private OrderReturnController orderController;
        private LoginController loginController;
        private string sqltxt = "select * from 제품";
        private DataTable dt;
        public Order()
        {
            InitializeComponent();
            stckcontroller = new StockController();
            productInfoController = new ProductInfoController();
            orderController = new OrderReturnController();
            loginController = new LoginController();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //콤보 박스 읽기 전용
            comboBox1.Text = label;
            dataview();
        }
        private void dataview()
        {          
            try
            {
                dataGridView1.Columns.Clear();
                dt = productInfoController.GetProduct();             
                if (!string.IsNullOrEmpty(categori)) // Check if categori is not empty or null
                {
                    dt.DefaultView.RowFilter = $"카테고리 ='{categori}'";
                }
                //dt.DefaultView.RowFilter = $"카테고리 ='{categori}'";
                dataGridView1.AllowUserToAddRows = false; //빈레코드 표시x
                var chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "chk",
                    HeaderText = "선택"
                };
                dataGridView1.Columns.Add(chkCol);
                dataGridView1.DataSource = dt;   //데이터 추가 부분
                dataGridView1.Columns.Add("발주량", "발주량");
                dataGridView1.Columns.Add("비고", "비고");

                //크기 조절부분 
                dataGridView1.Columns[0].Width = 40;

                // dataGridView1.ReadOnly = true; //전부 읽기 전용
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }

                // 발주량과 비고 열은 읽기 전용 해제
                dataGridView1.Columns["발주량"].ReadOnly = false;
                dataGridView1.Columns["비고"].ReadOnly = false;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e) //검색 부분
        {
            selectsusses = false;
            label = comboBox1.Text;
            find();
        }

        private void button1_Click(object sender, EventArgs e) //save 부분
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["chk"].Value)) //체크된 데이터 선택 부분
                {
                    try
                    {
                        if (Properties.Settings.Default.Orderindex == 0)
                        {
                            orderController.SetOrder("DELETE 발주");
                        }
                        string user_address = loginController.GetUserDetail(Properties.Settings.Default.LoginIDSave.ToString(), "편의점주소");
                        //발주 테이블 추가 
                        string sqltxt = "MERGE INTO 발주 " +
                                        "USING dual " +
                                        "ON (발주제품 = :발주제품) " +
                                        "WHEN NOT MATCHED THEN " +
                                        "INSERT (발주번호, 주문고객, 발주제품, 수량, 배송지, 주문일자) " +
                                        "VALUES (:발주번호, :주문고객, :발주제품, :수량, :배송지, :주문일자) " +
                                        "WHEN MATCHED THEN UPDATE SET 수량 = :수량";
                        OracleParameter[] order =
                        {
                            new OracleParameter("발주번호", Properties.Settings.Default.Orderindex.ToString()),
                            new OracleParameter("주문고객", Properties.Settings.Default.LoginIDSave.ToString()),
                            new OracleParameter("발주제품", dataGridView1.Rows[i].Cells["제품번호"].Value.ToString()),
                            new OracleParameter("수량", Convert.ToInt32(dataGridView1.Rows[i].Cells["발주량"].Value)),
                            new OracleParameter("배송지", user_address),
                            new OracleParameter("주문일자", DateTime.Now.ToString("yyyy-MM-dd"))
                        };  
                        orderController.SetOrder(sqltxt, order);

                        //재고 테이블에 수량 추가
                        if (DateTime.Now.ToString("yyyy-MM-dd") != Properties.Settings.Default.date)
                        {
                            sqltxt = "MERGE INTO 재고 " +
                                "USING dual " +
                                "ON (제품번호 = :제품번호) " +
                                "WHEN NOT MATCHED THEN " +
                                "INSERT (제품번호, 제품명, 재고량, 가격) " +
                                "VALUES (:제품번호, :제품명, :재고량, :가격) " +
                                "WHEN MATCHED THEN " +
                                "UPDATE SET 재고량 = 재고량 + :재고량";
                        }
                        else
                        {
                            sqltxt = "MERGE INTO 재고 " +
                                "USING dual " +
                                "ON (제품번호 = :제품번호) " +
                                "WHEN NOT MATCHED THEN " +
                                "INSERT (제품번호, 제품명, 재고량, 가격) " +
                                "VALUES (:제품번호, :제품명, :재고량, :가격) " +
                                "WHEN MATCHED THEN " +
                                "UPDATE SET 재고량 = :재고량";
                        }

                        OracleParameter[] stock =
                        {
                            new OracleParameter("제품번호", dataGridView1.Rows[i].Cells["제품번호"].Value.ToString()),
                            new OracleParameter("제품명", dataGridView1.Rows[i].Cells["제품명"].Value.ToString()),
                            new OracleParameter("재고량", Convert.ToInt32(dataGridView1.Rows[i].Cells["발주량"].Value)),
                            new OracleParameter("가격",  Convert.ToInt32(dataGridView1.Rows[i].Cells["단가"].Value)*1.1),
                        };

                        stckcontroller.SetStock(sqltxt, stock);

                        Properties.Settings.Default.date = DateTime.Now.ToString("yyyy-MM-dd");

                        saveSuccess = true;
                    }
                    catch (OracleException ex)
                    {
                        saveSuccess = false;
                        MessageBox.Show(ex.Message);
                    }
                    Properties.Settings.Default.Orderindex += 1; //발주번호 값증가시키기
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;  //선택된 데이터 노란색으로 보임
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                
            }
            if (saveSuccess == true)
            {
                MessageBox.Show("저장되었습니다.");
            }

            /*for (int j = 0; j < list.Count; j++)
            {
                sw.WriteLine($"{list[j].Orderindex},{list[j].userID},{list[j].product},{list[j].quantity},{list[j].user_address},{list[j].date}");
            }
            sw.Close();
            fs.Close();*/
        }
        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            //닫혔을때 save 하는지 물어보는 부분 
            if (saveSuccess == false)
            {
                DialogResult dialog = MessageBox.Show("저장하시겠습니까?", "경고", MessageBoxButtons.YesNoCancel);
                if (dialog == DialogResult.Yes)
                {
                    button1.PerformClick();
                }
                else if (dialog == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if(dialog == DialogResult.No)
                {
                    e.Cancel = false;
                }
                //MessageBox.Show("저장하시겠습니까?"); //예,아니요,취소 부분 되게 
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e) //카테고리 선택
        {
            if (radioButton4.Checked == true)
            {
                categori = null;
                dataview();

            }
            if (radioButton1.Checked == true)
            {
                categori = radioButton1.Text;
                dataview();

            }
            else if (radioButton2.Checked == true)
            {
                categori = radioButton2.Text;
                dataview();
            }
            else if (radioButton3.Checked == true)
            {
                categori = radioButton3.Text;
                dataview();
            }
        }

        private void find() //검색 부분
        {
            string keyword = textBox1.Text;//Textbox에 입력된 메시지를 keyword 저장
                                           // 인덱스를 찾을 이름, 검색할 입력값

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               
                if (dataGridView1.Rows[i].Cells[$"{label}"].Value.ToString().Trim() == keyword.Trim())
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;  //색칠
                    selectsusses = true;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            if(selectsusses == false)
            {
                MessageBox.Show("검색 결과가 없습니다.");
            }       
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            saveSuccess = false;
        }    
    }
}
