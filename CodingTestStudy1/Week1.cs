// Week1 : "문자열 내 마음대로 정렬하기"

using System.Collections.Generic;
using System.Linq;

public class Week1
{
    public string[] solution(string[] strings, int n)
    {
        List<string> answer = new List<string>();

        var lstTemp1 = (from word in strings
                       orderby word[n]
                       select word[n]).Distinct();

        foreach (var item in lstTemp1)
        {
            List<string> lstTemp2 = new List<string>();

            foreach (var word in strings)
            {
                if (item == word[n])
                {
                    lstTemp2.Add(word);
                }
            }

            lstTemp2.Sort();

            foreach (var word in lstTemp2)
            {
                answer.Add(word);
            }
        }

        return answer.ToArray();
    }
}