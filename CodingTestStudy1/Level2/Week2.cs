// Week2 : "기능개발"

using System;
using System.Collections.Generic;

public class Week2
{
    public int[] solution(int[] progresses, int[] speeds)
    {
        List<int> answer = new List<int>();
        // 1. 답을 저장하는 List<int> 선언
        // (List로 선언하는 이유 : [1] .Add() 메서드 호출로 편하게 저장할 수 있음, [2] return시 .ToArray() 메서드로 간편하게 리턴가능)

        Queue<int> qProgresses = new Queue<int>(progresses);
        // 2. 작업 목록을 저장하는 Queue<int> 선언
        // Dequeue(), Enqueue()를 Queue의 길이만큼 하면 한바퀴 순회할 수 있음

        Queue<int> qSpeeds = new Queue<int>(speeds);
        // 3. 작업 속도를 저장하는 Queue<int> 선언

        Stack<int> sFinishedWorkIndex = new Stack<int>();
        // 4. 한번의 배포에 몇 개의 기능이 배포되는지 저장할 Stack<int> 선언

        while (true)
        {
            if (qProgresses.Count <= 0) break;
            // 5. 작업 개수가 0개 이하일 경우 빠져나감(예외 처리)

            int iQueueCount = qProgresses.Count;
            // 6. 현재 남은 작업 개수를 iQueueCount에 저장
            // (iQueueCount만큼 Dequeue(), Enqueue()하기 위해서)

            for (int i = 0; i < iQueueCount; i++)
            {
                int iSpeed = qSpeeds.Dequeue();

                qProgresses.Enqueue(qProgresses.Dequeue() + iSpeed);
                qSpeeds.Enqueue(iSpeed);
            }
            // 7. qProgresses에 qSpeeds만큼 작업 진도를 Dequeue()하여 더해주고, Enqueue()하여 다시 저장
            // 한 바퀴 순회

            for (int i = 0; i < iQueueCount; i++)
            {
                if (qProgresses.Peek() >= 100)
                {
                    sFinishedWorkIndex.Push(i);
                    qProgresses.Dequeue();
                    qSpeeds.Dequeue();
                }
            }
            // 8. 저장된 큐의 맨 처음 작업이 완료되었다면 계속해서 다음 작업도 완료되었는지 확인
            // 작업의 인덱스를 스택에 저장 *
            // (완료된 작업의 개수를 반환하는거라서 인덱스는 사실 저장할 필요가 없음)

            if (sFinishedWorkIndex.Count > 0)
            {
                answer.Add(sFinishedWorkIndex.Count);
                sFinishedWorkIndex.Clear();
            }
            // 9. 답을 저장하기 위한 리스트(answer)에 스택의 카운트를 저장 후, 스택을 초기화 *
            // (스택에 다음 완료 작업도 저장하기 위해 스택을 초기화함)
        }

        return answer.ToArray();
        // 10. 답 반환(List -> Array)
    }
}