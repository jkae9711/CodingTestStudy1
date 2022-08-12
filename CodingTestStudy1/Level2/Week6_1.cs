// #Week6_1 : 다리를 지나는 트럭

using System.Collections.Generic;

public class Week6_1
{
    /// <summary>
    /// 트럭을 모사하는 클래스
    /// 트럭 객체를 만들기 위함
    /// </summary>
    public class Truck
    {
        public int iCurrentLocation;
        // 트럭의 현재 위치 인덱스를 저장

        public int iWeight;
        // 트럭의 무게를 저장

        /// <summary>
        /// 생성자
        /// 위치는 1로 초기화
        /// 무게는 매개변수로 입력받아 초기화
        /// </summary>
        /// <param name="weight"></param>
        public Truck(int weight)
        {
            iCurrentLocation = 1;
            iWeight = weight;
        }
    }

    public int solution(int bridge_length, int weight, int[] truck_weights)
    {
        int iElapsedTime = 0;
        // 경과 시간

        Queue<int> qWaitingTruck = new Queue<int>(truck_weights);
        // 입력값인 트럭 무게를 대기 중인 트럭이 저장되는 큐에 삽입
        // 따로 큐에 저장하는 이유 -> Dequeue() 하면서 다리를 건너가는 트럭은 삭제해버리기 위함

        List<Truck> lstBridge = new List<Truck>();
        // 다리를 건너고 있는 트럭을 저장하는 리스트

        while (qWaitingTruck.Count > 0 || lstBridge.Count > 0)
        { // 대기 중인 트럭 개수와 다리를 건너고 있는 트럭 개수를 체크하며 무한 루프

            iElapsedTime++;
            // 경과 시간 ++

            if (lstBridge.Count > 0)
            { // 다리를 건너고 있는 트럭이 없다면 넘어감(최초 루프시)

                int iCountListBridge = lstBridge.Count;
                // 반복문 돌리기 전 Index 제한을 위해서(다리 위 트럭의 개수만큼 반복)

                for (int iIndex = iCountListBridge - 1; iIndex >= 0; iIndex--)
                {
                    var CurrentTruck = lstBridge[iIndex];

                    CurrentTruck.iCurrentLocation++;

                    if (CurrentTruck.iCurrentLocation > bridge_length)
                        lstBridge.RemoveAt(iIndex);
                }
                // 다리 위에 있는 트럭들의 iCurrentLocation ++
            }

            if (qWaitingTruck.Count > 0)
            { // 대기 중인 트럭이 없다면 넘어감(마지막에 다리를 건너고 있는 트럭만 남았을 경우)

                int iWeightSum = 0;
                // 트럭 무게 합산을 위한 변수 선언 & 0 초기화

                foreach (var truck in lstBridge)
                    iWeightSum += truck.iWeight;
                // 다리를 건너고 있는 트럭들의 무게를 합산

                if (iWeightSum + qWaitingTruck.Peek() <= weight)
                    lstBridge.Add(new Truck(qWaitingTruck.Dequeue()));
                // 다리를 건너고 있는 트럭들의 무게 + 대기 중인 트럭의 무게 <= 다리가 견딜 수 있는 무게인지 확인
            }
        }

        return iElapsedTime;
        // 마지막으로 경과 시간을 반환
    }
}