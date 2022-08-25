// #Week8_2 : 카펫

using System.Collections.Generic;

public class Week8_2
{
    public int[] solution(int brown, int yellow)
    {
        int width = 0, height = 0;
        // 리턴하고자 하는 가로, 세로 값 선언

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
                width = item[0] + 2;
                height = item[1] + 2;

                break;
            }
        }

        return new int[] { width, height };
    }
}