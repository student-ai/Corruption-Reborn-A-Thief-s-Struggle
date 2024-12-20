using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public MobilePauseButton PauseButton;
    // Use this for initialization
    void Start()
    {
        InputSystem.EnableDevice(Keyboard.current);
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1 || PauseButton.Paused == true && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            InputSystem.DisableDevice(Keyboard.current);
            GetComponent<Canvas>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        InputSystem.EnableDevice(Keyboard.current);
        PauseButton.Paused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        PauseButton.Paused = false;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PauseButton.Paused = false;
    }
}
