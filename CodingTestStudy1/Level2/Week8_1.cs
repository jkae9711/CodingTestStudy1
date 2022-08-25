// #Week8_1 : 소수 찾기

using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Week8_1
{
    public static List<string> lstNumber = new List<string>();

    public int solution(string numbers)
    {
        int iAnswer = 0;

        for (int i = 0; i < numbers.Length; i++)
            GetNumber(numbers, "", i);



        return iAnswer;
    }

    public void GetNumber(string numbers, string strMemory, int iIndex)
    {
        StringBuilder sbTemp = new StringBuilder(strMemory);

        sbTemp.Append(numbers[iIndex].ToString());
        lstNumber.Add(sbTemp.ToString());

        for (int i = iIndex + 1; i < numbers.Length; i++)
            GetNumber(numbers, sbTemp.ToString(), i);
    }
}