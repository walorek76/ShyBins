using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private AudioSource audioSource;
    private Rigidbody2D rb;
    private Vector2 lastShootDirection = Vector2.right; 

    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    private float coolDownTimer = Mathf.Infinity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (rb.velocity.sqrMagnitude > 0.01f)
        {
            lastShootDirection = rb.velocity.normalized;
        }


        if (Input.GetKeyDown(KeyCode.L) && coolDownTimer > attackCooldown)
        {
            audioSource.Play();
            Attack();
        }

        coolDownTimer += Time.deltaTime;
    }

    void Attack()
    {
        coolDownTimer = 0;


        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = lastShootDirection * bulletSpeed;


        float angle = Mathf.Atan2(lastShootDirection.y, lastShootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        bullet.tag = gameObject.tag;
    }
}
