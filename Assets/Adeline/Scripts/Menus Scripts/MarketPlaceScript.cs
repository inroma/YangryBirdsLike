using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketPlaceScript : MonoBehaviour {


    private Ball actualBall;
    private GameObject cubeScene;
    public GameObject balls;
    public GameObject equipButton;
    public GameObject unequipButton;
    // Use this for initialization
    void Start () {

        cubeScene = GameObject.Find("CubeRoom");
        for (int i = 0; i < balls.transform.childCount; i++)
        {
            BallsInventory.GetMarketPlaceBalls().Add(balls.transform.GetChild(i).gameObject.GetComponent<Ball>());
        }
        foreach ( Ball ball in BallsInventory.GetMarketPlaceBalls())
        {
            ball.gameObject.SetActive(false);
            PlayerPrefs.SetInt(ball.gameObject.name, 0);
        }

        actualBall =(Ball)BallsInventory.GetMarketPlaceBalls()[0];
        actualBall.transform.position = GameObject.Find("ActualBall").transform.position;
        actualBall.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {

        cubeScene.transform.Rotate(Vector3.up * Time.deltaTime * 2);
        actualBall.transform.Rotate(Vector3.up * Time.deltaTime * 40);

        if (!actualBall.gameObject.activeInHierarchy)
            actualBall.gameObject.SetActive(true);

        if (BallsInventory.GetInventoryBalls().Count == 3 ) 
        {
            DisableEquipButton();
            if (BallsInventory.GetInventoryBalls().Contains(actualBall))
            {
                EnableUnEquipButton();
            }
            else
            {
                DisableUnEquipButton();
            }
        }
        else if (BallsInventory.GetInventoryBalls().Contains(actualBall))
        {
            DisableEquipButton();
            EnableUnEquipButton();
        }
        else 
        {
            EnableEquipButton();
            DisableUnEquipButton();
        }

    }

    public void DisableEquipButton()
    {
        equipButton.SetActive(false);
    }
    public void EnableEquipButton()
    {
        equipButton.SetActive(true);
    }
    public void EnableUnEquipButton()
    {
        unequipButton.SetActive(true);
    }
    public void DisableUnEquipButton()
    {
        unequipButton.SetActive(false);
    }
    public void Equip()
    {
        actualBall.Equip();
        PlayerPrefs.SetInt(actualBall.gameObject.name, 1);
    }

    public void UnEquip()
    {

        PlayerPrefs.SetInt(actualBall.gameObject.name, 0);
        actualBall.UnEquip();
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

    public  void PlayGame()
    {
        PlayerPrefs.SetInt("BallSelected", BallsInventory.GetInventoryBalls().IndexOf(actualBall));
        SceneManager.LoadScene("Cameramvt");
    }



}
