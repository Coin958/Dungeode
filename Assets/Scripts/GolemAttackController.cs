using System.Collections;
using UnityEngine;

public class GolemAttackController : MonoBehaviour
{
    [Header("General")]
    public Animator animator;

    private bool isAttacking = false;

    // =========================
    // Melee (Punch)
    // =========================
    [Header("Melee")]
    public float attackRange = 2f;
    public int damage = 20;
    public float punchDuration = 0.9f;
    public float punchCooldown = 0.5f;

    private float lastPunchTime;

    // =========================
    // Shoot (Projectile)
    // =========================
    [Header("Shoot")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootDelay = 0.5f;
    public float shootDuration = 1.1f;
    public float shootCooldown = 1f;

    private float lastShootTime;

    void Update()
    {
        HandlePunch();
        HandleShoot();
    }

    // Maneja el input del golpe
    void HandlePunch()
    {
        if (isAttacking) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= lastPunchTime + punchCooldown)
        {
            StartCoroutine(PunchCoroutine());
            lastPunchTime = Time.time;
        }
    }

    IEnumerator PunchCoroutine()
    {
        isAttacking = true;

        animator.ResetTrigger("Shoot");
        animator.SetTrigger("Punch");

        yield return new WaitForSeconds(0.2f);

        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange))
        {
            Debug.Log("Golpeaste: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(punchDuration - 0.2f);

        isAttacking = false;
    }

    // Maneja el input del disparo
    void HandleShoot()
    {
        if (isAttacking) return;

        if (Input.GetKeyDown(KeyCode.E) && Time.time >= lastShootTime + shootCooldown)
        {
            StartCoroutine(ShootCoroutine());
            lastShootTime = Time.time;
        }
    }

    IEnumerator ShootCoroutine()
    {
        isAttacking = true;

        animator.ResetTrigger("Punch");
        animator.SetTrigger("Shoot");

        yield return new WaitForSeconds(shootDelay);

        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        }

        yield return new WaitForSeconds(shootDuration - shootDelay);

        isAttacking = false;
    }
}