using UnityEngine;
using System.Collections;



public class SwipeManager : MonoBehaviour
{
	public static bool rebon;
	public GameObject wiin;
    public bool oneT;
	public int nbplatform;
	public int nx ;


	void Start () {

		chcolor.win=0;
		chcolorigid.win=0;
		Renderer rend = GetComponent<Renderer>();
		//rend.material.shader = Shader.Find("ball7");

		rend.material.SetColor("_RimColor", new Color32 (0x72,0xFF,0x00,0xFF));


		rebon=false;
		oneT=true;
		wiin.SetActive(false);
	
		//GetComponent<Rigidbody>().isKinematic=true;

	}

	void Update () {
		//Application.CaptureScreenshot("Screenshot"+nx+".png");
		//nx++;
		if((chcolor.win+chcolorigid.win/*+chcolormovx.win*/)==nbplatform&&oneT){
			wiin.SetActive(true);
			rebon=true;
			//print("WIN");
			oneT=false;
		
		}
	
		/*if (!bally.activeInHierarchy){
			Renderer rend = GetComponent<Renderer>();
			//rend.material.shader = Shader.Find("ball7");

			rend.material.SetColor("_RimColor", new Color32 (0xFF,0x00,0x00,0xFF));

		}*/
	}



}
