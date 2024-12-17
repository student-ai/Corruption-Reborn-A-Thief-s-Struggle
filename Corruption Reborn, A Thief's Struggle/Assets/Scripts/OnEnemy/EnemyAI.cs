using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    float chaseSpeed;
    [SerializeField]
    float chaseTriggerDistance = 5.0f;
    [SerializeField]
    bool returnHome = true;
    Vector3 home;
    float timer = 0;
    [SerializeField]
    float returnDelay = 0f;
    [SerializeField]
    float easy_chaseSpeed = 5f;
    [SerializeField]
    float medium_chaseSpeed = 10f;
    [SerializeField]
    float hard_chaseSpeed = 15f;
    public GameObject GameManager;
    public GameManagerScript difffinder;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;

        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        difffinder = Object.FindAnyObjectByType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (difffinder.difficulty == 0)
        {
            chaseSpeed = easy_chaseSpeed;
        }
        if (difffinder.difficulty == 1)
        {
            chaseSpeed = medium_chaseSpeed;
        }
        if (difffinder.difficulty == 2)
        {
            chaseSpeed = hard_chaseSpeed;
        }


        timer += Time.deltaTime;
        // If the player gets too close
        Vector3 playerPosition = player.transform.position;
        Vector3 chaseDir = playerPosition - transform.position;
        Vector3 homeDir = home - transform.position;
        if (chaseDir.magnitude < chaseTriggerDistance)
        {
            // Chase the player
            // Chase direction = players position - my current position (enemy pos')
            // Move in the direction of the player
            timer = 0;
            chaseDir.Normalize();
            GetComponent<Rigidbody2D>().linearVelocity = chaseDir * chaseSpeed;
        }
        else if (returnHome && homeDir.magnitude > 0.2f)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            // Return home
            if (timer > returnDelay)
            {
                homeDir.Normalize();
                GetComponent<Rigidbody2D>().linearVelocity = homeDir * chaseSpeed;

            }
        }
        else
        {
            // If the player is not close & we're not trying to return home, stop moving
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        }
    }
}