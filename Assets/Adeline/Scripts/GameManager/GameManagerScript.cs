using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject selectionBall;
    private GameObject balls;
    private GameObject spawnPoint;
    public delegate void StopTheBall();
    public static event StopTheBall StopTheBallEvent;
    void Start () {
        balls = GameObject.Find("Balls");
        spawnPoint = GameObject.Find("SpawnPoint");
        BallsInventory.GetInventoryBalls().Clear();
        this.EnableAllPlayerBalls();
        this.BlockAllBalls();
        StopTheBallEvent += StopBall;
    }
	
	// Update is called once per frame
	void Update () {

        if (!selectionBall.activeInHierarchy)
        {
            OnBallDrop();
            if (selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude < 1 && selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude > 0.3 )
            {
                Debug.Log("Velocity : " + selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude);
                StopTheBallEvent();
                OnBallStop();
            }
            else
            {
                selectionBall.GetComponent<SelectionBallScript>().SelectedBall.MoveTheBall();
            }
            //if (selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude != 0)
            //{
            //     OnBallDrop();

            //    if (selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude < 1)
            //    {
            //        selectionBall.GetComponent<SelectionBallScript>().SelectedBall.StopTheBall();
            //        OnBallStop();
            //    }
            //}


        }

    }
    private void StopBall()
    {
        Debug.Log("test");
        selectionBall.GetComponent<SelectionBallScript>().SelectedBall.StopTheBall();

    }

    public void OnBallStop()
    {
        selectionBall.GetComponent<SelectionBallScript>().ActiveChoosingBallsMenu();
    }

    public void OnBallDrop()
    {
        selectionBall.GetComponent<SelectionBallScript>().SelectedBall.BlockBallDropping();
    }

    public  void BlockAllBalls()
    {
        foreach (Ball ball in BallsInventory.GetInventoryBalls())
        {
            ball.BlockBallDropping();
        }
    }

    public void EnableAllPlayerBalls()
    {
        for (int i = 0; i < balls.transform.childCount; i++)
        {
            if (PlayerPrefs.GetInt(balls.transform.GetChild(i).gameObject.name) == 1)
            {
                balls.transform.GetChild(i).gameObject.SetActive(true);
                BallsInventory.GetInventoryBalls().Add((Ball)balls.transform.GetChild(i).gameObject.GetComponent<Ball>());
            }
            else
            {
                balls.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
