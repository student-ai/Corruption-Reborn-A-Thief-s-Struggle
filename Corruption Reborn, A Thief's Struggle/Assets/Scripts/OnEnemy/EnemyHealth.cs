using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameManagerScript findselecteddifficulty;
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
    // Start is called before the first frame update
    void Start()
    {

        ///healthBar = GetComponentsInChildren<Image>()[1] ;
        ///healthBar.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (findselecteddifficulty.difficulty == 0)
        {
            maxHealth = easy_health;
        }
        if (findselecteddifficulty.difficulty == 1)
        {
            maxHealth = medium_health;
        }
        if (findselecteddifficulty.difficulty == 2)
        {
            maxHealth = hard_health;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float health = maxHealth;   
        if(collision.gameObject.tag == "PlayerBullet")
        {
            health -= 1;
            ///healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
