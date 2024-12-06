using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindEnemies : MonoBehaviour 
{
    [SerializeField]
    GameObject player;
    private void Start()
    {
        string playername = player.name;
        Debug.Log(playername);
    }

    void Update()
    {
        // find enemies on the screen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // for every enemy, find their position and save it (maybe in a list?)
        // and for now, debug it to show the code works
        for(int i = 0; i < enemies.Length; i++)
        {

            Vector2 tempEnemy;
            tempEnemy = enemies[i].transform.position;
            // Debug.Log(tempEnemy);
            
        }
    }

}
