using System;
using System.Collections;

namespace Example {
    internal class ex04 {
        static void Main() {
            // 연산자
            //int num1 = 10;
            //int num2 = 3;

            //// 산술연산자: + - * / %
            //Console.WriteLine(num1 + num2);
            //Console.WriteLine(num1 - num2);
            //Console.WriteLine(num1 * num2);
            //Console.WriteLine(num1 / num2);
            //Console.WriteLine(num1 % num2);

            //// 증감연산자: ++ --
            //num1 = 10;
            //num2 = 3;
            //Console.WriteLine(num1++); 
            //Console.WriteLine(num1);
            //// 뒷++은 자신의 항목 뒤에 연산
            //Console.WriteLine(num1++ + num1);
            //Console.WriteLine(num1);
            //// ++, -- 연산자는 가급적 한 줄에 여러개 쓰지 않는다
            //Console.WriteLine(num1--);
            //Console.WriteLine(num1);

            //// 관계(비교)연산자: == != < > <= >=
            //num1 = 10;
            //num2 = 3;
            //Console.WriteLine(num1 == num2);
            //Console.WriteLine(num1 != num2);
            //Console.WriteLine(num1 < num2);
            //Console.WriteLine(num1 > num2);
            //Console.WriteLine(num1 <= num2);
            //Console.WriteLine(num1 >= num2);

            //// 논리연산자: &&(and), ||(or), !(not)
            //Console.WriteLine(true && true);
            //Console.WriteLine(true && false);
            //Console.WriteLine(false && true);
            //Console.WriteLine(false && false);

            //Console.WriteLine(true || true);
            //Console.WriteLine(true || false);
            //Console.WriteLine(false || true);
            //Console.WriteLine(false || false);

            //Console.WriteLine(!true);
            //Console.WriteLine(!false);

            //// 삼항연산자: ? :
            //Console.WriteLine(10 % 2 == 0 ? "짝수" : "홀수");

            //// 대입연산자: =
            //num1 = 10;

            //// 복합대입연산자: += -= *= /=
            //num1 += 10;
            //Console.WriteLine(num1);

            //// null: 값이 없는 것을 의미함. 메모리에 할당 안됨
            ////     : 값 대입 불가, 연산 불가, 0도 아님.

            //// null 조건부연산자: ?. ?[]
            //ArrayList list = null;
            //// list.Add("야구")      // null 오류 발생
            //list?.Add("야구");       // list가 null이면 Add 함수를 수행하지 않음.
            //Console.WriteLine(list?.Count);

            //list = new ArrayList();
            //list?.Add("야구");
            //list?.Add("축구");
            //Console.WriteLine(list?.Count);
            //Console.WriteLine(list[0]);
            //Console.WriteLine(list[1]);

            ////null병합 연산자 : ??
            ////nullable 타입 : int? , null일수도 있는 타입을 의미

            ////a ?? 0의 의미:
            ////만약 a가 null이면 0을 반환.
            ////만약 a에 값이 있으면 그 값을 반환.
            //int? a = null;
            //Console.WriteLine($"{a ?? 0}"); // a는 null이므로 0 출력

            //a = 99;
            //Console.WriteLine($"{a ?? 0}"); // a는 null이 아니므로 99 출력


            // 연습문제
            // 1. 정수형 변수 하나를 선언하고 123으로 초기화하고 백의 자릿수와 십의 자릿수, 일의 자릿수를 구하여 출력
            // 출력예) 백의 자릿수: 1
            //         십의 자릿수: 2
            //         일의 자릿수: 3
            int Int1 = 123;
            Console.WriteLine($"백의 자릿수: {Int1 / 100}");
            Console.WriteLine($"십의 자릿수: {(Int1 % 100) / 10}");
            Console.WriteLine($"일의 자릿수: {Int1 % 10}");

            // 2. 콘솔로부터 정수 2개를 입력받고 더 큰 수를 출력
            // 입력예) 10
            //         20
            // 출력예) 20
            int Int2_1 = int.Parse(Console.ReadLine());
            int Int2_2 = int.Parse(Console.ReadLine());

            if (Int2_1 > Int2_2) {
                Console.WriteLine(Int2_1);
            } else if (Int2_1 < Int2_2) {
                Console.WriteLine(Int2_2);
            } else {
                Console.WriteLine("Equal");
            }

            // 3. 콘솔로부터 10자 미만의 문자열을 입력받고 null이 아니라면 문자열의 길이를 출력
            string Str3 = Console.ReadLine();
            Console.WriteLine(Str3?.Length);
            
            // 4. string input = null로 선언하고 input이 null이라면 기본값 "null값입니다."를 출력
            string Str4 = null;
            Console.WriteLine(Str4 ?? "null값입니다");
        }
    }
}
