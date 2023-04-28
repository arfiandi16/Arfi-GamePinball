using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameOverUIController gameOverUIController;
    public GameObject gameOverCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            gameOverCanvas.SetActive(true);
        }
    }

}
