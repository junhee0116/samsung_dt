using System;

namespace Example {
    internal class ex05 {
        static void Main() {
            // 조건문 if문 switch문
            // 1. 단일 if 문
            // if (조건식) {
            //     true 일 때만 수행되는 수행문
            // }
            
            if (true) {
                Console.WriteLine("조건식이 true");
            }

            if (10 == 20) {
                Console.WriteLine("실행되지 않음");
            }

            // 2. if else 문
            // 패턴
            // if (조건식) {
            //      true 일 때 수행
            // } else {
            //      false 일 때 수행
            // }
            if (10 == 20) {
                Console.WriteLine("True");
            } else {
                Console.WriteLine("False");
            }

            // 3. if else if 문
            int num = 30;
            if (num == 10) {
                Console.WriteLine("10 입니다");
            } else if (num == 20) {
                Console.WriteLine("20 입니다");
            } else if (num == 30) {
                Console.WriteLine("30 입니다");
            } else {
                Console.WriteLine("그 외의 수입니다");
            }

            // 4. 중첩 if 문
            if (true) {
                if (true) {

                }
            }



            //랜덤한 정수 생성하기
            //Random 클래스: 랜덤한 수를 생성해주는 클래스
            // rand: 클래스로부터 생성된 객체
            // new: 객체를 생성하는 예약어
            // Random(): 클래스 이름과 동일한 생성자 함수
            // 클래스 안에는 변수와 메소드가 있다
            //Random rand = new Random();
            //int randNum = rand.Next(1, 100);    // 1부터 100 사이의 랜덤한 정수 발생!
            //Console.WriteLine(randNum);



            // 연습문제4
            // 1. 철수와 영희가 각각 주사위를 2번씩 던져서, 주사위의 수의 합이 더 큰 사람이 승리하게 되고 누가 승리하는지 출력
            // 입력예) 주사위값 4개
            // 출력예) 영희 승! or 철수 승!

            Random rand = new Random();
            int result1 = 0;
            int result2 = 0;

            for (int i = 0; i < 4; i++) {
                int dice1 = rand.Next(1, 7);
                int dice2 = rand.Next(1, 7);

                Console.WriteLine("{0} {1}", dice1, dice2);

                result1 += dice1;
                result2 += dice2;
            }

            if(result1 > result2) {
                Console.WriteLine("철수 승!");
            } else if(result1 == result2) {
                Console.WriteLine("무승부!");
            } else {
                Console.WriteLine("영희 승!");
            }

            // 2. 랜덤한 정수 (0 ~ 9)를 2개 뽑아서 첫번째 정수는 십의 자리로, 두 번째 정수는 일의 자리로 생성하여 출력
            // 입력예) 랜덤한 정수 2개 1, 3
            // 출력예) 13

            //Random rand = new Random();

            //int num1 = rand.Next(0, 10);
            //int num2 = rand.Next(0, 10);

            //Console.WriteLine("랜덤한 정수 2개 {0}, {1}", num1, num2);
            //Console.WriteLine(num1 * 10 + num2);


            // 3. 1 ~ 100의 랜덤한 정수를 하나 발생시키고
            // 90점이상이면 "A" 80점이상이면 "B" 70점이상이면 "C" 60점이상이면 "D" 그외의 수이면 "E" 라고 출력
            // 입력예) 88
            // 출력예) B

            //Random rand = new Random();

            //int num = rand.Next(1, 101);

            //Console.WriteLine(num);

            //if (num >= 90) {
            //    Console.WriteLine("A");
            //} else if (num >= 80) {
            //    Console.WriteLine("B");
            //} else if (num >= 70) {
            //    Console.WriteLine("C");
            //} else if (num >= 60) {
            //    Console.WriteLine("D");
            //} else {
            //    Console.WriteLine("E");
            //}

            //4. 교대로 주사위를 계속 던져(무한 루프) 같은 주사위의 값이 먼저 나온 사람이 승리하게 된다. 누가 먼저 승리하는지 출력
            // 출력예) 철수 4
            //         영희 5
            //         철수 4
            //         철수 승!

            //Random rand = new Random();
            //int before_num1 = 0;
            //int before_num2 = 0;
            //int i = 0;

            //while (true) {
            //    int num = rand.Next(1, 7);

            //    if (i % 2 == 0) {
            //        Console.WriteLine("철수 " + num);
            //        if (num == before_num1) {
            //            Console.WriteLine("철수 승!");
            //            break;
            //        }
            //        before_num1 = num;
            //    } else {
            //        Console.WriteLine("영희 " + num);
            //        if (num == before_num2) {
            //            Console.WriteLine("영희 승!");
            //            break;
            //        }
            //        before_num2 = num;
            //    }
            //    i++;
            //}


            // 5. 100제 - 34번
            // 0 ~ 9의 정수값을 차례로 3개 발생시키고 그 값을 반대로 출력하시오.(ArrayList나 배열 사용)

            // Generic: 클래스 안에 데이터 타입을 다양하게 넣는 것
            // 배열 Array(Non-Generic)
            // 리스트 List(Generic)
            // 리스트 ArrayList(Non-Generic)
            // 배열: int[] student = new int[6];
            // 리스트: ArrayList<int> list = new ArrayList(); list.add(3);
            // 입력예) 3 6 8
            // 출력예) 8 6 3

            //Random rand = new Random();
            //ArrayList numbers = new ArrayList();

            //for (int i = 0; i < 3; i++) {
            //    int num = rand.Next(10);
            //    numbers.Add(num);
            //    Console.Write(num + " ");
            //}
            //Console.WriteLine();
            //for (int i = numbers.Count; i > 0; i--) {
            //    Console.Write(numbers[i - 1] + " ");
            //}

        }
    }
}
