using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public GameObject VictoryUI;
    public GameObject inGameUI;
    public GameObject pauseUI;

    public static bool GameIsPaused = false;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }


    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            appear();
        }
    }

    void appear()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        VictoryUI.SetActive(true);
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
