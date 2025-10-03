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
    }
    void Awake()
    {
        Destroy(gameObject,life);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != gameObject.tag) { 
            Destroy(gameObject);
        }
    }
    
}
