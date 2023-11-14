using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame(){
        SceneManager.LoadScene("MainMenu");
    }

    public void resetGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void exitApp(){
        Application.Quit();
    }
}
