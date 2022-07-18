// Week3_1 : 소수 만들기

using System;
using System.Collections.Generic;
using System.Linq;

class Week3_1
{
    public int solution(int[] nums)
    {
        List<int> lstSum = new List<int>();
        // 입력 배열에서 3개 원소의 합을 구해 .Add()하기 위한 List<int> 선언

        //List<int> lstPrime = new List<int>();
        // 소수를 찾아 .Add()하기 위한 List<int> 선언
        // (방법 2에서는 쓰이지 않음)

        int iAnswer = 0;
        // 소수의 개수를 카운트하기 위한 변수 선언

        bool bIsContinue = false;
        // 루프에서 분기하기 위한 변수 선언

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    lstSum.Add(nums[i] + nums[j] + nums[k]);
                }
            }
        }
        // 입력 배열에서 3개 원소의 합을 구하여 lstSum에 .Add()하는 루프

        #region 방법 1 : 소수를 먼저 찾고, lstSum에서 같은 숫자의 개수를 반환 -> 느림...

        //for (int number = 2; number <= lstSum.Max(); number++)
        //{
        //    if (number > 2 && number % 2 == 0)
        //        continue;

        //    foreach (var primeNumber in lstPrime)
        //    {
        //        if (primeNumber > Math.Sqrt(number)) break;

        //        if (number % primeNumber == 0)
        //        {
        //            bIsContinue = true;

        //            break;
        //        }
        //    }

        //    if (bIsContinue)
        //    {
        //        bIsContinue = false;

        //        continue;
        //    }
        //    else
        //        lstPrime.Add(number);
        //}

        //foreach (var SumNumber in lstSum)
        //{
        //    if (lstPrime.Contains(SumNumber))
        //        iAnswer++;
        //}

        #endregion

        #region 방법 2 : lstSum을 순회하며 소수인지 확인하고, 소수의 개수를 반환 -> 문제에서는 이게 더 빠름

        foreach (var SumNumber in lstSum)
        {
            for (int i = 2; i < SumNumber; i++)
            {
                if (SumNumber % i == 0)
                {
                    bIsContinue = true;

                    break;
                }
            }

            if (bIsContinue)
            {
                bIsContinue = false;

                continue;
            }
            else
                iAnswer++;
        }

        #endregion

        return iAnswer;
    }
}