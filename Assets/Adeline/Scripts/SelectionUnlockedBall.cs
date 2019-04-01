using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionUnlockedBall : MonoBehaviour
{
    private GameObject ballsImages;
    private GameObject unlockedBallsImages;
    private GameObject allBalls;
    private GameObject actualBallImage;
    private GameObject selectedBallsImages;
    private int index;
    public GameObject SpawnPoints;
    private List<GameObject> unlockedBallsImagesList;
    public GameObject valid_icon;
    public GameObject remove_icon;

    // Start is called before the first frame update
    void Start()
    {

        this.unlockedBallsImages = GameObject.Find("unlockedBallsImages");
        this.selectedBallsImages = GameObject.Find("selectedBallsImages");
        this.ballsImages = GameObject.Find("ballsImages");
        this.unlockedBallsImagesList = new List<GameObject>();

        GetUnlockedBallsImages();

        int index = 0; 
        for (int i = 0; i < unlockedBallsImages.transform.childCount; i++)
        {
            this.unlockedBallsImagesList.Add(unlockedBallsImages.transform.GetChild(i).gameObject);
            unlockedBallsImages.transform.GetChild(i).gameObject.SetActive(false);
        }

        this.actualBallImage = unlockedBallsImages.transform.GetChild(index).gameObject;
        this.actualBallImage.SetActive(true);
        this.valid_icon.SetActive(true);
        this.remove_icon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    public void PreviousBall()
    {

        this.actualBallImage.SetActive(false);

        if (this.index - 1 != -1)
        {
            this.actualBallImage = unlockedBallsImages.transform.GetChild(index - 1).gameObject;
        }
        else
        {
            this.actualBallImage = unlockedBallsImages.transform.GetChild(this.unlockedBallsImagesList.Count -1).gameObject;
        }
        this.actualBallImage.SetActive(true);
        this.index = this.unlockedBallsImagesList.IndexOf(this.actualBallImage);

        this.UpdateSelectButtons();
    }

    public void NextBall()
    {
        this.actualBallImage.SetActive(false);

        if (this.index != this.unlockedBallsImagesList.Count - 1)
        {
            this.actualBallImage = unlockedBallsImages.transform.GetChild(index + 1).gameObject;
        }
        else
        {
            this.actualBallImage = unlockedBallsImages.transform.GetChild(0).gameObject;
        }
        this.actualBallImage.SetActive(true);
        this.index = this.unlockedBallsImagesList.IndexOf(this.actualBallImage);
        this.UpdateSelectButtons();

    }

    public void UpdateSelectButtons()
    {
        if (BallsInventory.GetSelectedBalls().Contains(this.actualBallImage.GetComponent<BallImage>().ball))
        {
            this.valid_icon.SetActive(false);
            this.remove_icon.SetActive(true);
        }
        else
        {
            this.remove_icon.SetActive(false);
            this.valid_icon.SetActive(true);
        }
    }

    public void SelectBall()
    {
       BallsInventory.AddBallToSelected(this.actualBallImage.GetComponent<BallImage>().ball);
       PlayerPrefs.SetInt(this.actualBallImage.GetComponent<BallImage>().ball.gameObject.name, 1);
        this.UpdateSelectButtons();
        this.DisplaySelectedBall();
    }

    public void UnSelectBall()
    {
        BallsInventory.GetSelectedBalls().IndexOf(this.actualBallImage.GetComponent<BallImage>().ball);
        BallsInventory.RemoveBallToSelected(this.actualBallImage.GetComponent<BallImage>().ball);
        PlayerPrefs.SetInt(this.actualBallImage.GetComponent<BallImage>().ball.gameObject.name, 0);
        this.SpawnPoints.transform.GetSiblingIndex();
        SearchMyBallToDestroy();
        this.UpdateSelectButtons();
    }

    private void SearchMyBallToDestroy()
    {
        for (int i = 0; i < this.SpawnPoints.transform.childCount; i++)
        {
            if (SpawnPoints.transform.GetChild(i).Find(this.actualBallImage.name) != null)
            {
                Destroy(this.SpawnPoints.transform.GetChild(i).Find(this.actualBallImage.name).gameObject);
                return;
            }
        }
    }

    private void GetUnlockedBallsImages()
    {
        for (int i = 0; i < ballsImages.transform.childCount; i++)
        {
            if(PlayerPrefs.GetInt(ballsImages.transform.GetChild(i).GetComponent<BallImage>().ball.gameObject.name + "isunlock") == 1)
            {
                BallsInventory.AddEnableBall(ballsImages.transform.GetChild(i).GetComponent<BallImage>().ball);
                var unlockball = Instantiate(ballsImages.transform.GetChild(i).gameObject);
                unlockball.transform.position =unlockedBallsImages.transform.position;
                unlockball.transform.parent = this.unlockedBallsImages.transform;
                unlockball.name = ballsImages.transform.GetChild(i).GetComponent<BallImage>().ball.name;
            }
  
        }
    }

    private void DisplaySelectedBall()
    {
        for (int i = 0; i < this.SpawnPoints.transform.childCount; i++)
        {
            if (SpawnPoints.transform.GetChild(i).childCount == 0)
            {
                var selectball = Instantiate(this.actualBallImage);
                selectball.transform.parent = this.SpawnPoints.transform.GetChild(i);
                selectball.name = this.actualBallImage.GetComponent<BallImage>().ball.gameObject.name;
                selectball.transform.position = SpawnPoints.transform.GetChild(i).position;
                return;
            }
        }
    }

    public void ReturnToLevel()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
    }



}
