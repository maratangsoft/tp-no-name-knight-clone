using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : Character
{
    Coroutine damageCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            float damage = other.GetComponent<Character>().Attack;
            float interval = other.GetComponent<Character>().AttackInterval;
            damageCoroutine = StartCoroutine(OnDamage(damage, interval));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
}
