using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticChangeBall : MonoBehaviour {

    public List<GameObject> listBalls;
    private GameObject currentBall;

    // Use this for initialization
    void Start()
    {
        currentBall = this.GetComponentInChildren<GameObject>();
        StartCoroutine(ChangeBall());
    }
	
	// Update is called once per frame
	void Update () {
        currentBall = this.GetComponentInChildren<GameObject>();
    }

    IEnumerator ChangeBall()
    {
        foreach (GameObject ball in listBalls)
        {
            currentBall.SetActive(false);
            ball.SetActive(true);
            yield return new WaitForSeconds(3);
        }
    }
}
