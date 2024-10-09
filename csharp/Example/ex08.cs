using System;
using System.Collections.Generic;

namespace Examples {
    internal class ex08 {
        //메인 함수
        static void Main() {
            //함수안에서 함수를 선언/정의하면 안됨.

            myFunc();

            myFunc1();
            myFunc2( 10 );

            string result = myFunc3();
            Console.WriteLine( result );

            float dimension = myFunc4(10, 20);
            Console.WriteLine( dimension ); 
        }

        //서브 함수(사용자정의 함수) 선언
        //패턴
        //반환타입 함수이름( 매개변수 ){
        //   실행문...
        //}
        //void : 반환타입(값)이 없음을 의미
        //static 함수에서는 static 함수만 호출가능 
        static void myFunc() {
            Console.WriteLine("myFunc() 호출됨");
        }

        //static : 정적(고정), 코드 호출시에 고정된 주소값을 가지는 것을 의미
        //       : 안정적인 코드 수행이 가능(시작점, 전역변수, 중요한 변수나 데이터)

        //함수의 4가지 패턴
        //매개변수 X 반환값 X
        static void myFunc1() {
            Console.WriteLine("myFunc1() 호출됨");
        }
        //매개변수 O 반환값 X 
        static void myFunc2(int param) {
            Console.WriteLine("myFunc2() 호출됨");
            Console.WriteLine($"매개변수 {param}");
           
        }
        //매개변수 X 반환값 O
        static string myFunc3() {
            Console.WriteLine("myFunc3() 호출됨");
            return "하이";
        }

        //매개변수 O 반환값 O
        static float myFunc4(int width, int height) {
            return width * height; 
        }
            
    }
}