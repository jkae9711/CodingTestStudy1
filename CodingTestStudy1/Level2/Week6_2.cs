// Week6_2 : 위장

using System.Collections;
using System.Collections.Generic;

public class Week6_2
{
    public int solution(string[,] clothes)
    {
        int iAnswer = 1;
        // 1인 이유 -> 곱해줄 예정이라서

        HashSet<string> hsType = new HashSet<string>();
        // 입력 clothes에서 옷 종류를 걸러내기 위한 HashSet

        Hashtable htClothesCountByType = new Hashtable();
        // 옷 종류별 개수를 저장하기 위한 Hashtable

        string[] strArrType;
        // HashSet 값을 배열로 복사하여 편하게 사용하기 위한 string 배열 선언

        for (int clothesIndex = 0; clothesIndex < clothes.GetLength(0); clothesIndex++)
            hsType.Add(clothes[clothesIndex, 1]);
        // 입력 clothes에서 옷 종류를 걸러냄

        strArrType = new string[hsType.Count];
        // 배열 개수 초기화

        hsType.CopyTo(strArrType);
        // HashSet -> strArr 복사

        for (int arrIndex = 0; arrIndex < hsType.Count; arrIndex++)
        {
            int iCount = 0;

            for (int clothesIndex = 0; clothesIndex < clothes.GetLength(0); clothesIndex++)
                if (strArrType[arrIndex].Equals(clothes[clothesIndex, 1]))
                    iCount++;

            htClothesCountByType.Add(strArrType[arrIndex], iCount);
            iCount = 0;
        }
        // 옷 종류별 개수를 카운트하여 Hashtable(htClothesCountByType)에 저장

        foreach (var item in htClothesCountByType.Values)
            iAnswer *= ((int)item + 1);
        // 경우의 수를 모두 곱함

        return iAnswer - 1;
        // 아무것도 입지 않는 경우 때문에 -1
    }
}