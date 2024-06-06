using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Windows.Forms;
using TP.control;


namespace TP
{
    public partial class InvenUI : Form
    {
        private string categori = null;
        private string label = "제품명";
        private int selectsusses = 0; //검색 성공 
        private InquiryInvenController inquiryInvenController;
        private ProductInfoController productInfoController;

        public InvenUI()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //콤보 박스 읽기 전용
            comboBox1.Text = label;
            inquiryInvenController = new InquiryInvenController();
            productInfoController = new ProductInfoController();

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
            LoadCategories();

            dataview();
        }

        private void LoadCategories()
        {
            try
            {
                // 기본 "전체" 추가
                comboBox2.Items.Add("전체");

                // 카테고리 데이터 불러오기
                DataTable categoryData = productInfoController.GetCategories();
                foreach (DataRow row in categoryData.Rows)
                {
                    comboBox2.Items.Add(row["카테고리"].ToString());
                }

                comboBox2.SelectedIndex = 0; // 기본적으로 "전체" 선택
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            categori = comboBox2.SelectedItem.ToString() == "전체" ? null : comboBox2.SelectedItem.ToString();
            dataview();
        }

        private void dataview()
        {
            DataTable dt = inquiryInvenController.GetStock();
            if (!string.IsNullOrEmpty(categori)) // Check if categori is not empty or null
            {
                dt.DefaultView.RowFilter = $"카테고리 ='{categori}'";
            }
            dataGridView1.AllowUserToAddRows = false; //빈레코드 표시x
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Exit 버튼 - 클릭 시 창 닫음
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectsusses = 0;
            label = comboBox1.Text;
            find();
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
                    selectsusses = 1;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            if (selectsusses == 0)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
