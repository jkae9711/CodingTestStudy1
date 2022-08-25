// #Week8_2 : 카펫

using System.Collections.Generic;

public class Week8_2
{
    public int[] solution(int brown, int yellow)
    {
        int width = 0, height = 0;
        // 리턴하고자 하는 가로(width), 세로(height) 변수 선언

        List<int[]> lstXY = new List<int[]>();
        // yellow 영역의 가로(X), 세로(Y)를 저장하는 리스트 선언

        for (int i = 1; i <= yellow; i++)
        // 세로(i)를 1씩 증가시킴
        {
            double iTemp = (double)yellow / (double)i;
            // yellow / 가로 = 세로
            // (가로, 세로) 조합을 찾기

            if (i <= iTemp)
            // 문제의 조건 : 세로 길이 <= 가로 길이
            {
                if (iTemp % 1 == 0)
                // 가로 길이가 자연수일 경우 진입
                    lstXY.Add(new int[] { (int)iTemp, i });
                    // lstXY에 (가로, 세로) 조합을 저장
            }
            else
            // 문제의 조건에 만족하지 않는 가로 < 세로인 경우 불필요한 연산이므로 break;
                break;
        }

        foreach (var item in lstXY)
        // lstXY에 있는 요소를 하나씩 item으로 가져오기, iteration
        {
            if (brown == (item[0] + 2) * 2 + item[1] * 2)
            // brown = (가로 + 2) * 2 + 세로 * 2
            {
                width = item[0] + 2;
                height = item[1] + 2;
                // 반환할 가로, 세로 길이를 결정

                break;
                // brown을 찾아내면 더 이상 반복할 필요 없으므로 break;
            }
        }

        return new int[] { width, height };
    }
}