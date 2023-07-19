using UnityEngine;

public class Champion : Character
{
    Coroutine damageCoroutine;

    // 적 근접유닛 및 적 발사체와 충돌시 코루틴으로 대미지 입는 로직 반복
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Character enemy = other.GetComponent<Character>();
            float damage = enemy.AttackPower;
            float interval = enemy.AttackInterval;
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
