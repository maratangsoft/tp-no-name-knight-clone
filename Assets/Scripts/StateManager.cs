using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    CHAMPION,
    ENEMY
}

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private CharacterType characterType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
