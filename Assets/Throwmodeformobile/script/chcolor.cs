using UnityEngine;
using System.Collections;

public class chcolor : MonoBehaviour {
	//public GameObject explosion;
	public bool touch;
	public static int win;
	public AudioClip saw; 
	/*public byte Rafter;
	public byte Gafter;
	public byte Bafter;
	public byte Rbefore;
	public byte Gbefore;
	public byte Bbefore;*/
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().volume=0.2f;
		GetComponent<AudioSource> ().clip = saw;
		win=0;
		touch=true;
		Renderer rend = GetComponent<Renderer>();
		//rend.material.shader = Shader.Find("ball7");

		rend.material.SetColor("_RimColor", new Color32 (0x00,0x14,0xFF,0xFF));

		rend.material.SetColor("_Color", new Color32 (0x65,0x65,0x65,0xFF));
		//GetComponent<Renderer> ().material.color = new Color32 (0x63,0x63,0x63,0xFF);
	}
	void Update () {

		if(SwipeManager.rebon){
			GetComponent<AudioSource> ().volume=0f;
		}

	}
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "Player"){
			
			Renderer rend = GetComponent<Renderer>();
			//rend.material.shader = Shader.Find("ball7");
			rend.material.SetColor("_RimColor", new Color32 (0xE2,0x0B,0x0B,0xFF));
			rend.material.SetColor("_Color", new Color32 (0xFF,0xFF,0xFF,0xFF));
			GetComponent<AudioSource> ().Play ();

			if (touch){
				win++;
				touch=false;
			}

			/*GetComponent<Renderer> ().material.color = new Color32 (0x5F,0x2E,0x92,0xFF);
			prefb.SetColor("_TintColor",new Color(Random.value,Random.value,Random.value,1));*/
			/*GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy(gameObject); // destroy the grenade
			Destroy(expl, 3); */
		}

	}

}
