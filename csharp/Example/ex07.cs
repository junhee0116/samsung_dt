using System;
using System.Text.Json;

namespace Example {
    internal class ex07 {
        static void Main() {
            // 반복문 while
            // 초기화
            // while (조건식) {
            //      수행문
            //      증감문
            // }
            //int i = 0;
            //while (i < 5) {
            //    Console.WriteLine(i);
            //    i++;
            //}

            //// 무한루프
            //i = 0;
            //while (true) {
            //    Console.WriteLine(i);
            //    if(i > 10) {
            //        break;
            //    }
            //    i++;
            //}

            //연습문제 6
            //1. 철수와 영희가 주사위게임을 한다.
            //  주사위를 한번씩 던져서, 2나 4이면 1칸 전진, 홀수(1,3,5)이면 그 자리에,
            //  6이면 뒤로 한칸이다.
            // 앞으로 10칸을 먼저 전진하는 사람이 승리한다.
            // 이때의 게임결과를 출력하시오.
            // 출력예) 철수: 1 그자리
            //         영희: 2 1칸전진!
            //         ...
            //         영희: 4 1칸전진!
            //         영희 승!

            //Random rand = new Random();
            //int chul = 0;
            //int young = 0;
            //int i = 0;

            //while (true) {
            //    int num = rand.Next(1, 7);

            //    if (i % 2 == 0) {
            //        if (num == 2 || num == 4) {
            //            chul += 1;
            //            Console.WriteLine("철수: {0} 1칸 전진!  {1}", num, chul);
            //        } else if (num == 6) {
            //            chul -= 1;
            //            Console.WriteLine("철수: {0} 1칸 후진!  {1}", num, chul);
            //        } else {
            //            Console.WriteLine("철수: {0} 그자리  {1}", num, chul);
            //        }

            //        if (chul == 10) {
            //            Console.WriteLine("철수 승!");
            //            break;
            //        }
            //    } else {
            //        if (num == 2 || num == 4) {
            //            young += 1;
            //            Console.WriteLine("영희: {0} 1칸 전진!  {1}", num, young);
            //        } else if (num == 6) {
            //            young -= 1;
            //            Console.WriteLine("영희: {0} 1칸 후진!  {1}", num, young);
            //        } else {
            //            Console.WriteLine("영희: {0} 그 자리  {1}", num, young);
            //        }

            //        if (young == 10) {
            //            Console.WriteLine("영희 승!");
            //            break;
            //        }
            //    }
            //    i++;
            //}


            //2. 페널티킥 게임
            // 손흥민이 공을 차고, 조현우가 골키퍼를 한다.
            // 공의 방향은 왼쪽(0), 가운데(1), 오른쪽(2) 이다.
            // 랜덤하게 공을 찬다. 왼쪽으로 찰 확률은 30%, 가운데는 20%, 오른쪽은 50%로 찬다.
            // 조현우도 수비방향이 왼쪽(0), 가운데(1), 오른쪽(2) 이다.
            // 수비 확률은 왼쪽은 40%, 가운데는 30%, 오른쪽은 30%로 찬다.
            // 이때 골인인지? 방어인지? 출력하시오.

            Random rand = new Random();
            string son_direction = "";
            string jo_direction = "";

            int son = rand.Next(1, 11);

            if (son == 1 || son == 2 || son == 3) {
                son_direction = "Left";
            } else if (son == 4 || son == 5) {
                son_direction = "Center";
            } else {
                son_direction = "Right";
            }
            Console.WriteLine("손흥민 킥 - {0}", son_direction);

            int jo = rand.Next(1, 11);

            if (jo == 1 || jo == 2 || jo == 3 || jo == 4) {
                jo_direction = "Left";
            } else if (jo == 5 || jo == 6 || jo == 7) {
                jo_direction = "Center";
            } else {
                jo_direction = "Right";
            }
            Console.WriteLine("조현우 수비 - {0}", jo_direction);


            if (son_direction == jo_direction) {
                Console.WriteLine("No Goal");
            } else {
                Console.WriteLine("Goal");
            }
        }
    }
}
