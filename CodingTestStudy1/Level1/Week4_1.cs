// #Week4_1 : 신고 결과 받기

using System.Collections.Generic;
using System.Linq;

public class Week4_1
{
    public int[] solution(string[] id_list, string[] report, int k)
    {
        Dictionary<string, List<string>> dicIDReportList = new Dictionary<string, List<string>>();
        // ID별 신고한 ID의 리스트를 저장하는 Dictionary

        Dictionary<string, int> dicIDReportedCount = new Dictionary<string, int>();
        // ID별 신고당한 횟수를 저장하는 Dictionary

        List<int> lstIDReceivedMailCount = new List<int>();
        // ID별 메일을 받게될 횟수를 저장하는 List

        dicIDReportList = report.Distinct()
                            .GroupBy(x => x.Split(' ')[0], x => x.Split(' ')[1])
                            .ToDictionary(g => g.Key, g => g.ToList());
        // ID별 신고한 ID의 리스트를 저장

        for (int iIndex = 0; iIndex < id_list.Length; iIndex++)
        {
            int iCountReported = 0;

            foreach (var item in dicIDReportList.Values)
                if (item.Contains(id_list[iIndex]))
                    iCountReported++;

            dicIDReportedCount.Add(id_list[iIndex], iCountReported);
        }
        // ID별 신고당한 횟수를 저장

        for (int iIndex = 0; iIndex < id_list.Length; iIndex++)
        {
            if (dicIDReportList.ContainsKey(id_list[iIndex]))
            {
                int iCountReceivedMailCount = (from item in dicIDReportList[id_list[iIndex]]
                                               where dicIDReportedCount[item] >= k
                                               select item).Count();

                lstIDReceivedMailCount.Add(iCountReceivedMailCount);
            }
            else
                lstIDReceivedMailCount.Add(0);
        }
        // ID별 메일을 받게될 횟수를 저장

        return lstIDReceivedMailCount.ToArray();
    }
}