using System;
using System.Windows.Forms;


namespace TP
{
    public partial class AddInvenUI : Form
    {
        string DB_Server_Info = "Data Source = localhost; User ID = system; Password = 1234;";
        public AddInvenUI()
        {
            InitializeComponent();
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
    }
}
