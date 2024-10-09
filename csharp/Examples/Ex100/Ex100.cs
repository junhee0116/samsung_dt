using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks.Sources;

namespace Examples.Ex100 {
    internal class Ex100 {
        static void Main(string[] args) {
            // ex01
            //Console.WriteLine("Hello");

            // ex02
            // Console.WriteLine("Hello World");

            // ex03
            // Console.WriteLine("Hello\n\nWorld");

            // ex04
            // Console.WriteLine("'Hello'");

            // ex05
            // Console.WriteLine("\"Hello World\"");

            // ex06
            // Console.WriteLine("C:\\Download\\hello.java");

            // ex07
            // int input;
            // input = int.Parse(Console.ReadLine());
            // Console.WriteLine(input);

            // ex08
            // string input = Console.ReadLine();
            // Console.WriteLine(input);

            // ex09
            // float input;
            // input = float.Parse(Console.ReadLine());
            // Console.WriteLine(input);

            // ex10
            // int a, b;
            // a = int.Parse(Console.ReadLine());
            // b = int.Parse(Console.ReadLine());
            // Console.WriteLine("{0} {1}", a, b);

            // ex11
            // string a = Console.ReadLine();
            // string b = Console.ReadLine();
            // Console.WriteLine("{1} {0}", a, b);

            // ex12
            // string input = Console.ReadLine();
            // Console.WriteLine(input);

            // ex13
            // float input;
            // input = float.Parse(Console.ReadLine());
            // Console.WriteLine($"{input.ToString("n2")}");

            // ex14
            // int hour, minute;
            // hour = int.Parse(Console.ReadLine());
            // minute = int.Parse(Console.ReadLine());
            // Console.WriteLine("{0}:{1}", hour, minute);

            // ex15
            // int Year = int.Parse(Console.ReadLine());
            // int Month = int.Parse(Console.ReadLine());
            // int Day = int.Parse(Console.ReadLine());
            // Console.WriteLine(string.Format("{0}.{1:00}.{2:00}", Year, Month, Day));

            // ex16
            //int Num1 = int.Parse(Console.ReadLine());
            //Console.WriteLine(Convert.ToString(Num1, 8));

            // ex17
            //int Num1 = int.Parse(Console.ReadLine());
            //Console.WriteLine(Convert.ToString(Num1, 16));

            // ex18
            //string Str = Console.ReadLine();
            //Console.WriteLine(Convert.ToInt32(Str[0]));

            // ex19
            //int Int = int.Parse(Console.ReadLine());
            //Console.WriteLine(Convert.ToChar(Int));

            //// ex20
            //int num1 = int.Parse(Console.ReadLine());
            //int num2 = int.Parse(Console.ReadLine());
            //int num3 = int.Parse(Console.ReadLine());

            //double result = num1 + num2 + num3;

            //Console.WriteLine(result);
            //Console.WriteLine(string.Format("{0:F1}", (result / 3)));

            // ex21
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());

            //Console.WriteLine(a * Math.Pow(2, b));

            // ex22
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());

            //if (a > b) {
            //    Console.WriteLine("1");
            //} else {
            //    Console.WriteLine("0");
            //}

            // ex23
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());

            //if (a == b) {
            //    Console.WriteLine("1");
            //} else {
            //    Console.WriteLine("0");
            //}

            // ex24
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());        

            //if (b >= a) {
            //    Console.WriteLine("1");
            //} else {
            //    Console.WriteLine("0");
            //}

            // ex25
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());        

            //if (a != b) {
            //    Console.WriteLine("1");
            //} else {
            //    Console.WriteLine("0");
            //}

            // ex26
            //bool Bool = bool.Parse(Console.ReadLine());

            //Console.WriteLine(!Bool);

            // ex27
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());

            //Console.WriteLine(a >= b ? a : b);


            // ex28
            //List<int> numbers = new List<int>();

            //int num1 = int.Parse(Console.ReadLine());
            //int num2 = int.Parse(Console.ReadLine());
            //int num3 = int.Parse(Console.ReadLine());

            //numbers.Add(num1);
            //numbers.Add(num2);
            //numbers.Add(num3);

            //for (int i = 0; i < numbers.Count; i++) {
            //    if (numbers[i] % 2 == 0) {
            //        Console.WriteLine(numbers[i]);
            //    }



            // ex29
            //List<int> numbers = new List<int>();

            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());
            //int c = int.Parse(Console.ReadLine());

            //numbers.Add(a);
            //numbers.Add(b);
            //numbers.Add(c);

            //for (int i = 0; i < numbers.Count; i++) {
            //    if (numbers[i] % 2 == 0) {
            //        Console.WriteLine("even");
            //    } else {
            //        Console.WriteLine("odd");
            //    }
            //}

            // ex30
            //int num = int.Parse(Console.ReadLine());

            //if (num < 0) {
            //    Console.WriteLine("minus");
            //} else if (num > 0) {
            //    Console.WriteLine("plus");
            //} else if (num == 0) {
            //    Console.WriteLine("0은 입력이 불가합니다");
            //}

            //if (num % 2 == 0) {
            //    Console.WriteLine("even");
            //} else {
            //    Console.WriteLine("odd");
            //}


            // ex31.
            //int score = int.Parse(Console.ReadLine());

            //if (score >= 90 && score <= 100) {
            //    Console.WriteLine("A");
            //} else if (score >= 70 && score < 89) {
            //    Console.WriteLine("B");
            //} else if (score >= 40 && score < 69) {
            //    Console.WriteLine("C");
            //} else if (score >= 0 && score < 39) {
            //    Console.WriteLine("D");
            //} else {
            //    Console.WriteLine("범위를 벗어난 숫자입니다");
            //}


            //// ex32.
            //string Str = Console.ReadLine();

            //switch (Str) {
            //    case "D":
            //        Console.WriteLine("Slowly~");
            //        break;
            //    case "C":
            //        Console.WriteLine("Run!");
            //        break;
            //    case "B":
            //        Console.WriteLine("Good!!");
            //        break;
            //    case "A":
            //        Console.WriteLine("Best!!!");
            //        break;
            //    default:
            //        Console.WriteLine("What?");
            //        break;
            //}

            // ex33.
            //int Month = int.Parse(Console.ReadLine());

            //switch (Month) {
            //    case 12:
            //    case 1:
            //    case 2:
            //        Console.WriteLine("Winter");
            //        break;
            //    case 3:
            //    case 4:
            //    case 5:
            //        Console.WriteLine("Spring");
            //        break;
            //    case 6:
            //    case 7:
            //    case 8:
            //        Console.WriteLine("Summer");
            //        break;
            //    case 9:
            //    case 10:
            //    case 11:
            //        Console.WriteLine("Fall");
            //        break;
            //}


            //// ex34.
            //while(true) {
            //    int num = int.Parse(Console.ReadLine());

            //    if (num == 0) {
            //        break;
            //    } else {
            //        Console.WriteLine(num);
            //    }
            //}


            // ex35.
            //int num = int.Parse(Console.ReadLine());
            //int sum = 0;

            //for(int i = 1; i <= num; i++) {
            //    if (i % 2 == 0) {
            //        sum += i;
            //    } 
            //}

            //Console.WriteLine(sum);

            //// ex36.
            //int N = int.Parse(Console.ReadLine());
            //int M = int.Parse(Console.ReadLine());

            //for(int i = 1; i <= N; i++) {
            //    for(int j = 1; j <= M; j++) {
            //        Console.WriteLine("{0} {1}", i, j);
            //    }
            //}



            // ex37.
            //int n = int.Parse(Console.ReadLine());

            //for(int i = 0; i < n; i++) { 
            //   string answer = "";
            //   for (int j = 0; j < n; j++) {
            //        answer += "*";
            //    }
            //    Console.WriteLine(answer);
            //}


            // ex38.
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());

            //double result = (a * b) / 2;

            //Console.WriteLine(string.Format("{0:F1}", result));


            // ex39.
            //int num1 = int.Parse(Console.ReadLine());
            //int num2 = int.Parse(Console.ReadLine());
            //int num3 = int.Parse(Console.ReadLine());

            //int min;

            //if (num1 >= num2) {
            //    min = num2;
            //} else {
            //    min = num1;
            //}

            //if (min <= num3) {
            //    Console.WriteLine(min);
            //} else {
            //    Console.WriteLine(num3);
            //}


            // ex40.
            //double n = double.Parse(Console.ReadLine());

            //if (n <= 60 && n >= 50) {
            //    Console.WriteLine("Win");
            //} else {
            //    Console.WriteLine("Lose");
            //}

            // ex41.
            //int n = int.Parse(Console.ReadLine());

            //if ((n <= 40 && n >= 30) || (n <= 70 && n >= 60)) {
            //    Console.WriteLine("Win");
            //} else {
            //    Console.WriteLine("Lose");
            //}


            // ex42.
            //int n = int.Parse(Console.ReadLine());

            //if((n <= 70 && n >= 50) || (n % 6 == 0)) {
            //    Console.WriteLine("Win");
            //} else {
            //    Console.WriteLine("Lose");
            //}



            // ex43.
            //int num = int.Parse(Console.ReadLine());

            //int[] numbers = new int[5];

            //numbers[0] = num / 10000;
            //numbers[1] = (num % 10000) / 1000;
            //numbers[2] = (num % 1000) / 100;
            //numbers[3] = (num % 100) / 10;
            //numbers[4] = num % 10;

            //string result = "";

            //for(int i = 0; i < numbers.Length; i++) {
            //    if(numbers[i] == 1) {
            //        result += "일";
            //    } else if(numbers[i] == 2) {
            //        result += "이";
            //    } else if (numbers[i] == 3) {
            //        result += "삼";
            //    } else if (numbers[i] == 4) {
            //        result += "사";
            //    } else if (numbers[i] == 5) {
            //        result += "오";
            //    } else if (numbers[i] == 6) {
            //        result += "육";
            //    } else if (numbers[i] == 7) {
            //        result += "칠";
            //    } else if (numbers[i] == 8) {
            //        result += "팔";
            //    } else if (numbers[i] == 9) {
            //        result += "구";
            //    }

            //    if(i == 0 && numbers[i] >= 1) {
            //        result += "만";
            //    } else if(i == 1 && numbers[i] >= 1) {
            //        result += "천";
            //    } else if (i == 2 && numbers[i] >= 1) {
            //        result += "백";
            //    } else if (i == 3 && numbers[i] >= 1) {
            //        result += "십";
            //    }
            //}

            //Console.WriteLine(result);



            // ex44.
            //List<string> day = new List<string>() { "월요일", "화요일", "수요일", "목요일", "금요일", "토요일", "일요일" };

            //int input = int.Parse(Console.ReadLine());

            //if(day[input + 1] == "월요일" || day[input + 1] == "수요일" || day[input + 1] == "금요일" || day[input + 1] == "일요일") {
            //    Console.WriteLine("oh my god");
            //} else {
            //    Console.WriteLine("enjoy");
            //}


            // ex46.
            //int[] numbers = new int[3];
            //string[] result = new string[3];

            //for(int i = 0; i < numbers.Length; i++) {
            //    numbers[i] = int.Parse(Console.ReadLine());

            //    if(numbers[i] <= 170) {
            //        result[i] = "CRASH";
            //    } else {
            //        result[i] = "PASS";
            //    }
            //}

            //for(int i = 0; i < result.Length; i++) {
            //    Console.WriteLine(result[i]);
            //}




            // ex47.
            //int year = int.Parse(Console.ReadLine());

            //if(year % 4 == 0 && year % 100 != 0 || year % 400 == 0) {
            //    Console.WriteLine("yes");
            //} else {
            //    Console.WriteLine("no");
            //}




            // ex48.
            //DateTime today = DateTime.Today;

            //int year = today.Year;

            //string birth = Console.ReadLine();
            //int gender = int.Parse(Console.ReadLine());

            //if (gender == 1 || gender == 2) {
            //    int birth_year = int.Parse("19" + birth[0] + birth[1]);
            //    Console.WriteLine(year - birth_year);
            //} else if(gender == 3 || gender == 4) {
            //    int birth_year = int.Parse("20" + birth[0] + birth[1]);
            //    Console.WriteLine(year - birth_year);
            //}



            // ex49.
            //int hour = int.Parse(Console.ReadLine());

            //if(hour >= 25 || hour < 0) {
            //    Console.WriteLine("Error");
            //    // 메서드나 함수에서 실행을 중단하고 호출한 곳으로 즉시 돌아가고 싶을 때 사용 - 이 이후의 코드는 실행 X
            //    return;
            //}

            //int minute = int.Parse(Console.ReadLine());

            //if (minute >= 61 || minute < 0) {
            //    Console.WriteLine("Error");
            //    return;
            //}

            //if(minute >= 30) {
            //    minute -= 30;
            //    Console.WriteLine($"{hour} {minute}");
            //} else {
            //    minute = 60 - (30 - minute);
            //    hour -= 1;
            //    Console.WriteLine($"{hour} : {minute}");
            //}


            // ex50.
            //int BMI = int.Parse(Console.ReadLine());

            //if(BMI > 23) {
            //    Console.WriteLine("과체중");
            //} else if(BMI >= 18.5 && BMI <= 23) {
            //    Console.WriteLine("정상체중");
            //} else {
            //    Console.WriteLine("저체중");
            //}



            // ex51.
            //int trash = int.Parse(Console.ReadLine());

            //if(trash > 99 || trash < 0) {
            //    Console.WriteLine("Error");
            //    return;
            //}

            //int trash_10 = trash / 10;
            //int trash_1 = trash % 10;

            //int result = (trash_1 * 10 + trash_10) * 2;

            //if((result % 100) <= 50) {
            //    Console.WriteLine(result % 100);
            //    Console.WriteLine("GOOD");
            //} else {
            //    Console.WriteLine(result % 100);
            //    Console.WriteLine("OH MY GOD");
            //}



            // ex52.
            //int num = int.Parse(Console.ReadLine());

            //if(num % 10 == 1) {
            //    Console.WriteLine(num + "st");
            //} else if(num % 10 == 2) {
            //    Console.WriteLine(num + "nd");
            //} else if(num % 10 == 3) {
            //    Console.WriteLine(num + "rd");
            //} else {
            //    Console.WriteLine(num + "th");
            //}



            // ex53.
            //double[] num = new double[8];
            //double max = 0.0;

            //double a = double.Parse(Console.ReadLine());
            //double b = double.Parse(Console.ReadLine());

            //num[0] = a + b;
            //num[1] = b + a;
            //num[2] = a - b;
            //num[3] = b - a;
            //num[4] = a * b;
            //num[5] = b * a;
            //num[6] = a / b;
            //num[7] = b / a;

            //for (int i = 0; i < num.Length; i++) {
            //    if (max < num[i]) {
            //        max = num[i];
            //    }
            //}

            //Console.WriteLine(String.Format("{0:0.0000}", max));



            // ex54.
            //uint a = uint.Parse(Console.ReadLine());
            //uint b = uint.Parse(Console.ReadLine());

            //if(a > b) {
            //    if(a % b == 0) {
            //        Console.WriteLine($"{b} * {a / b} = {a}");
            //    } else {
            //        Console.WriteLine("none");
            //    }
            //} else {
            //    if (b % a == 0) {
            //        Console.WriteLine($"{a} * {b / a} = {b}");
            //    } else {
            //        Console.WriteLine("none");
            //    }
            //}



            //// ex55.
            //int grade = int.Parse(Console.ReadLine());

            //if(grade < 0 || grade > 100) {
            //    Console.WriteLine("error");
            //    return;
            //} else if(grade >= 90) {
            //    Console.WriteLine("A");
            //} else if (grade >= 80) {
            //    Console.WriteLine("B");
            //} else if (grade >= 70) {
            //    Console.WriteLine("C");
            //} else if (grade >= 60) {
            //    Console.WriteLine("D");
            //} else if (grade < 60) {
            //    Console.WriteLine("F");
            //}



            // ex56.
            //Random random = new Random();
            //int[] input = new int[4];

            //for(int i = 0; i < input.Length; i++) {
            //    input[i] = random.Next(0, 2);
            //    Console.WriteLine(input[i]);
            //}

            //if(input.Count(n => n == 1) == 1) {
            //    Console.WriteLine("도");
            //} else if(input.Count(n => n == 1) == 2) {
            //    Console.WriteLine("개");
            //} else if (input.Count(n => n == 1) == 3) {
            //    Console.WriteLine("걸");
            //} else if (input.Count(n => n == 1) == 4) {
            //    Console.WriteLine("윷");
            //} else if (input.Count(n => n == 1) == 0) {
            //    Console.WriteLine("모");
            //}



            // ex57.
            //Dictionary<string, int> menu = new Dictionary<string, int> {
            //    { "치즈버거", 400 },
            //    { "야채버거", 340 },
            //    { "우유", 170 },
            //    { "계란말이", 100 },
            //    { "샐러드", 70 }
            //};

            //int order1 = int.Parse(Console.ReadLine()) - 1;
            //int order2 = int.Parse(Console.ReadLine()) - 1;

            //if((menu.ElementAt(order1).Value + menu.ElementAt(order2).Value) > 500) {
            //    Console.WriteLine("angry");
            //} else {
            //    Console.WriteLine("no angry");
            //}



            //// ex58.
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());
            //int c = int.Parse(Console.ReadLine());

            //if(a > b) {
            //    if(a < c) {
            //        if(c < (a + b)) {
            //            Console.WriteLine("yes");
            //        } else {
            //            Console.WriteLine("no");
            //        }
            //    } else {
            //        if(a < (c + b)) {
            //            Console.WriteLine("yes");
            //        } else {
            //            Console.WriteLine("no");
            //        }
            //    }
            //} else {
            //    if (b < c) {
            //        if (c < (a + b)) {
            //            Console.WriteLine("yes");
            //        } else {
            //            Console.WriteLine("no");
            //        }
            //    } else {
            //        if (b < (a + c)) {
            //            Console.WriteLine("yes");
            //        } else {
            //            Console.WriteLine("no");
            //        }
            //    }
            //}



            // ex59.
            Random random = new Random();

            int i = 0;
            int lotto_count = 0;
            int[] lotto = new int[7];
            int[] numbers = new int[6];

            while (i < lotto.Length) {
                if (i == 0) {
                    lotto[i] = random.Next(1, 46);
                    i++;
                    continue;
                }

                var value = random.Next(1, 46);

                // 중복 제거
                if (lotto.Contains(value)) {
                    continue;
                } else {
                    lotto[i] = value;
                }

                i++;
            }

            // 값 입력
            for(int j = 0; j < numbers.Length; j++) {
                numbers[j] = int.Parse(Console.ReadLine());
            }

            int[] slicedLotto = lotto.Skip(0).Take(6).ToArray();

            for (int j = 0; j < numbers.Length; j++) {
                if(slicedLotto.Contains(numbers[j])) {
                    lotto_count += 1;
                }
            }

            if(lotto_count == 6) {
                Console.WriteLine("1등");
            } else if(lotto_count == 5) {
                if(numbers.Contains(lotto[7])) {
                    Console.WriteLine("2등");
                } else {
                    Console.WriteLine("3등");
                }
            } else if(lotto_count == 4) {
                Console.WriteLine("4등");
            } else if(lotto_count == 3) {
                Console.WriteLine("5등");
            } else {
                Console.WriteLine("꽝!");
            }
        }
    }
}
