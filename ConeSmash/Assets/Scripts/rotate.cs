using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

    float startTime;

	// Use this for initialization
	void Start () {

        startTime = Time.deltaTime;
        Debug.Log("Start time: " + startTime);

	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAroundLocal(Vector3.up, Time.deltaTime);
        
        if(transform.rotation.y > 350)
        {
            float endTime = Time.deltaTime - startTime;
            Debug.Log("360 time: " + endTime);
        }

    }
}
