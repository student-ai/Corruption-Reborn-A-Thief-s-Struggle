using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindEnemies : MonoBehaviour 
{
    private void Start()
    {
    }

    void Update()
    {
        // find enemies on the screen
        GameObject[] positions = GameObject.FindGameObjectsWithTag("Enemy");

        // for every enemy, find their position and save it (maybe in a list?)
        // and for now, debug it to show the code works
        for(int i = 0; i < positions.Length; i++)
        {

            Vector2 tempEnemy;
            tempEnemy = positions[i].transform.position;
            Debug.Log(tempEnemy);
        }
    }

}
