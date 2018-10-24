using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realus : MonoBehaviour {

    public Material mat;

	// Use this for initialization
	void Start () {
        mat.EnableKeyword("_EMISSION");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
