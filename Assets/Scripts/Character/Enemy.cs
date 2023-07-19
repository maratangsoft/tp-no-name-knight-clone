using UnityEngine;

public class Enemy : Character
{
    Coroutine damageCoroutine;

    // 아군 근접유닛 및 아군 발사체와 충돌시 코루틴으로 대미지 입는 로직 반복
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("champion"))
        {
            Character champion = other.GetComponent<Character>();
            float damage = champion.AttackPower;
            float interval = champion.AttackInterval;

            damageCoroutine = StartCoroutine(OnDamage(damage, interval));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("champion"))
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
}
