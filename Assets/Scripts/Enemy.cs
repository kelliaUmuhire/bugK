using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public float speed;

    public float timeBetweenAttacks;

    public int damage;

    public GameObject explosion;

    [HideInInspector]
    public Transform player;

    public Player playerScript;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = FindObjectOfType<Player>();
    }

    void DestroyEnemy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        playerScript.Heal(health);
        Destroy(gameObject);
        
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            //Destroy(gameObject);
            DestroyEnemy();
        }
    }
}
