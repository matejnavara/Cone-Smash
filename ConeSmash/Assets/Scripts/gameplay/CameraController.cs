using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


	// Use this for initialization
	void Start () {
        playerCheck();
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        playerCheck();
        transform.position = player.transform.position + offset;
	
	}

    void playerCheck()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

}
