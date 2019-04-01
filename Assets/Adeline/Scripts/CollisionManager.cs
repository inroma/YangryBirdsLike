using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour {


    public GameObject restart;
    public GameObject youwin;
    public Text nombrecoup;
    public int nbcoup;
    // Use this for initialization

    void Start () {
        youwin.SetActive(false);
        restart.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {

        nombrecoup.text = nbcoup.ToString();
        if (nbcoup==0 )
        {
            StartCoroutine(Example());
           
         //   gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
      
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Finish")
        {
            youwin.SetActive(true);
        }
        if (col.gameObject.tag == "dead")
        {
            print("lose");
            restart.SetActive(true);
        }
    }

    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(3);
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            restart.SetActive(true);
            Destroy(gameObject);
        }
            
    }
}
