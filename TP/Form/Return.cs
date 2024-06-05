﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TP.control;

namespace TP
{
    public partial class Return : Form
    {
        private string DB_Server_Info = "Data Source = localhost;" +
           "User ID = DEU; Password = 1234;";
        private string categori = null;
        private string label = "제품명";
        private bool saveSuccess = false; //저장 성공
        private bool selectsusses = false; // 검색 성공
        private StockController stckcontroller;
        private OrderReturnController returnController;
        private LoginController loginController;
        private DataTable dt;
        public Return()
        {
            InitializeComponent();
            stckcontroller = new StockController();
            returnController = new OrderReturnController();
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
                dt = stckcontroller.GetStock();
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
                dataGridView1.Columns.Add("반품량", "반품량");
                dataGridView1.Columns.Add("비고", "비고");

                //크기 조절부분 
                dataGridView1.Columns[0].Width = 40;

                //dataGridView1.ReadOnly = true; //전부 읽기 전용           
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns["반품량"].ReadOnly = false;
                dataGridView1.Columns["비고"].ReadOnly = false;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //검색부분
            selectsusses = false;
            label = comboBox1.Text;
            find();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["chk"].Value)) //체크된 데이터 선택 부분
                {
                    try
                    {
                        if (Properties.Settings.Default.Returnindex == 0)
                        {
                            returnController.SetReturn("DELETE 반품");
                        }

                        OracleConnection conn = new OracleConnection(DB_Server_Info);
                        string user_address = loginController.GetUserDetail(Properties.Settings.Default.LoginIDSave.ToString(), "편의점주소");

                        OracleCommand oc = new OracleCommand();
                        oc.Connection = conn;
                        oc.CommandText = "MERGE \n into 반품 \n USING dual \n ON (반품제품 = :반품제품) " + "\n WHEN NOT MATCHED THEN \n" +
                            "insert (반품번호,반품고객,반품제품,반품수량,반품지,반품일자) values(:반품번호, :반품고객, :반품제품,:반품수량,:반품지,:반품일자)"
                            + "WHEN MATCHED THEN UPDATE SET 반품수량 = :반품수량 ";
                        oc.BindByName = true;
                        oc.Parameters.Add(new OracleParameter("반품번호", Properties.Settings.Default.Returnindex.ToString()));
                        oc.Parameters.Add(new OracleParameter("반품고객", Properties.Settings.Default.LoginIDSave.ToString()));
                        oc.Parameters.Add(new OracleParameter("반품제품", dataGridView1.Rows[i].Cells["제품번호"].Value.ToString()));
                        oc.Parameters.Add(new OracleParameter("반품수량", Convert.ToInt32(dataGridView1.Rows[i].Cells["반품량"].Value)));
                        oc.Parameters.Add(new OracleParameter("반품지", user_address));
                        oc.Parameters.Add(new OracleParameter("반품일자", DateTime.Now.ToString("yyyy-MM-dd").ToString()));
                        //반품번호 //반품고객// 반품제품 // 반품수량 // 반품지 // 반품일자// 
                        if (conn.State == ConnectionState.Open) conn.Close();
                        conn.Open();
                        oc.ExecuteNonQuery();
                        OracleCommand occ = new OracleCommand(); //재고 추가 부분
                        occ.Connection = conn;
                        if (DateTime.Now.ToString("yyyy-MM-dd").ToString() != Properties.Settings.Default.date)
                        {
                            occ.CommandText = "MERGE \n into 재고 \n USING dual \n ON (제품번호 = :제품번호) " +
                             "WHEN MATCHED THEN UPDATE SET 재고량 = 재고량 -:재고량 ";
                        }
                        else
                        {
                            occ.CommandText = "MERGE \n into 재고 \n USING dual \n ON (제품번호 = :제품번호) " +
                             "WHEN MATCHED THEN UPDATE SET 재고량 = 재고량 -:재고량 ";
                        }
                        occ.BindByName = true;
                        //occ.Parameters.Add(new OracleParameter("카테고리", dataGridView1.Rows[i].Cells[pindex - 1].Value.ToString()));
                        occ.Parameters.Add(new OracleParameter("제품번호", dataGridView1.Rows[i].Cells["제품번호"].Value.ToString()));
                        //occ.Parameters.Add(new OracleParameter("제조업체", dataGridView1.Rows[i].Cells[pindex + 1].Value.ToString()));
                        //occ.Parameters.Add(new OracleParameter("제품명", dataGridView1.Rows[i].Cells[pindex + 2].Value.ToString()));
                        occ.Parameters.Add(new OracleParameter("재고량", Convert.ToInt32(dataGridView1.Rows[i].Cells["반품량"].Value)));
                        //occ.Parameters.Add(new OracleParameter("단가", dataGridView1.Rows[i].Cells[pindex + 4].Value));
                        //occ.Parameters.Add(new OracleParameter("규격", dataGridView1.Rows[i].Cells[pindex + 5].Value.ToString()));
                        //카테고리,제품번호,제조업체,제품명,재고량,단가,규격
                        Properties.Settings.Default.date = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                        if (conn.State == ConnectionState.Open) conn.Close();
                        conn.Open();
                        occ.ExecuteNonQuery();
                        Properties.Settings.Default.Returnindex += 1; //반품번호 값증가시키기
                        saveSuccess = true;
                    }
                    catch (OracleException ex)
                    {
                        saveSuccess = false;
                        MessageBox.Show(ex.Message);
                    }
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }

            }

            if (saveSuccess == true)
            {
                MessageBox.Show("저장되었습니다.");
                dataview();
            }
            //save 부분
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
            if (selectsusses == false)
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

        private void Return_FormClosing(object sender, FormClosingEventArgs e)
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
                else if (dialog == DialogResult.No)
                {
                    e.Cancel = false;
                }
                //MessageBox.Show("저장하시겠습니까?"); //예,아니요,취소 부분 되게 
            }
        }
    }
}
