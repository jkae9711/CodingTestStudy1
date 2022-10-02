// Week13_2 : 조이스틱

using System.Collections.Generic;
using System.Linq;

public class Week13_2
{
    public int solution(string name)
    {
        int iOperationCount = 0;

        Queue<char> qGlobal = new Queue<char>(name);

        int iCountNotA = (from x in qGlobal
                          where x != 'A'
                          select x)
                          .Count();

        for (int i = iCountNotA; i > 0; i--)
        {
            int iRightSearchResult = 0;
            int iLeftSearchResult = 0;

            // Find iRightSearchResult start
            Queue<char> qTemp = new Queue<char>(qGlobal);
            Queue<char> qTempCopy = new Queue<char>(qTemp);

            for (int j = 0; j < qGlobal.Count; j++) 
            {
                char cDequeue = qTempCopy.Dequeue();

                if (cDequeue != 'A')
                {
                    iRightSearchResult = j;

                    break;
                }
            }
            // Find iRightSearchResult end

            // Find iLeftSearchResult start
            Queue<char> qTempReverse = new Queue<char>(qGlobal.Reverse());
            Queue<char> qTempReverseCopy = new Queue<char>(qTempReverse);

            for (int n = 0; n < qTempReverse.Count - 1; n++)
            {
                qTempReverse.Enqueue(qTempReverse.Dequeue());
                qTempReverseCopy.Enqueue(qTempReverseCopy.Dequeue());
            }

            for (int j = 0; j < qGlobal.Count; j++) 
            {
                char cDequeue = qTempReverseCopy.Dequeue();

                if (cDequeue != 'A')
                {
                    iLeftSearchResult = j;

                    break;
                }
            }
            // Find iLeftSearchResult end

            // Calculation start
            if (iRightSearchResult <= iLeftSearchResult)
            {
                iOperationCount += iRightSearchResult;

                for (int k = 0; k < iRightSearchResult; k++)
                    qTemp.Enqueue(qTemp.Dequeue());

                char cDequeueGlobal = qTemp.Dequeue();

                if ((int)cDequeueGlobal <= (int)'N')
                    iOperationCount += (int)cDequeueGlobal - (int)'A';
                else
                    iOperationCount += ((int)'Z' - (int)cDequeueGlobal + 1);

                qTemp.Enqueue('A');

                for (int m = 0; m < qTemp.Count - 1; m++)
                    qTemp.Enqueue(qTemp.Dequeue());

                qGlobal = qTemp;
            }
            else // iRightSearchResult > iLeftSearchResult
            {
                iOperationCount += iLeftSearchResult;

                for (int k = 0; k < iLeftSearchResult; k++)
                    qTempReverse.Enqueue(qTempReverse.Dequeue());

                char cDequeueGlobal = qTempReverse.Dequeue();

                if ((int)cDequeueGlobal <= (int)'N')
                    iOperationCount += (int)cDequeueGlobal - (int)'A';
                else
                    iOperationCount += ((int)'Z' - (int)cDequeueGlobal + 1);

                qTempReverse.Enqueue('A');

                qGlobal = qTempReverse;
            }
            // Calculation end
        }

        return iOperationCount;
    }
}

/*
 * 
 * 
 * 미완
 * 
 * 테스트 1 〉	통과 (3.11ms, 31MB)
 * 테스트 2 〉	통과 (4.91ms, 30.8MB)
 * 테스트 3 〉	통과 (3.23ms, 31MB)
 * 테스트 4 〉	실패 (3.15ms, 31MB)
 * 테스트 5 〉	통과 (3.22ms, 30.9MB)
 * 테스트 6 〉	통과 (3.55ms, 31.4MB)
 * 테스트 7 〉	실패 (3.20ms, 31.3MB)
 * 테스트 8 〉	실패 (3.09ms, 31MB)
 * 테스트 9 〉	통과 (3.19ms, 30.9MB)
 * 테스트 10 〉	통과 (3.13ms, 31MB)
 * 테스트 11 〉	실패 (3.21ms, 31.3MB)
 * 테스트 12 〉	통과 (3.29ms, 30.9MB)
 * 테스트 13 〉	실패 (3.21ms, 31.1MB)
 * 테스트 14 〉	실패 (3.70ms, 31MB)
 * 테스트 15 〉	통과 (4.17ms, 31.1MB)
 * 테스트 16 〉	통과 (2.02ms, 30.9MB)
 * 테스트 17 〉	통과 (2.66ms, 31.1MB)
 * 테스트 18 〉	통과 (3.13ms, 31.2MB)
 * 테스트 19 〉	통과 (3.09ms, 31.1MB)
 * 테스트 20 〉	실패 (3.46ms, 31.2MB)
 * 테스트 21 〉	통과 (4.79ms, 31.1MB)
 * 테스트 22 〉	통과 (3.34ms, 31.3MB)
 * 테스트 23 〉	통과 (3.51ms, 31.1MB)
 * 테스트 24 〉	실패 (3.20ms, 30.9MB)
 * 테스트 25 〉	실패 (3.36ms, 31.4MB)
 * 테스트 26 〉	실패 (3.14ms, 31.2MB)
 * 테스트 27 〉	실패 (3.29ms, 31MB)
 * 
 * 
 */
