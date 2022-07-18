// Week3_2 : 피보나치 수

using System.Collections.Generic;

public class Week3_2
{
    public int solution(int n)
    {
        // 46까지 int 범위안에 들어옴
        // 47부터는 int 범위안에 안들어옴 47 = 45 + 46
        // 34부터 > 1234567

        List<int> lstFiboNumber = new List<int>(n + 1);
        // index 1 ~ 33까지는 피보나치 수 저장
        // index > 34부터는 나머지 저장으로 변경
        // 피보나치 수가 너무 커지기 때문에 그때그때 나눠서 나머지만 저장함

        for (int i = 0; i < lstFiboNumber.Capacity; i++)
        {
            if (Fibo(i, lstFiboNumber) > 1234567)
                lstFiboNumber.Add(Fibo(i, lstFiboNumber) % 1234567); // <- 나머지 저장하는 부분
            else
                lstFiboNumber.Add(Fibo(i, lstFiboNumber)); // <- 피보나치 수를 저장하는 부분
        }

        return lstFiboNumber[n];
    }

    public int Fibo(int index, List<int> lstFiboNumber)
    {
        if (index == 0) return 0;
        else if (index == 1) return 1;
        else if (index == 2) return 1;
        // index 0 ~ 2까지는 다음 피보나치 수를 구하기 위해서 수동으로 저장
        else
        {
            if (lstFiboNumber.Count > index + 1)
                return lstFiboNumber[index];
            // DP(Dynamic programming) 사용 : 재귀 횟수를 줄일 수 있음
            // 피보나치 수를 저장하고 있다가 필요할 때 가져다 사용함
            else
                return Fibo(index - 2, lstFiboNumber) + Fibo(index - 1, lstFiboNumber);
            // 재귀호출
        }
    }
}