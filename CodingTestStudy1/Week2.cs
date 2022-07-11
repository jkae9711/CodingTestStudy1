// Week2 : "기능개발"

using System;
using System.Collections.Generic;

public class Week2
{
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> answer = new List<int>();
        Queue<int> qProgresses = new Queue<int>(progresses);
        Queue<int> qSpeeds = new Queue<int>(speeds);
        Stack<int> sFinishedWorkIndex = new Stack<int>();

        while (true)
        {
            if (qProgresses.Count <= 0) break;

            int iQueueCount = qProgresses.Count;

            for (int i = 0; i < iQueueCount; i++)
            {
                int iSpeed = qSpeeds.Dequeue();

                qProgresses.Enqueue(qProgresses.Dequeue() + iSpeed);
                qSpeeds.Enqueue(iSpeed);
            }

            for (int i = 0; i < iQueueCount; i++)
            {
                if (qProgresses.Peek() >= 100)
                {
                    sFinishedWorkIndex.Push(i);
                    qProgresses.Dequeue();
                    qSpeeds.Dequeue();
                }
            }

            if (sFinishedWorkIndex.Count > 0)
            {
                answer.Add(sFinishedWorkIndex.Count);
                sFinishedWorkIndex.Clear();
            }
        }

        return answer.ToArray();
    }
}