using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Character Information")]
    [SerializeField] private TextAsset statusFile;
    [SerializeField] private TextAsset skillFile;

    [Header("Others")]
    [SerializeField] private SpawnManager spawnManager;

    List<Status> _statusList;
    List<Skill> _skillList;

    private void Start()
    {
        _statusList = LoadJsonResource<StatusListWrapper>(statusFile).StatusList;
        _skillList = LoadJsonResource<SkillListWrapper>(skillFile).SkillList;

        _statusList.ForEach(status => Debug.Log(status.CharaId));
        _skillList.ForEach(status => Debug.Log(status.SkillId));

        spawnManager.SpawnCharacters(_statusList, _skillList);
    }

    T LoadJsonResource<T>(TextAsset file)
    {
        //TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        string jsonString = file.text;
        Debug.Log(jsonString);
        return JsonUtility.FromJson<T>(jsonString);
    }
}
