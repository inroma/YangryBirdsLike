using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketPlaceScript : MonoBehaviour {


    private Ball actualBall;
    private GameObject cubeScene;
    public GameObject locker;
    public GameObject balls;
    public GameObject buyBallButton;
    public ModalPanel modalPanel;
    private int diamonds;
    public TextMeshProUGUI diamonds_text;

    void Start () {

        cubeScene = GameObject.Find("CubeRoom");
        this.modalPanel.gameObject.SetActive(false);

        for (int i = 0; i < balls.transform.childCount; i++)
        {
            BallsInventory.GetMarketPlaceBalls().Add(balls.transform.GetChild(i).gameObject.GetComponent<Ball>());
        }

        foreach ( Ball ball in BallsInventory.GetMarketPlaceBalls())
        {
            ball.gameObject.SetActive(false);
        }

        actualBall =(Ball)BallsInventory.GetMarketPlaceBalls()[0];
        actualBall.transform.position = GameObject.Find("ActualBall").transform.position;
        actualBall.gameObject.SetActive(true);
        this.modalPanel.gameObject.SetActive(false);
        diamonds = PlayerPrefs.GetInt("diamonds");
        diamonds = this.diamonds + 1;
        this.diamonds_text.text = diamonds.ToString();

    }
	
	// Update is called once per frame
	void Update ()
    {

        cubeScene.transform.Rotate(Vector3.up * Time.deltaTime * 2);
        actualBall.transform.Rotate(Vector3.up * Time.deltaTime * 40);


        if (!actualBall.gameObject.activeInHierarchy)
            actualBall.gameObject.SetActive(true);

        if( actualBall.isUnlock == false)
        {
            locker.gameObject.SetActive(true);
            buyBallButton.gameObject.SetActive(true);
            
        }
        else
        {
            locker.gameObject.SetActive(false);
            buyBallButton.gameObject.SetActive(false);
        }

    }

 
    public void PreviousBall()
    {
        actualBall.gameObject.SetActive(false);
        if (BallsInventory.GetMarketPlaceBalls().IndexOf(actualBall)-1 != -1)
        {
            actualBall = (Ball) BallsInventory.GetMarketPlaceBalls()[BallsInventory.GetMarketPlaceBalls().IndexOf(actualBall) - 1];
        }
        else
        {
            actualBall = (Ball)BallsInventory.GetMarketPlaceBalls()[BallsInventory.GetMarketPlaceBalls().Count - 1];
        }
        actualBall.transform.position = GameObject.Find("ActualBall").transform.position;

    }

    public void NextBall()
    {
        actualBall.gameObject.SetActive(false);
        if (BallsInventory.GetMarketPlaceBalls().IndexOf(actualBall) != BallsInventory.GetMarketPlaceBalls().Count - 1)
        {
            actualBall = (Ball)BallsInventory.GetMarketPlaceBalls()[BallsInventory.GetMarketPlaceBalls().IndexOf(actualBall) + 1];
        }
        else
        {
            actualBall = (Ball)BallsInventory.GetMarketPlaceBalls()[0];
        }
        actualBall.transform.position = GameObject.Find("ActualBall").transform.position;
    }

    public void BuyBall()
    {
        if(this.diamonds - this.actualBall.price >= 0)
        {
            modalPanel.gameObject.SetActive(true);
            this.diamonds = this.diamonds - this.actualBall.price;
            PlayerPrefs.SetInt("diamonds", diamonds);
            modalPanel.infotext.text = " Achat terminé ! Il vous reste "+ diamonds + " diamants";
            this.actualBall.isUnlock = true;
            PlayerPrefs.SetInt(this.actualBall.gameObject.name + "isunlock" , 1);
            this.diamonds_text.text = diamonds.ToString();
        }
        else
        {
            modalPanel.gameObject.SetActive(true);
            modalPanel.infotext.text = " On fait pas de la charité ici ! Transaction refusée.";
        }    
    }



    //public  void PlayGame()
    //{
    //    SceneManager.LoadScene("Cameramvt");
    //}



}
