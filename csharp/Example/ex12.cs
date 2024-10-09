using System;
using System.Collections.Generic;


namespace Example {
    internal class ex12 {
        static void Main() {
            CoffeeRobot cRobot = new CoffeeRobot();
            cRobot.work(); //부모의 자산을 자식이 물려받은 것.
            Console.WriteLine(cRobot.price);

            cRobot.make();
        }
    }
    //클래스의 상속 : 부모클래스의 자산(변수,함수)을 자식클래스에서 넘겨줌.
    //공통된 클래스를 이용하여, 코드중복을 줄이거나 체계적인 코드 작성에 용이함.
    class Robot {
        public int price = 1000; //속성
        public void work() {//행동
            Console.WriteLine("일한다.");
        }
    }
    //Robot을 상속
    class CoffeeRobot : Robot{
        public string name = "커피로봇";
        public void make() {
            Console.WriteLine("커피를 만든다.");
        }
    }
    class DeliveryRobot : Robot {
        public string name = "배달로봇";
        public void delivery() {
            Console.WriteLine("배달한다.");
        }
    }


}
