using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.VFX;
using Unity.VisualScripting;

public class ShootEnemies : MonoBehaviour 
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bulletprefab;
    [SerializeField]
    float shootSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    [SerializeField]
    float shootDelay = 0.5f;
    float timer = 0;
    private void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;

        GameObject target = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemies.Length; i++)
        {
            Vector2 playerPos = player.transform.position;
            Vector2 tempEnemy;
            tempEnemy = enemies[i].transform.position;
            // Debug.Log(tempEnemy);
            float enemyDist = Vector2.Distance(tempEnemy, playerPos);
            float dist = 999;
            if (dist > enemyDist)
            {
                target = enemies[i];
                dist = enemyDist;
                Debug.Log("Closest enemy is at " + target.transform.position);
            }
            if (timer > shootDelay && Time.timeScale == 1)
            {
                timer = 0;
                // Fire a projectile in a straight line to the last known position of the closest enemy
                // spawn in the bullet
                Vector2 shootDir = target.transform.position - transform.position;
                GameObject bullet = Instantiate(bulletprefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().linearVelocity = shootDir * shootSpeed;
                Destroy(bullet,bulletLifetime);

                Debug.Log("Should have fired towards " + target.transform.position);
            }
        }
        // find enemies on the screen

        // for every enemy, find their position and save it (maybe in a list?)
        // and for now, debug it to show the code works
    }

}



