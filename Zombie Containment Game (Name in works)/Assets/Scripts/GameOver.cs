using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject inGameUI;
    public GameObject pauseUI;

    public GlobalHealth health;
    public static bool GameIsPaused = false;

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
            appear();
        }
    }

    void appear()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);
        pauseUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
