using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindNumber {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private int findNumber = 0;
        private int chance = 0;


        // 게임시작 버튼
        private void ButtonStart_Click(object sender, EventArgs e) {
            
            // 1부터 20 사이의 랜덤 수 발생!
            Random rand = new Random();
            this.findNumber = rand.Next(1, 20);

            // 10회 찬스 설정
            this.chance = 10;

            // 게임 초기화
            display.Text = "1부터 20사이의 수를 맞추세요";
        }

        // 번호 입력 버튼
        private void ButtonInput_Click(object sender, EventArgs e) {
            // 텍스트 박스의 입력된 숫자를 가져오기
            // string -> int로 바꾸기
            int inputNumber = Int32.Parse(textBox.Text);

            // 랜덤수와 입력된 숫자를 비교하기
            // 1. 일치한 경우 = "승리"
            if(inputNumber == this.findNumber) {
                display.Text = "승리 " + this.findNumber;
                return;
            }

            // 2. 10회 이하인 경우: "실패. 남은 기회는 9번"
            //    10회 초과한 경우: "패배"
            if(this.chance == 1) {
                display.Text = "패배";
                return;
            } else {
                if(inputNumber > this.findNumber) {
                    display.Text = $"실패. 정답은 더 작은 수 입니다. 남은 기회는 {this.chance}번";
                } else {
                    display.Text = $"실패. 정답은 더 큰 수 입니다. 남은 기회는 {this.chance}번";
                }
                
            }

            this.chance -= 1;

            // 수정 및 개선사항
            // 1. 틀렸습니다. 더 큰 수 입니다.
            // 2. 틀렸습니다. 더 작은 수 입니다.
        }

    }

}
