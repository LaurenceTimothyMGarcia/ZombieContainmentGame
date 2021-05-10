using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject inGameUI;
    public GameObject pauseUI;

    public GlobalHealth health;
    public static bool GameIsPaused = false;
    public float timeTillReset = 1f;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalHealth.PlayerHealth <= 0)
        {
            GlobalHealth.PlayerHealth = GlobalHealth.originalHealth;
            appear();
        }
    }

    void appear()
    {
        //AudioManager audio = GetComponent<AudioManager>();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);
        pauseUI.SetActive(false);
        //Time.timeScale = 0;
        //audio.GetComponent<AudioManager>().enabled = false;
        GameIsPaused = true;
        
    }

    public void restart()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void quit()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
