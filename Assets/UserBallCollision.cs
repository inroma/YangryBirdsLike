using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBallCollision : MonoBehaviour {

    public ParticleSystem particleSystem;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if (col.GetComponent<Collider>().tag == "Player")
        {
            //particleSystem = col.GetComponentInChildren<ParticleSystem>();
            foreach (ParticleSystem item in col.GetComponentsInChildren<ParticleSystem>())
            {
                if (item.tag == "effect")
                {
                    Debug.Log("effect found");
                    particleSystem = item;
                    particleSystem.GetComponent<Renderer>().enabled = true;
                }
            }
        }
    }
}
