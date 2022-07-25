// #Week4_2 : 프린터

using System.Collections.Generic;
using System.Linq;

public class Week4_2
{
    public int solution(int[] priorities, int location)
    {
        Queue<int> qPrinter = new Queue<int>(priorities);
        // priorities를 저장하는 Queue

        int iCountPrint = 0;
        // 현재까지 출력된 작업물의 개수를 카운트

        while (true)
        {
            int iDequeueValue = qPrinter.Dequeue();
            // 1. 우선 Dequeue()

            if (qPrinter.Count > 0)
            // 2. 제일 마지막에 Dequeue()되면 queue에 남아있는 값이 없어서 .Max()에서 런타임 오류 발생하므로 걸러줌
            {
                if (iDequeueValue >= qPrinter.Max())
                // 3. 현재 Dequeue()한 작업물의 우선순위를 queue에 남아있는 작업물들의 우선순위와 비교
                {
                    iCountPrint++;
                    location--;

                    if (location < 0) // 4. 내가 원하는 작업물이 출력되었는지 확인
                        break;
                }
                else
                {
                    qPrinter.Enqueue(iDequeueValue);
                    // 5. 현재 Dequeue()한 작업물이 queue에 남아있는 작업물들의 우선순위보다 낮아서 다시 Enqueue()

                    location--;

                    if (location < 0) // 6. 만약 내가 원하던 작업물이 우선순위 때문에 출력되지 못하였다면 다시 위치를 큐의 맨 마지막으로 갱신
                        location = qPrinter.Count - 1;
                }
            }
            else
            {
                iCountPrint++;

                break;
            }
        }

        return iCountPrint;
        // 7. 출력 횟수 반환
    }
}