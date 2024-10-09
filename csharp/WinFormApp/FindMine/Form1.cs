using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMine {
    public partial class Form1 : Form {
        //배열,List,ArrayList
        List<Button> btnList = new List<Button>();
        int[,] map = new int[10, 10];

        int mineCount = 0;
        int foundNumber = 0;

        //생성자함수 : 클래스생성시 자동호출
        public Form1() {
            InitializeComponent();
            //게임초기화
            initGame();
        }
        private void initGame() { //게임초기화
            for(int i = 1; i <= 100; i++) {
                //버튼을 이름으로 찾아서 리스트에 추가
                Control[] controls = this.Controls.Find("button" + i, true);
                if(controls.Length > 0 && controls[0] is Button) {
                    btnList.Add((Button)controls[0]);
                }
            }
            // display.Text = "찾은 버튼 갯수" + btnList.Count;
            foreach(Button btn in btnList) {
                btn.Text = "";
                //버튼이벤트 연결
                btn.Click += new EventHandler(onButtonClick);
            }
            // 1. 2차배열 map = new int[10][10]
            //    폭탄의 위치값을 가진다.

            // 2. 10 X 10에 랜덤한 위치에 0 ~ 9, 0 ~ 9 랜덤수를 2번 뽑는다.
            //   폭탄을 map 데이터에 업데이트 한다.
            Random random = new Random();

            // 20개의 지뢰 설치
            for(int i = 0; i < 20; i++) { 
                int randomRow = random.Next(0, 9);
                int randomCol = random.Next(0, 9);
                map[randomRow, randomCol] = 1; //지뢰 설치
            }
            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    Console.Write(map[i, j] + ",");
                    if(map[i, j] == 1) {
                        mineCount++;
                    }
                }
                Console.WriteLine();
            }

            // 3. 클릭이벤트에서 버튼 클릭시
            //   1) 숫자를 보여주거나
            //   2) 지뢰가 터진다. "실패한다." -> 버튼에 폭탄이미지 보여주기

            // 4. 모든 숫자를 보여주면, "승리한다." ->버튼에 폭탄이미지 보여주기

        }
        // 100개의 모든 버튼의 클릭 이벤트를 받는다.
        // sender : 이벤트을 보낸 컨트롤(Button)
        // e : 이벤트 정보
        private void onButtonClick(object sender, EventArgs e) {
            //클릭된 버튼 가져오기
            Button clickedBtn = (Button)sender;
            //MessageBox.Show(clickedBtn.Name + "이 클릭됨");
            Console.WriteLine("클릭된 버튼 Name:" + clickedBtn.Name);


            // "button1"의 row,col 인덱스를 가져오기
            // button1 row 0, col 0
            // 1 ~ 100까지의 값을 row값, col값
            // row값 : 10의 몫, col값 : 10의 나머지

            // "button1" 문자열에서 "1"만 가져와서 숫자로 바꿈
            // "button10"에서 "button"문자열 제거
            string buttonNum = clickedBtn.Name.Substring(6);

            // 문자를 숫자로 변환
            int buttonNumInt = int.Parse(buttonNum);
            Console.WriteLine("buttonNumInt: " + buttonNumInt);

            int row = (buttonNumInt - 1) / 10;
            int col = (buttonNumInt - 1) % 10;
            Console.WriteLine($"{row},{col}");

            //자신이 폭탄인 경우
            if(map[row, col] == 1) {
                display.Text = "게임 실패";
                //버튼에 폭탄이미지 보여주기
                clickedBtn.BackgroundImage = Properties.Resources.bomb;
                clickedBtn.BackgroundImageLayout = ImageLayout.Stretch;
                return;
            }

            //팔방의 폭탄의 갯수를 세기
            int mineCount = 0;

            //왼쪽 위
            if(row > 0 && col > 0) {
                if(map[row - 1, col - 1] == 1) {
                    mineCount++;
                }
            }
            //왼쪽 중간
            if (col > 0) {
                if(map[row, col - 1] == 1) {
                    mineCount++;
                }
            }
            //왼쪽 아래
            if(row < 9 && col > 0) {
                if(map[row + 1, col - 1] == 1) {
                    mineCount++;
                }
            }
            //윗쪽
            if(row > 0) {
                if(map[row - 1, col] == 1) {
                    mineCount++;
                }
            }
            //오른쪽 위
            if(row > 0 && col < 9) {
                if(map[row - 1, col + 1] == 1) {
                    mineCount++;
                }
            }
            //오른쪽 중간
            if(col < 9) {
                if(map[row, col + 1] == 1) {
                    mineCount++;
                }
            }
            //오른쪽 아래
            if (row < 9 && col < 9) {
                if (map[row + 1, col + 1] == 1) {
                    mineCount++;
                }
            }
            //아랫쪽
            if (row < 9) {
                if (map[row + 1, col] == 1) {
                    mineCount++;
                }
            }

            Console.WriteLine("지뢰의 갯수:" + mineCount);
            clickedBtn.Text = mineCount.ToString();
            foundNumber++;

            //게임판정
            if (100 - this.mineCount == foundNumber) {
                display.Text = "모든 지뢰를 찾았습니다! 성공!";
            }
        }
    }
}