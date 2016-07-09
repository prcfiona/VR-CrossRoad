using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  //加载场景

public class GameLoader : MonoBehaviour
{
    public void LoadGame()
    {
        //Debug.Log("game load");
        SceneManager.LoadScene("Main");
    }
	
}
