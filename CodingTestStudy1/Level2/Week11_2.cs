// Week11_2 : 스킬트리

using System.Collections.Generic;
using System.Linq;

public class Week11_2
{
    public int solution(string skill, string[] skill_trees)
    {
        int answer = 0;
        // 선행스킬을 위반하지 않는 유저 스킬트리의 개수를 카운트하는 "문제의 답"

        bool bIsGoodSkillTree = true;
        // 유저의 스킬트리가 선행스킬을 위반하지 않는지 확인하기 위한 변수

        List<string> lstUserSkillTree = skill_trees.ToList();
        // 유저들의 스킬트리 입력 배열을 List로 저장하는 변수

        List<char> lstSkill = skill.ToList();

        for (int i = 0; i < skill_trees.Length; i++)
        {
            string strCurrentUserSkillTree = lstUserSkillTree[i];
            // 현재 루프에서 검사할 유저 스킬트리

            List<char> lstSkill_copy = new List<char>(lstSkill);
            // 유저 스킬트리가 선행 스킬을 만족할때마다 remove 하면서 검사하기 위해 선언

            for (int j = 0; j < strCurrentUserSkillTree.Length; j++)
            {
                if (lstSkill_copy.Count == 0)
                    break;

                if (lstSkill_copy.Contains(strCurrentUserSkillTree[j]))
                {
                    if (lstSkill_copy[0].Equals(strCurrentUserSkillTree[j]))
                        lstSkill_copy.RemoveAt(0);
                    else
                    {
                        bIsGoodSkillTree = false;

                        break;
                    }
                }
            }

            if (bIsGoodSkillTree == true)
                answer++;
            else
                bIsGoodSkillTree = true;
        }

        return answer;
    }
}