using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;

    private Animator anim;

    public float health;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //transform.position = transform.position + new Vector3(0.1f, 0,0);
        Shot();
    }

    public void Shot()
    {
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        //transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                anim.SetTrigger("Shoot");
                //yield return new WaitForSeconds(0.1);
                Instantiate(projectile, shotPoint.position, rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (health - damage < 1)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }
    }

    public void Heal(int val)
    {
        if(health + val > 10)
        {
            health = 10;
        }
        else
        {
            health += val;
        }
    }
}
