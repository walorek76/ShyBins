using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    public int damage;

    private void Start()
    {
        // damage = Stats.Instance.Damage;
        damage = 1;
    }
    void Awake()
    {
        Destroy(gameObject,life);
    }
    void OnTriggerEnter2D(Collider2D collision)
{
    
    if (collision.CompareTag(gameObject.tag)) return;

    
    if (collision.CompareTag("SolidObjects"))
    {
        Destroy(gameObject);
        return;
    }

    
    PlayerHealth targetHealth = collision.GetComponent<PlayerHealth>();
    if (targetHealth != null)
    {
        targetHealth.TakeDamage(damage);
    }

    
    Destroy(gameObject);
}

    
}
