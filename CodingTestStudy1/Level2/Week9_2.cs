// Week9_2 : 큰 수 만들기(혼자 못품)

using System.Text;

public class Week9_2
{
    public string solution(string number, int k)
    {
        StringBuilder sbTemp = new StringBuilder();
        int iStartIndex = -1;

        for (int j = 0; j < number.Length - k; j++)
        {
            char max = (char)0;

            for (int i = iStartIndex + 1; i <= k + j; i++)
            {
                if (max < number[i])
                {
                    max = number[i];
                    iStartIndex = i;
                }
            }

            sbTemp.Append(max);
        }

        return sbTemp.ToString();
    }
}