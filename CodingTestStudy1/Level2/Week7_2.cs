// #Week7_2 : 주식가격

public class Week7_2
{
    public int[] solution(int[] prices)
    {
        int[] intArrAnswer = new int[prices.Length];
        // 답을 저장할 배열 선언

        for (int iIndex1 = 0; iIndex1 < prices.Length; iIndex1++)
        // 배열의 0번째 부터 하나씩 계산
        {
            int iCountTime = 0;

            for (int iIndex2 = iIndex1 + 1; iIndex2 < prices.Length; iIndex2++)
            // 배열의 iIndex1번째 값과 그 다음 값을 하나씩 더해가며 비교
            {
                if (prices[iIndex1] > prices[iIndex2])
                // 배열의 iIndex1번째 값보다 작아지는 시점에서 break;
                {
                    iCountTime++;

                    break;
                }
                else
                // 배열의 iIndex1번째 값보다 크거나 같으면 iCountTime++, 이후 계속 루프
                    iCountTime++;
            }

            intArrAnswer[iIndex1] = iCountTime;
            // 가격이 떨어지지 않은 시간을 배열에 저장
        }

        return intArrAnswer;
    }
}