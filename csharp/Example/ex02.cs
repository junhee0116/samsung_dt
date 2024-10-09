using System;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

namespace Example
{
    internal class ex02
    {
        static void Main()
        {
            // 형변환 (type casting)            
            // ex) int(4) -> long(8)  문제 없음
            //     long(8) -> int(4)  byte가 작아져 데이터 삭제 가능성
            int myInt = 10;
            long myLong = myInt;    // 자동형변환

            long myLong2 = 1234_5678_9000;
            Console.WriteLine(myLong2);
            int myInt2 = (int)myLong2;   // 강제형변환
            // 형변환 연산자: (타입)
            Console.WriteLine(myInt2);

            // byte(1) < short(2) < int, uint(4) < long, ulong(8)
            // < float(4) < double(8)
            // int -> float: 문제없음
            // float -> int: 데이터 삭제 가능성
            int myInt3 = 10;
            float myFloat = myInt3;

            float myFloat2 = 3.14f;
            int myInt4 = (int)myFloat2;  // 실수 -> 정수 (소숫점 삭제)
            Console.WriteLine(myInt4);

            // 문자열을 숫자로 형변환
            string myString = "123";
            int myNum1 = int.Parse(myString);
            int myNum2 = Int32.Parse(myString);
            Console.WriteLine(myNum1);
            float myNum3 = float.Parse("3.14");
            Console.WriteLine(myNum3);

            // 숫자를 문자열로 형변환
            int myNum4 = 30;
            string myStr1 = myNum4.ToString();
            Console.WriteLine(myStr1);
            Console.WriteLine(myStr1.GetType().Name);



            // 연습문제
            // 1. 정수형 변수 100을 선언하고, 실수형으로 형변환 한 후에 그 변수를 출력.
            int Int1 = 100;
            float Float1 = Int1;
            Console.WriteLine("1. " + Float1 + " " + Float1.GetType().Name);

            // 강사님 풀이
            int myNumber = 100;
            float myFloatNumber = (float)myNumber;
            Console.WriteLine(myFloatNumber);
            Console.WriteLine(myFloatNumber.GetType().Name);

            // 2. 실수형 변수 3.14를 선언하고, 정수형으로 형변환 한 후에 그 변수를 출력.
            float Float2 = 3.14f;
            int Int2 = (int)Float2;
            Console.WriteLine("2. " + Int2 + " " + Int2.GetType().Name);

            // 강사님 풀이
            double myDoubleNumber = 3.14;
            Console.WriteLine(myDoubleNumber.GetType().Name);
            int myNumber2 = (int)myDoubleNumber;
            Console.WriteLine(myNumber2);
            Console.WriteLine(myNumber2.GetType().Name);

            // 3. int 타입 변수에 200을 넣어 선언하고, long 타입으로 형변환 한 후에 출력.
            int Int3 = 200;
            long Long3 = Int3;
            Console.WriteLine("3. " + Long3 + " " + Long3.GetType().Name);

            // 강사님 풀이
            int myNumber3 = 200;
            long myLongNumber = myNumber3;
            Console.WriteLine(myLongNumber);
            Console.WriteLine(myLongNumber.GetType().Name);

            // 4. long 타입 변수에 200억을 넣어 선언하고, int 타입으로 형변환 한 후에 출력.
            long Long4 = 20000000000;
            int Int4 = (int)Long4;
            Console.WriteLine("4. " + Int4 + " " + Int4.GetType().Name);

            // 강사님 풀이
            long myLongNumber2 = 20_000_000_000L;
            int myNumber4 = (int)myLongNumber2;
            Console.WriteLine(myNumber4);
            Console.WriteLine(myNumber4.GetType().Name);
        }
    }
}
