// #Week8_1 : 소수 찾기

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Week8_1
{
    class Permutation
    {
        private int[] data = null;
        private int order = 0;

        public Permutation(int n)
        {
            this.data = new int[n];
            for (int i = 0; i < n; ++i)
            {
                this.data[i] = i;
            }

            this.order = n;
        }

        public Permutation Successor()
        {
            Permutation result = new Permutation(this.order);

            int left, right;
            for (int k = 0; k < result.order; ++k)  // Step #0 - copy current data into result
            {
                result.data[k] = this.data[k];
            }

            left = result.order - 2;  // Step #1 - Find left value 
            while ((result.data[left] > result.data[left + 1]) && (left >= 1))
            {
                --left;
            }

            if ((left == 0) && (this.data[left] > this.data[left + 1]))
            {
                return null;
            }

            right = result.order - 1;  // Step #2 - find right; first value > left
            while (result.data[left] > result.data[right])
            {
                --right;
            }

            int temp = result.data[left];  // Step #3 - swap [left] and [right]
            result.data[left] = result.data[right];
            result.data[right] = temp;


            int i = left + 1;              // Step #4 - order the tail
            int j = result.order - 1;

            while (i < j)
            {
                temp = result.data[i];
                result.data[i++] = result.data[j];
                result.data[j--] = temp;
            }

            return result;
        }

        internal static long Choose(int length)
        {
            long answer = 1;

            for (int i = 1; i <= length; i++)
            {
                checked { answer = answer * i; }
            }

            return answer;
        }

        public string[] ApplyTo(string[] arr)
        {
            if (arr.Length != this.order)
            {
                return null;
            }

            string[] result = new string[arr.Length];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = arr[this.data[i]];
            }

            return result;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("( ");
            for (int i = 0; i < this.order; ++i)
            {
                sb.Append(this.data[i].ToString() + " ");
            }
            sb.Append(")");

            return sb.ToString();
        }

    }

    public int solution(string numbers)
    {
        int iAnswer = 0;
        string[] strInput = (from item in numbers
                            select item.ToString())
                            .ToArray();

        string[] snapshot = null;
        List<string> lstNeedCheck = new List<string>();

        Permutation permut = new Permutation(strInput.Length);

        while (permut != null)
        {
            snapshot = permut.ApplyTo(strInput);
            permut = permut.Successor();

            if (permut != null)
                lstNeedCheck.Add(permut.ToString());
        }

        //for (int i = 0; i < numbers.Length; i++)
        //    GetNumber(numbers, "", i);

        //StringBuilder sbTemp = new StringBuilder();

        //foreach (var item in numbers.Reverse())
        //    sbTemp.Append(item);

        //for (int i = 0; i < numbers.Length; i++)
        //    GetNumber(sbTemp.ToString(), "", i);

        //var temp1 = (from item in lstNumber
        //             select item)
        //           .Distinct()
        //           .ToList();

        //List<int> lstNeedCheckPrimeNumber = new List<int>();

        //for (int i = 0; i < temp1.Count; i++)
        //{
        //    var strTemp = temp1[i].ToString().ToArray();

        //    for (int j = 0; j < strTemp.Length; j++)
        //    {
        //        char[] temp = (char[])strTemp.Clone();

        //        for (int k = 0; k < strTemp.Length; k++)
        //        {
        //            var temp2 = temp[j];

        //            temp[j] = temp[k];
        //            temp[k] = temp2;

        //            StringBuilder sbtemptemp = new StringBuilder();

        //            foreach (var item in temp)
        //                sbtemptemp.Append(item);

        //            lstNeedCheckPrimeNumber.Add(Int32.Parse(sbtemptemp.ToString()));
        //        }
        //    }
        //}

        //var lstNeedCheckPrimeNumberDistinct = lstNeedCheckPrimeNumber.Distinct().ToList();

        //for (int i = 0; i < lstNeedCheckPrimeNumberDistinct.Count; i++)
        //{
        //    bool bIsPrimeNumber = true;

        //    if (lstNeedCheckPrimeNumberDistinct[i] == 0 || lstNeedCheckPrimeNumberDistinct[i] == 1)
        //        continue;

        //    for (int j = 2; j <= Math.Sqrt(lstNeedCheckPrimeNumberDistinct[i]); j++)
        //    {
        //        if (lstNeedCheckPrimeNumberDistinct[i] % j == 0)
        //        {
        //            bIsPrimeNumber = false;

        //            break;
        //        }
        //    }

        //    if (bIsPrimeNumber)
        //    {
        //        iAnswer++;
        //        Console.WriteLine("PrimeNumberIs : " + i);
        //    }
        //}

        return iAnswer;
    }

    //public void GetNumber(string numbers, string strMemory, int iIndex)
    //{
    //    StringBuilder sbTemp = new StringBuilder(strMemory);

    //    sbTemp.Append(numbers[iIndex].ToString());
    //    lstNumber.Add(sbTemp.ToString());

    //    for (int i = iIndex + 1; i < numbers.Length; i++)
    //        GetNumber(numbers, sbTemp.ToString(), i);
    //}
}