using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotEnemy1 : Enemy
{
    public float stopDistance;
    private float attackTime;
    public float attackSpeed;
    public float shotTime;
    public float timeBetweenShots;

    public Transform shotPoint;
    public GameObject projectile;

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                Debug.Log("Stopped");
                if (Time.time >= attackTime)
                {
                    //attack
                    attackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        Quaternion rotation = Quaternion.AngleAxis(90, Vector3.forward);

        Instantiate(projectile, shotPoint.position, rotation);
       // shotTime = Time.time + timeBetweenShots;

        yield return null;
    }
}
