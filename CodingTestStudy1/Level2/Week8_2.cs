// #Week8_2 : 카펫

using System.Collections.Generic;

public class Week8_2
{
    public int[] solution(int brown, int yellow)
    {
        int height = 0, width = 0;
        List<int[]> lstXY = new List<int[]>();

        for (int i = 1; i <= yellow; i++)
        {
            double iTemp = (double)yellow / (double)i;

            if (i <= iTemp)
            {
                if (iTemp % 1 == 0)
                    lstXY.Add(new int[] { (int)iTemp, i });
            }
            else
                break;
        }

        foreach (var item in lstXY)
        {
            if (brown == (item[0] + 2) * 2 + item[1] * 2)
            {
                height = item[0] + 2;
                width = item[1] + 2;

                break;
            }
        }

        return new int[] { height, width };
    }
}