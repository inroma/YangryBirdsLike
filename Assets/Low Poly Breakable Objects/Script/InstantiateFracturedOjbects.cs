using UnityEngine;
using System.Collections;

public class InstantiateFracturedOjbects : MonoBehaviour {
	public GameObject cone;
	public GameObject cube;
	public GameObject cylinder;
	public GameObject hedra;
	public GameObject platform;
	public GameObject pyramid;
	public GameObject sphere;
	public GameObject torus;
	public GameObject tube;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {

		if(Input.GetKeyDown("space")){
			ScreenCapture.CaptureScreenshot("screenshot.png");
		}


	}
	public void coneinst (){
		var obj0 = (GameObject)Instantiate (
			cone,
			transform.position,
			transform.rotation);
		Destroy(obj0,6);
	}
	public void cubeinst (){
		var obj1 = (GameObject)Instantiate (
			cube,
			transform.position,
			transform.rotation);
		Destroy(obj1,6);
	}
	public void cylinderinst (){
		var obj2 = (GameObject)Instantiate (
			cylinder,
			transform.position,
			transform.rotation);
		Destroy(obj2,6);
	}
	public void hedrainst (){
		var obj3 = (GameObject)Instantiate (
			hedra,
			transform.position,
			transform.rotation);
		Destroy(obj3,6);
	}
	public void platforminst (){
		var obj4 = (GameObject)Instantiate (
			platform,
			transform.position,
			transform.rotation);
		Destroy(obj4,6);
	}
	public void pyramidinst (){
		var obj5 = (GameObject)Instantiate (
			pyramid,
			transform.position,
			transform.rotation);
		Destroy(obj5,6);
	}
	public void sphereinst (){
		var obj6 = (GameObject)Instantiate (
			sphere,
			transform.position,
			transform.rotation);
		Destroy(obj6,6);
	}
	public void torusinst (){
		var obj7 = (GameObject)Instantiate (
			torus,
			transform.position,
			transform.rotation);
		Destroy(obj7,6);
	}
	public void tubeinst (){
		var obj8 = (GameObject)Instantiate (
			tube,
			transform.position,
			transform.rotation);
		Destroy(obj8,6);
	}


}
