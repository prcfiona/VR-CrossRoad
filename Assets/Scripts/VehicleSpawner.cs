using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour
{

    public GameObject[] vehiclePerfab;
    public float hightOffset = 1f;
    public float startOffset = -10f;
    public float speed = 5.0f;
    public float length = 20.0f;
    public float maxSpwanTime = 10f;

    void Start ()
    {
        StartCoroutine("Spawn");
    }

    void InstantiateVehicle(int vehiclIndex)
    {
        GameObject vehicleObject = Instantiate(vehiclePerfab[0]);
        vehicleObject.transform.position = GetPositionOffset();
        vehicleObject.transform.parent = transform; //把车放到road下面

        Vehicle vehicleComponent = vehicleObject.GetComponent<Vehicle>();
        vehicleComponent.SetPath(speed, length);
    }

    Vector3 GetPositionOffset()
    {
        Vector3 positionOffset = transform.position;
        positionOffset += Vector3.up * hightOffset;
        positionOffset += Vector3.right * startOffset;
        return positionOffset;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            WaitForSeconds randomWait = new WaitForSeconds(Random.Range(0.5f,maxSpwanTime));    //随机生成等待时间
            yield return randomWait;

            int vehiclIndex = Random.Range(0, vehiclePerfab.Length);
            InstantiateVehicle(vehiclIndex);
        }
    }

}
