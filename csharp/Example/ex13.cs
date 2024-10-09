using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example {
    internal class ex13 {
        static void Main() {
            Book book = new Book();
            Console.WriteLine(book.price);
            Book book2 = new Book(2000);
        }
    }
    // 생성자함수 : 클래스객체 생성시 자동으로 호출되는 함수
    // 용도: 값의 초기화
    class Book {
        public int price = 1000; //속성

        //생성자함수는 public이고, 반환형이 없음. 이름은 클래스이름과 동일
        public Book() {
            Console.WriteLine("생성자함수 호출됨.");
        }
        //메소드 오버로딩 : 매개변수의 타입과 갯수를 다르게 함으로
        //                  동일한 함수이름을 사용하도록 허락하는 것.
        public Book(int price) { 
            this.price = price;
        }
        void read() { //행동
            //읽는다.
        }
    }

}
