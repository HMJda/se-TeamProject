using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using TP.control;


namespace TP
{
    public partial class AddInvenUI : Form
    {
        private OrderReturnController OrderController;
        private InquiryInvenController inquiryInvenController;
        private DataTable dt;

        public AddInvenUI()
        {
            InitializeComponent();
            OrderController = new OrderReturnController();
            inquiryInvenController = new InquiryInvenController();
            dataview();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //Exit 버튼 - 클릭 시 창 닫음
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // 확인 창을 띄워 사용자에게 등록 여부를 물어봅니다.
            DialogResult result = MessageBox.Show("등록하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 사용자가 "예"를 선택한 경우
            if (result == DialogResult.Yes)
            {
                int testquantity = 1;
                // 등록 작업 실행
                changeLog(testquantity);
                //재고 테이블에 수량 추가
                for (int i = 0; i < addInvenTable.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(addInvenTable.Rows[i].Cells["chk"].Value)) //체크된 데이터 선택 부분
                    {
                        try
                        {
                            string sqltxt;
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
                            new OracleParameter("제품번호", addInvenTable.Rows[i].Cells["발주제품"].Value.ToString()),
                            new OracleParameter("제품명", addInvenTable.Rows[i].Cells["제품명"].Value.ToString()),
                            new OracleParameter("재고량", Convert.ToInt32(addInvenTable.Rows[i].Cells["수량"].Value)),
                            new OracleParameter("가격",  Convert.ToInt32(addInvenTable.Rows[i].Cells["단가"].Value)*1.1),
                        };
                            inquiryInvenController.SetStock(sqltxt, stock);

                            OrderController.SetOrder("DELETE 발주");
                            Properties.Settings.Default.date = DateTime.Now.ToString("yyyy-MM-dd");
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            // 사용자가 "아니오"를 선택한 경우는 아무 작업도 수행하지 않습니다.
            
        }

        // 등록 작업을 실행하는 메서드
        private void changeLog(int n)
        {
            // 등록된 물품 정보
            string productCode = "001"; // 예시로 상품 코드를 하드코딩하여 사용
            string productName = "상품1"; // 예시로 상품명을 하드코딩하여 사용
            int quantity = 10; // 예시로 등록된 개수를 하드코딩하여 사용

            // 등록된 물품 정보와 개수 변동 사항을 메시지 박스에 표시
            string message = $"상품이 등록되었습니다.\n\n상품 코드: {productCode}\n상품명: {productName}\n등록된 개수: {quantity}개";
            MessageBox.Show(message, "등록 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataview()
        {
            try
            {
                addInvenTable.Columns.Clear();
                dt = OrderController.GetOrders("select 발주제품,제품.제품명,수량,제품.규격,제품.제조업체,제품.단가 from 발주,제품 where 발주.발주제품=제품.제품번호");
                addInvenTable.AllowUserToAddRows = false; //빈레코드 표시x
                var chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "chk",
                    HeaderText = "선택"
                };
                addInvenTable.Columns.Add(chkCol);
                addInvenTable.DataSource = dt;   //데이터 추가 부분

                //크기 조절부분 
                addInvenTable.Columns[0].Width = 40;

                // dataGridView1.ReadOnly = true; //전부 읽기 전용
                for (int i = 1; i < addInvenTable.Columns.Count; i++)
                {
                    addInvenTable.Columns[i].ReadOnly = true;
                }

            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
