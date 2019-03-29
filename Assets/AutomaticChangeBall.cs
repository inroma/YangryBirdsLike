using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticChangeBall : MonoBehaviour {

    public List<GameObject> listBalls;
    public GameObject currentBall;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ChangeBall());
    }
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator ChangeBall()
    {
        while(true)
            for (int i = 0; i < listBalls.Capacity; i++)
            {
                currentBall.SetActive(false);
                listBalls[i].SetActive(true);
                currentBall = listBalls[i];
                yield return new WaitForSeconds(5.0f);
            }
    }
}
