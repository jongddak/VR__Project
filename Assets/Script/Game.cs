using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject clear;
    [SerializeField] GameObject over;  

    [SerializeField] GameObject reLoad;
    [SerializeField] GameObject Quit;

    private void Awake()
    {
        clear.SetActive(false);
        over.SetActive(false);
        reLoad.SetActive(false);
        Quit.SetActive(false);
    }
    public void GameClear()
    {
        clear.SetActive(true);
        reLoad.SetActive(true);
        Quit.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        over.SetActive(true);
        reLoad.SetActive(true);
        Quit.SetActive(true);
        Time.timeScale = 0;
    }

    public void reLoadSc()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void QuitSc()
    {
        Application.Quit();
    }
}
