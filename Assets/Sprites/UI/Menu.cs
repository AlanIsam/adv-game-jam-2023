using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{

    public GameObject optionsPopout;
    public GameObject winPopout;


    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Restart()
    {
        Destroy(GameObject.FindWithTag("LevelTravel"));
        SceneManager.LoadScene("Level1");
    }

    public void openOptions()
    {
        optionsPopout.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeOptions()
    {
        optionsPopout.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Destroy(this.gameObject);
        Debug.Log("QUIT!");
        //Application.Quit();
        SceneManager.LoadScene("Menu");
    }

    public void winPanel()
    {
        winPopout.SetActive(false);
        Time.timeScale = 1;

    }
}