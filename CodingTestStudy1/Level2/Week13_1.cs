// Week13_1 : 점프와 순간 이동

public class Week13_1
{
    int answer = 0; // K값

    public int solution(int n)
    {
        Function(n);

        return answer;
    }

    public void Function(int iInput)
    {
        if (iInput == 1)
        {
            answer++;

            return;
        }
        else
        {
            int iDivisionTwo = iInput / 2;

            if (iInput % 2 == 0)
            {
                Function(iDivisionTwo);
            }
            else // iInput % 2 != 0
            {
                Function(iDivisionTwo);

                answer++;
            }
        }
    }
}