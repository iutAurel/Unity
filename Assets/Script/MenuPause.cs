using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamesIsPaused = false;
    [SerializeField] GameObject pauseMenu;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (GamesIsPaused)
            {
                Resume();
            }
            else
            {
                PauseMenu();
            }
            
        }
        


    }
    public void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamesIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamesIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("SceneMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
