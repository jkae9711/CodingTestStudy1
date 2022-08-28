// #Week8_1 : 소수 찾기

using System;
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

        StringBuilder sbTemp = new StringBuilder();

        foreach (var item in numbers.Reverse())
            sbTemp.Append(item);

        for (int i = 0; i < numbers.Length; i++)
            GetNumber(sbTemp.ToString(), "", i);

        var temp1 = (from item in lstNumber
                     select item)
                   .Distinct()
                   .ToList();

        List<int> lstNeedCheckPrimeNumber = new List<int>();

        for (int i = 0; i < temp1.Count; i++)
        {
            var strTemp = temp1[i].ToString().ToArray();

            for (int j = 0; j < strTemp.Length; j++)
            {
                for (int k = 0; k < strTemp.Length; k++)
                {
                    char[] temp = (char[])strTemp.Clone();

                    var temp2 = temp[j];
                    temp[j] = temp[k];
                    temp[k] = temp2;

                    StringBuilder sbtemptemp = new StringBuilder();

                    foreach (var item in temp)
                        sbtemptemp.Append(item);

                    lstNeedCheckPrimeNumber.Add(Int32.Parse(sbtemptemp.ToString()));
                }
            }
        }

        var lstNeedCheckPrimeNumberDistinct = lstNeedCheckPrimeNumber.Distinct().ToList();

        for (int i = 0; i < lstNeedCheckPrimeNumberDistinct.Count; i++)
        {
            bool bIsPrimeNumber = true;

            if (lstNeedCheckPrimeNumberDistinct[i] == 0 || lstNeedCheckPrimeNumberDistinct[i] == 1)
                continue;

            for (int j = 2; j <= Math.Sqrt(lstNeedCheckPrimeNumberDistinct[i]); j++)
            {
                if (lstNeedCheckPrimeNumberDistinct[i] % j == 0)
                {
                    bIsPrimeNumber = false;

                    break;
                }
            }

            if (bIsPrimeNumber)
            {
                iAnswer++;
                Console.WriteLine("PrimeNumberIs : " + i);
            }
        }

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