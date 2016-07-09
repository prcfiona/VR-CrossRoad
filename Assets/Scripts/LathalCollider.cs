using UnityEngine;
using System.Collections;

public class LathalCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Player player = GameObject.FindObjectOfType<Player>();
        if (player != null)
        {
            GameState state = GameObject.FindObjectOfType<GameState>();
            state.isGameOver = true;
        }
    }
}
