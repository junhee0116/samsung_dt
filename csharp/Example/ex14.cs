using System;
using System.Collections.Generic;
using System.Reflection;

namespace Example {
    internal class ex14 {
        static void Main() {
            // 자료(데이터) 구조
            // 알고리즘: 문제를 풀어나가는 순서나 방법

            // 최댓값 구하기 - Array.Sort(nums)
            int[] nums = [10, 30, 20, 50, 40];

            // 1. max 변수에 최솟값을 설정
            int max = 0;

            // 2. max변수보다 큰 요소를 발견하면 max에 그 값을 넣는다.
            for(int i = 0; i < nums.Length; i++) {
                if(max < nums[i]) {
                    max = nums[i];
                }
            }

            // 3. max 최댓값
            Console.WriteLine(max);



            // 최솟값 구하기
            // 1. min 변수에 최댓값을 설정
            int min = 1000000;

            // 2. min변수보다 작은 요소를 발견하면 min에 그 값을 넣는다.
            for (int i = 0; i < nums.Length; i++) {
                if (min > nums[i]) {
                    min = nums[i];
                }
            }

            // 3. min 최솟값
            Console.WriteLine(min);


            // swap 치환
            int a = 10;
            int b = 3;


            //a에 b값을 b에 a값을 넣고싶다
            // a = b // 20 = 20
            // b = a // 20 = 20
            // 치환용 임시변수를 사용한다
            int temp = 0;
            temp = a;
            b = temp;


            // 정렬 알고리즘
            // 1. 버블 정렬
            nums = [10, 30, 20, 50, 40];

            for(int i = 0; i < nums.Length; i++) {
                for(int j = i + 1; j < nums.Length; j++) {
                    if(nums[i] > nums[j]) {
                        // 치환
                        int tmp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = tmp;
                    }
                }
            }

            foreach(int num in nums) {
                Console.Write(num + " ");
            }

            // 2. 선택 정렬
            nums = [10, 30, 20, 50, 40];
            int minIndex = 0;

            for(int i = 0; i < 5; i++) {
                minIndex = i;
                for(int j = i + 1; j < 5; j++) {
                    if (nums[j] < nums[minIndex]) {
                        // 더 작은 값을 발견
                        minIndex = j;
                    }
                }
                Console.WriteLine(minIndex);

                // 치환
                int tmp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = tmp;
            }

            foreach(int num in nums) {
                Console.Write(num + " ");
            }



            // 3. 삽입 정렬
            // 인덱스1 부터 시작하고 자기보다 왼쪽에 있는 값들을 비교하고 더 작은 값이면 치환
            // 교환할 값을 가진 key 변수를  사용
            nums = [10, 30, 20, 50, 40];
            int key = 0;

            for(int i = 1; i < nums.Length; i++) {
                key = nums[i];
                int j = i - 1;
                while(j >= 0 && nums[j] > key) {
                    nums[j + 1] = nums[j];
                    j--;
                }
                nums[j + 1] = key;
            }
            foreach(int num in nums) {
                Console.Write(num + " ");
            }

        }
    }
}
