using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;   
    public GameObject pauseMenuUI;
    public GameObject winMenu;
    
   public void onCLick()
    {
        Pause();
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f ; 
        GameIsPaused = false;
    }
   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f ; 
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log ("QG ");
        Application.Quit();
    }
    public void Update()
    {
        if(Movement.locked == true && mov1.locked == true && mov2.locked == true && mov3.locked == true && mov4.locked == true && mov5.locked == true && mov6.locked == true)
        winMenu.SetActive(true);
    }
}
