using UnityEngine;
using System.Collections;

public class Spawer : MonoBehaviour {

    public GameObject[] lanePerfabs;
    public float spawnHorizon = 500f;
    public float laneWidth = 2f;
    public GameObject player;
    public Transform spawnParent;

    private float nextLaneOffset =0f;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        float forwardPosition = player.transform.position.z;
        while(forwardPosition + spawnHorizon > nextLaneOffset)
        {
            int randomLaneIndex = Random.Range(0, lanePerfabs.Length);
            GameObject lane = lanePerfabs[randomLaneIndex];
            Vector3 nextLanePosition = nextLaneOffset * Vector3.forward;
            GameObject newLaneObject =  Instantiate(lane, nextLanePosition, Quaternion.identity) as GameObject;
            newLaneObject.transform.parent = spawnParent;
            nextLaneOffset += laneWidth;
        }
    }
}
