using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public Button mainMenuButton;
    public Button restartButton;
    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        restartButton.onClick.AddListener(Restart);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
