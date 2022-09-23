// Week12_1 : JadenCase 문자열 만들기

public class Week12_1
{
    public string solution(string s)
    {
        string answer = "";

        string[] strInput = s.Split(' '); // 공백을 기준으로 Split

        for (int i = 0; i < strInput.Length; i++)
        {
            if (char.IsLetter(strInput[i][0]) == true) // 문자인 경우
                answer += char.ToUpper(strInput[i][0]) + strInput[i].Substring(1, strInput[i].Length - 1) + " ";
            else // 문자가 아닌 경우
                answer += strInput[i] + " ";
        }

        return answer.Substring(0, answer.Length - 1); // 마지막 공백을 제외하고 출력
    }
}