using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string characterId;

    protected bool isAlive = true;

    protected float maxHp;
    protected float currentHp;
    private float attackPower;
    protected float armor;
    private float attackInterval;
    protected float attackRange;
    protected float speed;
    protected string skillId;

    protected string skillName;
    protected int targetType;
    protected int targetStat;
    protected float effect;
    protected float duration;
    protected float initCooltime;
    protected float cooltime;

    public string CharacterId { get => characterId; }
    public float AttackPower { get => attackPower; }
    public float AttackInterval { get => attackInterval; }

    public void BindStatusAndSkill(Status status, Skill skill)
    {
        maxHp = status.Hp;
        currentHp = maxHp;
        attackPower = status.AttackPower;
        armor = status.Armor;
        attackInterval = status.AttackInterval;
        speed = status.Speed;
        skillId = status.SkillId;

        // 아군 한정. 적은 스킬이 없음
        if (skill != null)
        {
            skillName = skill.SkillName;
            targetType = skill.TargetType;
            targetStat = skill.TargetStat;
            effect = skill.Effect;
            duration = skill.Duration;
            initCooltime = skill.InitCooltime;
            cooltime = skill.Cooltime;
        }
    }

    protected IEnumerator OnDamage(float damage, float interval)
    {
        currentHp -= (damage - armor);
        if (currentHp <= 0) Die();

        yield return new WaitForSeconds(interval);
    }

    void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
    }
}
