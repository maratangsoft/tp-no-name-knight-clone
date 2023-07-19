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
    private float attack;
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

    public float Attack { get => attack; }
    public float AttackInterval { get => attackInterval; }

    void Start()
    {
        Debug.Log("character Start");
        GameManager gameManager = GameManager.Instance;
        Status status = gameManager.GetStatus(characterId);
        Skill skill = gameManager.GetSkill(status.SkillId);
        BindStatusAndSkill(status, skill);

        Debug.Log(characterId);
        Debug.Log("hp: " + maxHp);
        Debug.Log("attack: " + attack);
        Debug.Log("armor: " + armor);
    }

    void BindStatusAndSkill(Status status, Skill skill)
    {
        maxHp = status.Hp;
        currentHp = maxHp;
        attack = status.Attack;
        armor = status.Armor;
        attackInterval = status.AttackInterval;
        speed = status.Speed;
        skillId = status.SkillId;

        skillName = skill.SkillName;
        targetType = skill.TargetType;
        targetStat = skill.TargetStat;
        effect = skill.Effect;
        duration = skill.Duration;
        initCooltime = skill.InitCooltime;
        cooltime = skill.Cooltime;
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
