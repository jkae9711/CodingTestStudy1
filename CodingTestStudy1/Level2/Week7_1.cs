// #Week7_1 : H-Index

public class Week7_1
{
    public int solution(int[] citations)
    {
        int[] intArrHValue = new int[citations.Length];
        int iAnswer = 0;

        for (int iIndex1 = 0; iIndex1 < citations.Length; iIndex1++)
        {
            int iHitCount = 0;

            for (int iIndex2 = 0; iIndex2 < citations.Length; iIndex2++)
            {
                if (citations[iIndex1] == 0) // h가 0인 경우에는 탐색 안함
                    break;

                if (citations[iIndex1] <= citations[iIndex2]) // h번 이상 인용된 논문의 개수 찾기
                    iHitCount++;

                if (iHitCount == citations[iIndex1]) // h번 이상 인용된 논문의 개수가 h개가 되면 그 이상 찾을 필요 없으므로 break;
                    break;
            }

            if (iHitCount >= iAnswer) // h의 최대값 갱신
                iAnswer = iHitCount;
        }

        return iAnswer;
    }
}