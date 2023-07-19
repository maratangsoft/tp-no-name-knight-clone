using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Champions")]
    [SerializeField] private GameObject[] champions;
    [SerializeField] private Transform championsParent;

    [Header("Enemies")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform enemiesParent;

    // 아군 및 적 오브젝트 생성하고 JSON에서 불러온 스탯과 스킬을 오브젝트에 전달
    public void SpawnCharacters(List<Status> statusList, List<Skill> skillList)
    {
        foreach (var champion in champions)
        {
            GameObject champObject = Instantiate(champion, championsParent);
            Champion champScript = champObject.GetComponent<Champion>();
            string charaId = champScript.CharacterId;

            Status status = GetStatus(statusList, charaId);
            Skill skill = GetSkill(skillList, status.SkillId);

            champScript.BindStatusAndSkill(status, skill);
        }
            
        foreach (var enemy in enemies)
        {
            GameObject enemyObject = Instantiate(enemy, enemiesParent);
            Enemy enemyScript = enemyObject.GetComponent<Enemy>();
            string charaId = enemyScript.CharacterId;

            // 적은 스킬이 없음
            Status status = GetStatus(statusList, charaId);

            enemyScript.BindStatusAndSkill(status, null);
        }
    }

    public Status GetStatus(List<Status> statusList, string charaId)
    {
        Debug.Log("getStatus");
        Status status = null;
        foreach (Status item in statusList)
            if (item.CharaId == charaId) status = item;

        return status;
    }

    public Skill GetSkill(List<Skill> skillList, string skillId)
    {
        Debug.Log("getSkill");
        Skill skill = null;
        foreach (var item in skillList)
            if (item.SkillId == skillId) skill = item;

        return skill;
    }
}
