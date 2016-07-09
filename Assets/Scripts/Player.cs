using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float jumpAngleIndegree=32;
    public float jumpSpeed=8;
    //public Text gazeText;

    private CardboardHead head;
    private Rigidbody rb;
    private bool onFloor = true;
    private float lastJumpRequestTime = 0.0f;
    private GameState state;

    void Start()
    {
        Cardboard.SDK.OnTrigger += PullTrigger;
        head = GameObject.FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
        state = GameObject.FindObjectOfType<GameState>();
    }

    void Update()
    {
        //gazeText.text = head.Gaze.ToString();
    }
    private void PullTrigger()
    {
        RequestJump();
    }

    private void RequestJump()
    {
        if (!state.isGameOver)
        {
            lastJumpRequestTime = Time.time;
            rb.WakeUp();
        }
    }

    private void Jump()
    {
        float jumpAngleInRadians = jumpAngleIndegree * Mathf.Deg2Rad;   //Mathf.Deg2Rad 度转弧度
        Vector3 jumpVector = Vector3.RotateTowards(LookDirection(), Vector3.up, jumpAngleInRadians, 0);
        rb.velocity = jumpVector * jumpSpeed;
    }

    public Vector3 LookDirection()
    {
        return Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.up);
    }

    void OnCollisionStay(Collision collision)
    {
        float delta = Time.time - lastJumpRequestTime;
        if (delta<0.1)
        {
            Jump();
            lastJumpRequestTime = 0.0f;
        }
    }
    
}
