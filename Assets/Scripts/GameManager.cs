using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    [SerializeField] private TextAsset statusFile;
    [SerializeField] private TextAsset skillFile;

    List<Status> _statusList;
    List<Skill> _skillList;

    public static GameManager Instance { get => _instance; }

    private void Awake()
    {
        _instance = this;
        _statusList = LoadJsonResource<List<Status>>(statusFile);
        _skillList = LoadJsonResource<List<Skill>>(skillFile);
    }

    T LoadJsonResource<T>(TextAsset file)
    {
        Debug.Log("load json");
        //TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        string jsonString = file.text;
        return JsonUtility.FromJson<T>(jsonString);
    }

    public Status GetStatus(string charaId)
    {
        Debug.Log("getStatus");
        Status status = null;
        foreach (Status item in _statusList)
            if (item.CharaId == charaId) status = item;

        return status;
    }

    public Skill GetSkill(string skillId)
    {
        Debug.Log("getSkill");
        Skill skill = null;
        foreach (var item in _skillList)
            if (item.SkillId == skillId) skill = item;

        return skill;
    }
}
