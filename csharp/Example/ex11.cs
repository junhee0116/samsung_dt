using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Example {
    //클래스 선언
    //객체지향 프로그래밍(OOP, Object Oriented Programming)
    //사물을 클래스로 추상화(코드화)하는 것
    //예) 강아지 : 속성(변수)과 행동(함수)

    //접근제한자
    //public : 다른 클래스에서 자신의 변수나 함수에 접근하게 열어줌. 공개한다는 의미.
    //private : 기본값(생략시), 자신만 변수나 함수를 사용가능.
    class Dog {
        public string name = "까미";
        public  void eat() {
            Console.WriteLine("먹는다");
        }
    }
    //메인 클래스
    internal class ex11 {
        static void Main() {
            //클래스를 메모리에 옮겨놓아야 실행가능하다.
            //객체(인스턴스)를 생성한다.

            //클래스 변수이름 = new 클래스();
            Dog dog = new Dog();
            //변수(객체)이름 뒤에 점.을 찍으면 변수와 함수에 접근 가능하다.
            Console.WriteLine(dog.name);
            //Console.WriteLinedog.eat()); //eat의 반환값이 void는 출력할 수 없다.
            dog.eat();

            Student student = new Student();
            Console.WriteLine($"문제1번은 {student.age}이다.");
            student.study();

            Farm farm = new Farm();
            Console.WriteLine($"문제2번은 {farm.carrotNum}이다.");
            farm.plant();

            Calc Calc = new Calc();
            Console.WriteLine($"문제3번에서 더하기의 값은 {Calc.Sum(10,5)}이다");
            Console.WriteLine($"문제3번에서 빼기의 값은 {Calc.Sub(10, 5)}이다");
            Console.WriteLine($"문제3번에서 곱하기의 값은 {Calc.Mul(10, 5)}이다");
            Console.WriteLine($"문제3번에서 나누기의 값은 {Calc.Div(10, 5)}이다");

            //강사님의 풀이
            //Student student = new Student();
            //student.study();
            //Console.WriteLine(student.age);

            //Farm farm = new Farm();
            //farm.plant(); farm.plant(); farm.plant(); farm.plant(); farm.plant();
            //Console.WriteLine(farm.getCarrotCount());

            //Calc calc = new Calc();
            //calc.sum(10, 20);
            //Console.WriteLine(calc.result);

        }
    }
    //연습문제 8 
    //1. 학생 Student 클래스를 설계해보자.
    // 학생의 속성은 int age(초기값 20), 학생은 행동은 study() 공부한다.
    // student객체를 생성하고, 속성과 행동을 출력하시오.

    class Student {
        public int age = 20;
        public void study() {
            Console.WriteLine("영어공부를 한다.");
        } 
    }

    //강사님 풀이
    //class Student {
    //    public int age = 20;
    //    public void study() {
    //        Console.WriteLine("공부한다.");
    //    }
    //}

    //2. 당근농장 Farm 클래스를 설계해보자.
    //  속성(변수)로 당근의 갯수를 가지고 있다. 초기값 0
    //  행동(함수)로 plant(생산)함수를 호출하면, 자신이 가지고 있는 당근의 갯수를 +1한다.
    // plant함수를 5번 실행한 후에, 당근의 갯수를 출력하시오.
    class Farm {
        public int carrotNum = 0;
        public void plant() {
            for (int i = 0; i < 5; i++) {
                carrotNum++;
            }
            Console.WriteLine(carrotNum);
        }
    }

    //강사님 풀이
    //class Farm() {
    //    //멤버 변수
    //    private int carrot = 0;  //외부에 자신의 중요한 값을 감춘다. 캡슐화(은닉)한다.

    //    //getter함수
    //    public int getCarrotCount() {
    //        return carrot;
    //    }
    //    //setter함수
    //    public void setCarrotCount(int carrot) {
    //        //this : 자신의 클래스를 의미함.
    //        this.carrot = carrot;
    //    }

    //    public void plant() {
    //        carrot++;
    //    }
    //}

    //3. 계산기 Calc 클래스를 설계해보자.
    // 속성(변수)로 결과값 double타입을 가지고 있고,
    // sum, sub, mul, div (더하기,빼기,곱하기,나누기)를 수행한다.
    // 매개변수는 double형 2개이고, 반환형은 double이다.
    // Calc 클래스 객체를 사용하여, 사칙연산을 수행해 보자.
    class Calc {
        public double Sum(double x, double y) {
            return x + y;
        }
        public double Sub(double x, double y) {
            return x - y;
        }    
        public double Mul(double x, double y) {
            return x * y;
        }
        public double Div(double x, double y) {
            return x / y;
        }
    }

    //강사님 풀이
    //class Calc {
    //    public double result = 0.0;
    //    public void sum(double x, double y) {
    //        this.result = x + y;
    //    }
    //    public void sub(double x, double y) {
    //        this.result = x - y;
    //    }
    //    public void mul(double x, double y) {
    //        this.result = x * y;
    //    }
    //    public void div(double x, double y) {
    //        this.result = x / y;
    //    }
    }
