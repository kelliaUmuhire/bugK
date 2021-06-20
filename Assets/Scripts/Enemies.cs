using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Enemy[] enemies;
    private int count;
    public int timeBetween;
    public int distanceBetween;

    [HideInInspector]
    public Transform player;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        count = 0;
        StartCoroutine(waitDistance());
        GetEnemy();
    }

    public void GetEnemy()
    {
        // if (count < enemies.Length)
        // {
        //yield return new WaitForSeconds(timeBetween);

        Vector2 randomPosition = new Vector2(-player.position.x*count* distanceBetween, player.position.y);
        Instantiate(enemies[count], randomPosition, player.rotation);
        Debug.Log("Count "+ count);

        //yield break;

        //yield return new WaitForSeconds(distanceBetween);


        // }
        // else
        //{
        //      Debug.Log("Out of enemies");
        // }
    }

    IEnumerator waitDistance()
    {
        yield return new WaitForSeconds(distanceBetween);
    }
    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            if (count + 1 < enemies.Length)
            {
                count++;
                //Debug.Log("Count " + count);
                GetEnemy();
                StartCoroutine(waitDistance());
            }
        }
        else
        {
            Debug.Log("Finished for good "+ GameObject.FindGameObjectsWithTag("Enemy").Length);
        }
        
    }
}
