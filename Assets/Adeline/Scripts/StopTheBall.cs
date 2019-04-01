using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheBall : MonoBehaviour {

    private GameObject selectionBall;
    private void Start()
    {
        selectionBall= GameObject.Find("selectionBall");
    }
    private void OnEnable()
    {
        GameManagerScript.StopTheBallEvent +=StopBall;
    }

    private void OnDisable()
    {
        GameManagerScript.StopTheBallEvent -= StopBall;
    }


    private void StopBall()
    {
        selectionBall.GetComponent<SelectionBallScript>().SelectedBall.StopTheBall();
        
    }

}
