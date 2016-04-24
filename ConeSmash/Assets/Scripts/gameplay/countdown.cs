using UnityEngine;
using System.Collections;

public class countdown : MonoBehaviour {

    private GameManager GMS;

    public void setCountdownDone()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        GMS.countDown = true;
        GMS.controller.SetActive(true);
        GMS.pauseButton.SetActive(true);

        GMS.SetCountText(); //probably move elsewhere along with timertext

    }
}
