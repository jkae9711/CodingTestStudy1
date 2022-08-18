// #Week7_1 : H-Index

using System.Linq;

public class Week7_1
{
    public int solution(int[] citations)
    {
        int[] intArrHValue = new int[citations.Length];

        for (int iIndex1 = 0; iIndex1 < citations.Length; iIndex1++)
        {
            int iHitCount = 0;

            for (int iIndex2 = 0; iIndex2 < citations.Length; iIndex2++)
            {
                if (citations[iIndex1] <= citations[iIndex2]) // h번 이상 인용된 논문의 개수 찾기
                    iHitCount++;

                if (iHitCount == citations[iIndex1]) // h번 이상 인용된 논문의 개수가 h번이 되면 그 이상 찾을 필요 없으므로 break;
                    break;
            }

            if (iHitCount <= citations[iIndex1])
                intArrHValue[iIndex1] = iHitCount;
            else
                intArrHValue[iIndex1] = 0;

            iHitCount = 0;
        }

        return intArrHValue.Max();
    }
}