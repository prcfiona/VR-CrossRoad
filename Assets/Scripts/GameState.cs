using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public bool isGameOver { get; set; }

    public void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Back()
    {
        SceneManager.LoadScene("Start");
    }
}
