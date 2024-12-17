using UnityEngine;
using UnityEngine.SceneManagement;

public class AETestDifficult : MonoBehaviour
{
    [SerializeField]
    string TestScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAE()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(TestScene);
    }
}
