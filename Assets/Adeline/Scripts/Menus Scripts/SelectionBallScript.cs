using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBallScript : MonoBehaviour {

    public Ball SelectedBall;
    public GameObject balls;
    // Use this for initialization
    void Start () {

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
        if (BallsInventory.GetInventoryBalls().IndexOf(SelectedBall) < BallsInventory.GetInventoryBalls().Count-1)
        {
            SelectedBall = (Ball)BallsInventory.GetInventoryBalls()[BallsInventory.GetInventoryBalls().IndexOf(SelectedBall) + 1];
        }
        else
        {
            SelectedBall = (Ball)BallsInventory.GetInventoryBalls()[0];
        }

    }

    public void SelectPreviousBall()
    {
        if (BallsInventory.GetInventoryBalls().IndexOf(SelectedBall) > 0)
        {
            SelectedBall = (Ball)BallsInventory.GetInventoryBalls()[BallsInventory.GetInventoryBalls().IndexOf(SelectedBall) - 1];
        }
        else
        {
            SelectedBall = (Ball)BallsInventory.GetInventoryBalls()[BallsInventory.GetInventoryBalls().Count-1];
        }

    }

}
