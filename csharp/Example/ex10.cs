using System;
using System.Collections;


namespace Example {
    internal class ex10 {
        static void Main() {
            //배열 Array : 동일한 타입의 데이터를 순차적으로 나열한 데이터 구조이다.
            int[] arrayNum = [10, 20, 30];
            int[] arrayNum2 = { 10, 20, 30 };
            int[] arrayNum3 = new int[3];
            arrayNum3[0] = 10;

            int[][] array2DNum = [[10, 20], [30, 40]];
            int[][] array2DNum2 = new int[3][];
            array2DNum2[0] = [10, 20, 30];
            array2DNum2[1] = [40, 50, 60];
            array2DNum2[2] = [70, 80, 90];

            //콜렉트(모음) : List, ArrayList, Queue, Stack, HashTable, Dictionary
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            foreach (int n in list) {
                Console.WriteLine(n);
            }
            for (int i = 0; i < list.Count; i++) {
                Console.WriteLine(list.ElementAt(i));
            }

            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add("20");
            arrayList.Add(3.14f);
            arrayList.Add(true);
            //var : 타입이 고정되지 않는 변수형
            foreach (var item in arrayList) {
                //object타입으로 arraylist는 저장한다.
                if (typeof(int) == item.GetType()) {
                    Console.WriteLine("int타입입니다.");
                    int num = Convert.ToInt32(item);
                    Console.WriteLine(num);
                }
                if (typeof(string) == item.GetType()) {
                    Console.WriteLine("string타입입니다.");
                }

                Console.WriteLine(item);
            }
            // 큐 Queue : FIFO(First IN First Out) 타입의 데이터 구조
            //            먼저 들어간 데이터가 먼저 나온다.
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            while (queue.Count > 0) {
                Console.WriteLine(queue.Dequeue());
            }

            //스택 Stack : FIFO(First IN Last Out)
            //             먼저 들어간 데이터가 맨 나중에 나옴
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            while (stack.Count > 0) {
                Console.WriteLine(stack.Pop());
            }

            //해쉬테이블 HashTable
            //해쉬 : Hash 암호화(인덱싱)된 키를 통해서 일정한 인덱스를 만드는 것.
            //해쉬테이블 : 키와 값으로 구성됨.
            Hashtable ht = new Hashtable();
            ht["apple"] = "사과";
            ht["banana"] = "바나나";
            ht["orange"] = "오렌지";

            //키를 참조하여 값을 가져온다.
            Console.WriteLine(ht["apple"]);
            Console.WriteLine(ht["banana"]);
            Console.WriteLine(ht["orange"]);

            //딕셔너리(사전) Dictionary : 키와 값을 구성되어 있음.
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("사과",1000);
            dic.Add("단감", 2000);
            Console.WriteLine(dic["사과"]);
            Console.WriteLine(dic["단감"]);

            //예외 처리하기
            //오류 발생시 처리하는 코드를 추가할 수 있다.
            Console.Write("나눌 숫자를 입력하세요 : ");
            int divider = int.Parse(Console.ReadLine());
            try {
                //오류가 발생될만한 코드
                Console.WriteLine(10 / divider); //0으로 나누면 오류 발생!
            } catch (Exception e) {
                //오류 발생시 실행되는 코드
                Console.WriteLine("예외 상황 : " + e.Message);
            }

        }
    }
}
