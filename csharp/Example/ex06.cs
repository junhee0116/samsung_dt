using System;



namespace Example {
    internal class ex06 {
        static void Main() {
            // 반복문 for, while
            // for(초기화; 조건식; 증감문) {
            //      수행문;
            // }
            //for(int i = 0; i < 5; i++) {
            //    Console.WriteLine(i);
            //}

            // 중괄호를 생략하는 경우 - 수행문이 한줄일때만
            //for(int i = 0; i < 5; i++)
            //    Console.WriteLine(i);
            //    Console.WriteLine(10);

            //if (10 < 20)
            //    Console.WriteLine("10 < 20");
            //Console.WriteLine("10 > 20");

            // 연습문제 5
            // 1. 반복변수 i를 1부터 100까지 출력
            //for (int i = 1; i <= 100; i++) {
            //    Console.WriteLine(i);
            //}

            //2. 반복변수 i를 1부터 100사이의 짝수만 출력
            //for (int i = 1; i <= 100; i++) {
            //    if (i % 2 == 0) {
            //        Console.WriteLine(i);
            //    }
            //}

            // 3. 10부터 - 10까지 출력
            //for (int i = 10; i >= -10; i--) {
            //    Console.WriteLine(i);
            //}

            // 4. 1부터 100사이의 수 중에서 3이나 6이나 9가 포함된 수만 출력
            // 출력예) 3, 6, 9, ... 3, 33 ... 99
            //for (int i = 1; i <= 100; i++) {
            //    if ((i % 30 == 0) || (i % 60 == 0) || (i % 90 == 0) || (i % 10 == 3) || (i % 10 == 6) || (i % 10 == 9)) {
            //        Console.Write(i + " ");
            //    }
            //}


            // 5. 1부터 100사이의 2의 배수이거나 3의 배수인 수의 갯수를 출력
            //int Count = 0;
            //for (int i = 1; i <= 100; i++) {
            //    if ((i % 2 == 0) || (i % 3 == 0)) {
            //        Count += 1;
            //    }
            //}

            //Console.WriteLine(Count);

            //6. 10의 약수의 갯수와 그 약수를 출력
            // 출력예) 10의 약수는 1 2 5 10 
            //int num = 10;

            //for (int i = 1; i <= num; i++) {
            //    if (num % i == 0) {
            //        Console.Write(i + " ");
            //    }
            //}

            //7. 2부터 100사이의 랜덤한 정수를 발생시키고, 그 수가 소수인지 아닌지 판별(소수는 약수의 갯수가 2개)
            // 출력예) 7은 소수입니다.
            //         10은 소수가 아닙니다.

            //Random rand = new Random();
            //ArrayList numbers = new ArrayList();

            //int num = rand.Next(2, 101);

            //for (int i = 1; i <= num; i++) {
            //    if (num % i == 0) {
            //        numbers.Add(i);
            //    }
            //}

            //if (numbers.Count == 2) {
            //    Console.WriteLine("{0}은 소수입니다", num);
            //} else {
            //    Console.WriteLine("{0}은 소수가 아닙니다", num);
            //}

