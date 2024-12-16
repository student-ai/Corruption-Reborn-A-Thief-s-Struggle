using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Leveloader : MonoBehaviour
{
    [SerializeField]
    string nextLevel;

    public countdownTimer countdown;

    public DropdownSelectionChecker FindSelectedDifficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.timeLeft > 0)
        {
            countdown.timeLeft -= Time.deltaTime;
        }
        else if (countdown.timeLeft <= 0)
        {
            SceneManager.LoadScene(nextLevel);
        }

        
    }


}