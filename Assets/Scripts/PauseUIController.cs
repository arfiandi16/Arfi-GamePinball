using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUIController : MonoBehaviour
{
    public Button pauseButton;
    public Button mainMenuButton;
    public Button backButton;
    public GameObject panelPause;
    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        pauseButton.onClick.AddListener(PauseGame);
        backButton.onClick.AddListener(BackToGame);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToGame()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
    }
    public void PauseGame()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }
}
