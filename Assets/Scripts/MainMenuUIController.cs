using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton, exitButton, creditButton;
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(CreditGame);
    }
    private void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }

    private void CreditGame()
    {
        SceneManager.LoadScene("Credits");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
