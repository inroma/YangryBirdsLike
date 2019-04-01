using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public GameObject selectionBall;
    private GameObject balls;
    private GameObject spawnPoint;
    public delegate void StopTheBall();
    public static event StopTheBall StopTheBallEvent;
    private GameObject chooseBallPanel;
    void Start () {

        balls = GameObject.Find("Balls");
        chooseBallPanel = GameObject.Find("chooseball_panel");
        

        BallsInventory.GetSelectedBalls().Clear();
        BallsInventory.AddBallToSelected(this.balls.transform.GetChild(0).gameObject.GetComponent<Ball>());
        this.balls.transform.GetChild(0).gameObject.SetActive(true);
        EnableAllSelectedBalls();

        this.BlockAllBalls();
        this.chooseBallPanel.SetActive(true);
        this.selectionBall.SetActive(false);
        StopTheBallEvent += StopBall; 

    }
	
	// Update is called once per frame
	void Update () {

        if (!selectionBall.activeInHierarchy)
        {
            OnBallDrop();
            if (selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude < 1 && selectionBall.GetComponent<SelectionBallScript>().SelectedBall.GetComponent<Rigidbody>().velocity.magnitude > 0.3 )
            {
        
                selectionBall.GetComponent<SelectionBallScript>().SelectedBall.StopTheBall();
                OnBallStop();
            }
            else
            {
                selectionBall.GetComponent<SelectionBallScript>().SelectedBall.MoveTheBall();
            }
        }

    }
    private void StopBall()
    {
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

    public void EnableAllSelectedBalls()
    {
        for (int i = 0; i < balls.transform.childCount; i++)
        {
            if (PlayerPrefs.GetInt(balls.transform.GetChild(i).gameObject.name) == 1)
            {
                BallsInventory.AddBallToSelected(balls.transform.GetChild(i).gameObject.GetComponent<Ball>());
                balls.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                balls.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }

    public void GoToSlectionBallScene()
    {
        PlayerPrefs.SetString("scene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Balls_Selection");
        this.chooseBallPanel.SetActive(false);

    }

    public void StayHere()
    {
        this.chooseBallPanel.SetActive(false);
        this.selectionBall.SetActive(true);
       
    }




}
