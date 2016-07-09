using UnityEngine;
using System.Collections;

public class GameOverMessage : MonoBehaviour
{

    public float UIDistance = 5f;
    public float UIHeight = 2f;

    private Player player;
    private Canvas canvas;
    private GameState state;

    void Start ()
    {
        player = GameObject.FindObjectOfType<Player>();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        state = GameObject.FindObjectOfType<GameState>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (state.isGameOver)
	    {
            TrackPlayerHead();
            canvas.enabled = true;
        }
	}

    void TrackPlayerHead()
    {
        transform.rotation = Quaternion.LookRotation(player.LookDirection());   //根据镜头方向旋转
        transform.position = player.transform.position;
        transform.position += player.LookDirection() * UIDistance;
        transform.position += Vector3.up * UIHeight;
    }
}
