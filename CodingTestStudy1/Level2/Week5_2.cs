// #Week5_2 : 가장 큰 수(혼자 못품)

using System;
using System.Linq;

public class Week5_2
{
    public string solution(int[] numbers)
    {
        Array.Sort(numbers, (x, y) =>
        {
            string XY = x.ToString() + y.ToString();
            string YX = y.ToString() + x.ToString();
            return YX.CompareTo(XY);
        });

        if (numbers.Where(x => x == 0).Count() == numbers.Length) return "0";
        else return string.Join("", numbers);
    }
}