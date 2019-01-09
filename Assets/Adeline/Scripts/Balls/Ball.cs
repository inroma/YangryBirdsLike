using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    public float smoothTime = 0.3F;
    public Vector3 velocity = Vector3.zero;
    // Use this for initialization
    void Start () {
		
	}

    public void StopTheBall()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        BlockBallDropping();

    }

    public void MoveTheBall()
    {
        this.GetComponent<draggy>().enabled = true;
    }

    public void BlockBallDropping()
    {
        this.GetComponent<draggy>().enabled = false;
    }

    public bool IsBallStopped()
    {
        if (this.GetComponent<Rigidbody>().velocity == Vector3.zero)
            return true;
        return false;
    }

    public void Equip()
    {
        BallsInventory.AddBall(this);
    }
    public void UnEquip()
    {
        BallsInventory.RemoveBall(this);
    }


}
