using UnityEngine;
using System.Collections;

public class countdown : MonoBehaviour {

    private GameManager GMS;

    public void setCountdownDone()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        GMS.countDown = true;
    }
}
