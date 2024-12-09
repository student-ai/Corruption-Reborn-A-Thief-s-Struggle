using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Rendering;

public class FromTheCat : MonoBehaviour 
{
    [SerializeField]
    GameObject bulletprefab;
    [SerializeField]
    float shootSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    [SerializeField]
    float shootDelay = 0.5f;
    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
        
        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }    
        }

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        if (timer > shootDelay && Time.timeScale == 1)
        {
            timer = 0;
            Vector2 enemyPos = closestEnemy.transform.position - this.transform.position;
            enemyPos.Normalize();
            GameObject bullet = Instantiate(bulletprefab, this.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = enemyPos * shootSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}
