using UnityEngine;

public class ShootRandom : MonoBehaviour
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
    public int Radnum = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        FindRandomEnemy();
    }

    void FindRandomEnemy()
    {
        GameObject[] allenemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject randomEnemy = null;

        if (timer > shootDelay && Time.timeScale == 1)
        {
            timer = 0;

            ///Generate a random number
            Radnum = Random.Range(0, allenemies.Length);
            Debug.Log(Radnum);

            ///Use that random number to pick a randm enemy
            randomEnemy = allenemies[Radnum];
            Debug.DrawLine(this.transform.position, randomEnemy.transform.position);
            Vector2 enemyPos = randomEnemy.transform.position - this.transform.position;
            enemyPos.Normalize();
            GameObject bullet = Instantiate(bulletprefab, this.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = enemyPos * shootSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }

}
