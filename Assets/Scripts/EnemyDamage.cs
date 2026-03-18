using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                PlayerHealth player = other.GetComponent<PlayerHealth>();

                if (player != null)
                {
                    player.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}