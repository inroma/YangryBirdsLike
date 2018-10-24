using UnityEngine;
using System.Collections;

public class rotateyouchoose : MonoBehaviour {

	public float x;
	public float y;
	public float z;
	// Use this for initialization
	void Start () {
		Application.targetFrameRate=30;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(x,y,z);
	}
}
