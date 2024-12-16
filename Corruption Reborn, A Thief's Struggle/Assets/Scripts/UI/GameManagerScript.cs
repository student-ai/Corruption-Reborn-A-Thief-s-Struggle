using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


public class GameManagerScript : MonoBehaviour
{
    public DropdownSelectionChecker difffinder;
    public float difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficulty = difffinder.difficulty;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
