using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusListWrapper
{
    [SerializeField] List<Status> statusList;

    public List<Status> StatusList { get => statusList; }
}

[Serializable]
public class Status
{
    [SerializeField] private string charaId;
    [SerializeField] private float hp;
    [SerializeField] private float attackPower;
    [SerializeField] private float armor;
    [SerializeField] private float attackInterval;
    [SerializeField] private float attackRange;
    [SerializeField] private float speed;
    [SerializeField] private string skillId;

    public string CharaId { get => charaId; }
    public float Hp { get => hp; }
    public float AttackPower { get => attackPower; }
    public float Armor { get => armor; }
    public float AttackInterval { get => attackInterval; }
    public float AttackRange { get => attackRange; }
    public float Speed { get => speed; }
    public string SkillId { get => skillId; }
}
