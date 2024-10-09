using System;
using System.Windows.Forms;

namespace WinFormApp {
    // Form 클래스 상속받아서 내 코드를 추가한다.
    public partial class Form1 : Form {
        // 생성자 함수
        public Form1() {
            // 윈폼을 초기화한다.
            InitializeComponent();
        }

        // 버튼 클릭 이벤트 - 콜백함수(대응함수)
        private void onClickButton(object sender, EventArgs e) {
            Console.WriteLine("김민규 서류 축하!");
            label1.Text = "김민규 서류 축하!";
        }
    }
}