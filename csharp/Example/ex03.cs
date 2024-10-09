using System;

namespace Example
{
    internal class ex03
    {
        static void Main()
        {
            /// 콘솔로부터 입력받기
            Console.Write("입력하세요: ");   // WriteLine - 줄바꿈 O, Write - 줄바꿈 X
            string input = Console.ReadLine();
            Console.WriteLine(input);       // string
            int myInt = int.Parse(input);
            Console.WriteLine(myInt * 2);   // int

            // 문자열 보간
            int myNum = 10;
            string msg = $"myNum의 값은 {myNum}입니다.";
            Console.WriteLine(msg);


            // 연습문제
            // 1. 콘솔로부터 정수 1개를 입력받고, 그 수에 10을 곱한 수를 출력.
            // 입력예) 10
            // 출력예) 100

            int Int1 = int.Parse(Console.ReadLine());
            Console.WriteLine(Int1 * 10);

            //2. 콘솔로부터 정수 1개를 입력받고 (1~100까지 중 하나), 그 수가 짝수이면 "짝수", 홀수이면 "홀수"라고 출력.
            // 힌트) %연산자 이용
            // 입력예) 5
            // 출력예) 홀수

            int Int2 = int.Parse(Console.ReadLine());

            if (Int2 % 2 == 0) {
                Console.WriteLine("짝수");
            } else {
                Console.WriteLine("홀수");
            }

            // 3. 콘솔로부터 문자열 2개를 입력받고, 합쳐서 출력.
            // 힌트) +연산자 이용
            // 입력예) 대한
            //         민국
            // 출력예) 대한민국

            string Str1 = Console.ReadLine();
            string Str2 = Console.ReadLine();
            Console.WriteLine(Str1 + Str2);

            // 4. 콘솔로부터 정수 1개를 입력받고, 문자열 보간을 이용하여 출력.
            // 입력예) 20
            // 출력예) 입력된 숫자는 20입니다.

            int Int4 = int.Parse(Console.ReadLine());
            Console.WriteLine($"입력된 숫자는 {Int4}입니다.");
        }
    }
}
