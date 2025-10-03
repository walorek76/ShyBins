using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; 
    private Rigidbody2D rb;
    private Vector2 lastShootDirection = Vector2.right; // domyślnie w prawo

    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private float coolDownTimer = Mathf.Infinity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // aktualizujemy ostatni kierunek gdy gracz się porusza
        if (rb.velocity.sqrMagnitude > 0.01f) // zamiast .normalized == Vector2.zero
        {
            lastShootDirection = rb.velocity.normalized;
        }

        // strzał po wciśnięciu F
        if (Input.GetKeyDown(KeyCode.F) && coolDownTimer > attackCooldown)
        {
            Attack();
        }

        coolDownTimer += Time.deltaTime;
    }

    void Attack()
    {
        coolDownTimer = 0;

        // Tworzymy pocisk
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = lastShootDirection * bulletSpeed;

        // Opcjonalnie: obrót pocisku w stronę kierunku lotu
        float angle = Mathf.Atan2(lastShootDirection.y, lastShootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
