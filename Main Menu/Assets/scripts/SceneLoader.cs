using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void PlayGame()
    {
        int x = Random.Range(1, 9);
        SceneManager.LoadScene(x);

    }
    public void QuitGame()
    {
        Application.Quit(0);
    }

}
