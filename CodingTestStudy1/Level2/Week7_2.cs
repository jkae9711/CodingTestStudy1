// #Week7_2 : 주식가격

public class Week7_2
{
    public int[] solution(int[] prices)
    {
        int[] intArrAnswer = new int[prices.Length];

        for (int iIndex1 = 0; iIndex1 < prices.Length; iIndex1++)
        {
            int iCountTime = 0;

            for (int iIndex2 = iIndex1 + 1; iIndex2 < prices.Length; iIndex2++)
            {
                if (prices[iIndex1] > prices[iIndex2])
                {
                    iCountTime++;

                    break;
                }
                else
                    iCountTime++;
            }

            intArrAnswer[iIndex1] = iCountTime;
        }

        return intArrAnswer;
    }
}