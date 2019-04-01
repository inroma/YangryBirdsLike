using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBallScript : MonoBehaviour {

    public Ball SelectedBall;
    private GameObject balls;
    // Use this for initialization
    void Start () {
       
        balls = GameObject.Find("Balls");
        SelectedBall = balls.transform.GetChild(0).gameObject.GetComponent<Ball>();
        this.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayingTheBall()
    {
        this.gameObject.SetActive(false);
    }

    public void ActiveChoosingBallsMenu()
    {
        this.gameObject.SetActive(true);
    }


    public void SelectNextBall()
    {
        if (BallsInventory.GetSelectedBalls().IndexOf(SelectedBall) < BallsInventory.GetSelectedBalls().Count-1)
        {
            SelectedBall = (Ball)BallsInventory.GetSelectedBalls()[BallsInventory.GetSelectedBalls().IndexOf(SelectedBall) + 1];
        }
        else
        {
            SelectedBall = (Ball)BallsInventory.GetSelectedBalls()[0];
        }

    }

    public void SelectPreviousBall()
    {
        if (BallsInventory.GetSelectedBalls().IndexOf(SelectedBall) > 0)
        {
            SelectedBall = (Ball)BallsInventory.GetSelectedBalls()[BallsInventory.GetSelectedBalls().IndexOf(SelectedBall) - 1];
        }
        else
        {
            SelectedBall = (Ball)BallsInventory.GetSelectedBalls()[BallsInventory.GetSelectedBalls().Count-1];
        }

    }

}
