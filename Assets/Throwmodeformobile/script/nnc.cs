using UnityEngine;
using System.Collections;


public class nnc : MonoBehaviour {

	Vector3 mMouseDownPos;
	Vector3 mMouseUpPos;
	public float speed = .1f;
	public static Vector3 prf1;
	public static Vector3 prf;
	public float distt;
	public GameObject indicator;
	public static int x;



	// Use this for initialization
	void Start () 
	{
		
		transform.localEulerAngles=new Vector3(0,0,0);
		Renderer rend = GetComponent<Renderer>();

		rend.material.SetColor("_RimColor", new Color (Random.value,Random.value,Random.value,0xFF));
		MeshFilter mesh = GetComponent<MeshFilter>();

		indicator.SetActive(false);
	}

	// Update is called once per frame
	void Update () 
	{
		
		 distt = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).magnitude;

		indicator.GetComponent<ParticleSystem>().startSpeed = distt/50;
		prf = prf1;
	}

	void OnMouseDown() 
	{	
		indicator.SetActive(true);


        Renderer rend = GetComponent<Renderer>();
		mMouseDownPos = Input.mousePosition;
		//Debug.Log( "the mouse down pos is " + mMouseDownPos.y.ToString() );
		mMouseDownPos = Input.mousePosition;
		//Debug.Log( "the mouse down pos is " + mMouseDownPos.z.ToString() );
		mMouseDownPos.z = 0;

	}

	void OnMouseUp() 
	{
		mMouseUpPos = Input.mousePosition;
		mMouseUpPos = Input.mousePosition;
		mMouseUpPos.z = 0;
		var direction = mMouseDownPos - mMouseUpPos;
		prf1 = direction;
		direction.Normalize();
		indicator.SetActive(false);
		//Debug.Log( "the mouse up pos is " + mMouseUpPos.ToString() );
	}
}
