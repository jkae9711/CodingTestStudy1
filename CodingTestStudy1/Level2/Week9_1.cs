// Week9_1 : 최댓값과 최솟값

using System;
using System.Linq;

public class Week9_1
{
    public string solution(string s)
    {
        var temp = from item in s.Split(' ')
                   select Int32.Parse(item);

        return temp.Min().ToString() + " " + temp.Max().ToString();
    }
}