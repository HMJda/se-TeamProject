using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP.control;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace TP
{
    public partial class salesfigures : Form
    {
        private salesfiguresController sfcontroller;
        private string setdate;
        private int type;

        public salesfigures()
        {
            InitializeComponent();
            sfcontroller = new salesfiguresController();
            // 년도 설정
            DateTime today = DateTime.Today;
            int thisYear = today.Year;
            for (int i = thisYear - 5; i < thisYear + 6; i++)
            {
                yearcomboBox.Items.Add(i.ToString());
            }
            yearcomboBox.Text = thisYear.ToString();
            // 월 설정
            for (int i = 1; i < 13; i++)
            {
                monthcomboBox.Items.Add(i.ToString());
            }
            monthcomboBox.Text = today.Month.ToString();
            type = 1;
            setdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dataview(type, setdate);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //일별 판매실적, 월별 판매실적, 대분류별 판매실적
            if (radioButton1.Checked == true)
            {
                type = 1;
                setdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                dataview(type, setdate);
                //MessageBox.Show(setdate);
            }
            else if (radioButton2.Checked == true)
            {
                type = 2;
                setdate = string.Format("{0:D4}-{1:D2}", Int32.Parse(yearcomboBox.Text.ToString()), Int32.Parse(monthcomboBox.Text.ToString()));
                dataview(type, setdate);
                //MessageBox.Show(setdate);
            }
            else if (radioButton3.Checked == true)
            {
                type = 3;
                setdate = string.Format("{0:D4}-{1:D2}", Int32.Parse(yearcomboBox.Text.ToString()), Int32.Parse(monthcomboBox.Text.ToString()));
                dataview(type,setdate);
                //MessageBox.Show(setdate);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false) //월별판매실적 or 대분류별판매실적
            {
                monthcomboBox.Visible = true;
                yearcomboBox.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                dateTimePicker1.Visible = false;
            }
            else if (radioButton1.Checked == true) //일일판매실적 
            {
                monthcomboBox.Visible = false;
                yearcomboBox.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                dateTimePicker1.Visible = true;
                type = 1;
                setdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                dataview(type, setdate);
            }
            else if (radioButton2.Checked == true)
            {
                dataGridView1.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
                type = 2;
                setdate = string.Format("{0:D4}-{1:D2}", Int32.Parse(yearcomboBox.Text.ToString()), Int32.Parse(monthcomboBox.Text.ToString()));
                dataview(type, setdate);
            }
            if (radioButton3.Checked == true) //대분류별판매실적 
            { 
                dataGridView1.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                dataGridView2.Visible = true;
                dataGridView3.Visible = true;
                type = 3;
                setdate = string.Format("{0:D4}-{1:D2}", Int32.Parse(yearcomboBox.Text.ToString()), Int32.Parse(monthcomboBox.Text.ToString()));
                dataview(type, setdate);
            }
            else //대분류가 아닌경우
            {
                dataGridView1.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView3.Visible = false;
            }
        }
        private void dataview(int type,string setdate)
        {
            dataGridView1.Columns.Clear();
            DataTable dt = sfcontroller.salesCalc(type, setdate);
            //dataGridView1.AllowUserToAddRows = false; //빈레코드 표시x
            if (type == 1 || type == 2)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView2.DataSource = dt;
                dataGridView3.DataSource = dt;
            }            
        }
    }
}
