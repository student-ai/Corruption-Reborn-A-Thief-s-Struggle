using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class countdownTimer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    public float timeLeft;

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft < 0)
        {
            timeLeft = 0;
            timerText.color = Color.red;
        }

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
