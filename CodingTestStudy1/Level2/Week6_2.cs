// Week6_2 : 위장

using System.Collections;
using System.Collections.Generic;

public class Week6_2
{
    public int solution(string[,] clothes)
    {
        int iAnswer = 1;
        HashSet<string> hsType = new HashSet<string>();
        Hashtable htClothesCountByType = new Hashtable();
        string[] strArrType;

        for (int clothesIndex = 0; clothesIndex < clothes.GetLength(0); clothesIndex++)
            hsType.Add(clothes[clothesIndex, 1]);

        strArrType = new string[hsType.Count];
        hsType.CopyTo(strArrType);

        for (int arrIndex = 0; arrIndex < hsType.Count; arrIndex++)
        {
            int iCount = 0;

            for (int clothesIndex = 0; clothesIndex < clothes.GetLength(0); clothesIndex++)
                if (strArrType[arrIndex].Equals(clothes[clothesIndex, 1]))
                    iCount++;

            htClothesCountByType.Add(strArrType[arrIndex], iCount);
            iCount = 0;
        }

        foreach (var item in htClothesCountByType.Values)
            iAnswer *= ((int)item + 1);

        return iAnswer - 1;
    }
}