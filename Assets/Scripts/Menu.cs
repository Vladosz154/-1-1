using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject button;
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Exit2()
    {
        Panel.SetActive(true);
        button.SetActive(false);
        Time.timeScale = 0;

    }
    public void Resume2()
    {
        Panel.SetActive(false);
        button.SetActive(true);
        Time.timeScale = 1;
    }
    public void Restart()
    { 
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    } 
}
