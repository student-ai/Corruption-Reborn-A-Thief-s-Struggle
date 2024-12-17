using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float easy_health = 3;
    [SerializeField]
    float medium_health = 4;
    [SerializeField]
    float hard_health = 5;
    /// <summary>
    /// Image healthBar;
    /// </summary>
    float maxHealth;
    public GameObject GameManager;
    public GameManagerScript difffinder;
    // Start is called before the first frame update
    void Start()
    {

        ///healthBar = GetComponentsInChildren<Image>()[1] ;
        ///healthBar.fillAmount = health / maxHealth;
        ///
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        difffinder = Object.FindAnyObjectByType<GameManagerScript>();

        if (difffinder.difficulty == 0)
        {
            maxHealth = easy_health;
        }
        if (difffinder.difficulty == 1)
        {
            maxHealth = medium_health;
        }
        if (difffinder.difficulty == 2)
        {
            maxHealth = hard_health;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            maxHealth -= 1;
            ///healthBar.fillAmount = health / maxHealth;
            if (maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
