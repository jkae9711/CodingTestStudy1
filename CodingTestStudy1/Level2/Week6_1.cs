// #Week6_1 : 다리를 지나는 트럭

using System.Collections.Generic;

public class Week6_1
{
    public class Truck
    {
        public int iCurrentLocation;
        public int iWeight;

        public Truck(int weight)
        {
            iCurrentLocation = 1;
            iWeight = weight;
        }
    }

    public int solution(int bridge_length, int weight, int[] truck_weights)
    {
        int iElapsedTime = 0;
        Queue<int> qWaitingTruck = new Queue<int>(truck_weights);
        List<Truck> lstBridge = new List<Truck>();

        while (qWaitingTruck.Count > 0 || lstBridge.Count > 0)
        {
            iElapsedTime++;

            if (lstBridge.Count > 0)
            {
                int iCountListBridge = lstBridge.Count;

                for (int iIndex = iCountListBridge - 1; iIndex >= 0; iIndex--)
                {
                    var CurrentTruck = lstBridge[iIndex];

                    CurrentTruck.iCurrentLocation++;

                    if (CurrentTruck.iCurrentLocation > bridge_length)
                        lstBridge.RemoveAt(iIndex);
                }
            }

            if (qWaitingTruck.Count > 0)
            {
                int iWeightSum = 0;

                foreach (var truck in lstBridge)
                    iWeightSum += truck.iWeight;

                if (iWeightSum + qWaitingTruck.Peek() <= weight)
                    lstBridge.Add(new Truck(qWaitingTruck.Dequeue()));
            }
        }

        return iElapsedTime;
    }
}