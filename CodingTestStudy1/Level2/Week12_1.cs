// Week12_1 : JadenCase 문자열 만들기

public class Week12_1
{
    public string solution(string s)
    {
        string answer = "";
        int iIndex = 0;
        bool bNeedToCapital = true;

        while (iIndex < s.Length) // 마지막 인덱스 이후에는 break
        {
            if (s[iIndex] == ' ') // 현재 글자가 공백인 경우, 다음 글자를 확인하여 Letter인 경우 bNeedToCapital = true
            {
                answer += s[iIndex];

                if (iIndex < s.Length - 1 == true) // 마지막 인덱스의 글자가 공백일 때, s[iIndex + 1] 부분에서 Exception 발생하므로 처리
                {
                    if (char.IsLetter(s[iIndex + 1]) == true)
                    {
                        bNeedToCapital = true;
                    }
                }
            }

            if (char.IsLetter(s[iIndex]) == true) // 현재 글자가 Letter인 경우, bNeedToCapital을 확인하여 answer에 추가
            {
                if (bNeedToCapital == true)
                {
                    answer += char.ToUpper(s[iIndex]);
                    bNeedToCapital = false;
                }
                else // bNeedToCapital == false
                {
                    answer += char.ToLower(s[iIndex]);
                }
            }

            if (char.IsDigit(s[iIndex]) == true) // 현재 글자가 Digit인 경우, answer에 추가하며 추가로 bNeedToCapital = false
            {
                answer += s[iIndex];
                bNeedToCapital = false;
            }

            iIndex++; // 다음 인덱스로 이동
        }

        return answer;
    }
}