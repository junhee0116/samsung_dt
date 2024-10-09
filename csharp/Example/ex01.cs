using System;

namespace Example
{
    internal class ex01{
        // CLI: hwp.exe a.hwp b.hwp
        // ["a.hwp", "b.hwp"]
        //      : npm install express
        static void Main(string[] args)
        {
            // 변수(함수) 이름 짓는 법
            // 1. 영소문자로 시작
            // 2. Camel Case(낙타등)을 사용 (단어의 시작은 대문자로) ex) myStudentCount
            // 3. _(언더바) 외에 특수문자(! @ # $) 사용 불가
            // 4. 상수는 대문자로
            // 5. 클래스 이름은 첫글자가 대문자


            // 정수형 변수 선언
            int num = 10;
            Console.WriteLine(num);

            // 정수형 상수 선언
            // 상수: 한번 값이 정해지면 바꿀 수 없는 변수
            const double PI = 3.141592;
            Console.WriteLine(PI);
            // PI = 4.14;   상수에 값을 재할당하면 오류!

            // 논리형(Bool)
            bool myBool = true;

            // 정수형 4byte
            int myInt = 100;

            // 정수형 8byte
            long myLong1 = 200;     // int 200을 만들어서 long 형변환됨
            long myLong2 = 300L;    // long 300을 만들어서 값이 복사됨 

            // 실수형 4byte
            float myFloat = 3.14f;  // 리터럴 뒤에 f를 꼭 써야됨

            // 실수형 8byte
            double myDouble = 4.25; // 실수는 기본이 double 타입임

            // 문자형(단따옴표만)
            char myChar1 = 'a';
            char myChar2 = '가';

            // 문자열(쌍따옴표만)
            string myString = "대한민국";
        }
    }
}
