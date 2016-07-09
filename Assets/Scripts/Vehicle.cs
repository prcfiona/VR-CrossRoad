using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{

    private float speed = 5.0f;
    private float length;

    void Start ()
    {
        float lifeTime = length/speed;
        Invoke("Remove",lifeTime);
    }
	
	void Update ()
	{
	    transform.position += Vector3.right*speed*Time.deltaTime;
	}
    //的到速度，方便在vehicleSpawner下修改速度
    public void SetPath(float someSpeed,float someLifeTime)
    {
        speed = someSpeed;
        length = someLifeTime;
    }
    //销毁车辆
    public void Remove()
    {
        Destroy(gameObject);
    }
}
