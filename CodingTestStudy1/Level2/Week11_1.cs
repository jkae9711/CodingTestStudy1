// Week11_1 : 최솟값 만들기

using System.Collections.Generic;
using System.Linq;

public class Week11_1
{
    public int solution(int[] A, int[] B)
    {
        int answer = 0;

        int iSelMinInA = 0, iSelMaxInB = 0;
        // 한 배열(A)에서 가장 작은 값을 꺼내고,
        // 다른 한 배열(B)에서는 가장 큰 값을 꺼내서,
        // 두 수를 곱해준 값을 계속 더해가면,
        // 최종 answer 값이 최솟값일 거라고 가정.

        List<int> lstA = A.ToList();
        List<int> lstB = B.ToList();
        // A, B 두 배열의 길이는 같음

        for (int i = 0; i < A.Length; i++)
        {
            iSelMinInA = lstA.Min();
            lstA.Remove(iSelMinInA);

            iSelMaxInB = lstB.Max();
            lstB.Remove(iSelMaxInB);

            answer += iSelMinInA * iSelMaxInB;
        }

        return answer;
    }
}