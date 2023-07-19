using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillList
{
    [SerializeField] List<Skill> skillList;
}

[Serializable]
public class Skill
{
    [SerializeField] private string skillId;
    [SerializeField] private string skillName;
    [SerializeField] private int targetType;
    [SerializeField] private int targetStat;
    [SerializeField] private float effect;
    [SerializeField] private float duration;
    [SerializeField] private float initCooltime;
    [SerializeField] private float cooltime;

    public string SkillId { get => skillId; }
    public string SkillName { get => skillName; }
    public int TargetType { get => targetType; }
    public int TargetStat { get => targetStat; }
    public float Effect { get => effect; }
    public float Duration { get => duration; }
    public float InitCooltime { get => initCooltime; }
    public float Cooltime { get => cooltime; }
}