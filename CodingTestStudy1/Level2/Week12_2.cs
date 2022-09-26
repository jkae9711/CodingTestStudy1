// Week12_2 : 하노이의 탑

using System;
using System.Collections.Generic;

public class Week12_2
{
    List<int[]> lstMove = new List<int[]>();

    public int[,] solution(int n)
    {
        Hanoi(n, 1, 3, 2);

        int[,] answer = new int[lstMove.Count, 2];

        for (int i = 0; i < lstMove.Count; i++)
        {
            answer[i, 0] = lstMove[i][0];
            answer[i, 1] = lstMove[i][1];
        }

        return answer;
    }

    public void Hanoi(int num, int start, int end, int by)
    {
        Console.WriteLine(@"Called Hanoi({0}, {1}, {2}, {3})", num, start, end, by);

        if (num == 1)
        {
            lstMove.Add(new int[] { start, end });

            Console.WriteLine(@"{0} ring start {1} to {2}", num, start, end);
        }
        else
        {
            Hanoi(num - 1, start, by, end);

            lstMove.Add(new int[] { start, end });

            Console.WriteLine(@"{0} ring start {1} to {2}", num, start, end);

            Hanoi(num - 1, by, end, start);
        }
    }
}