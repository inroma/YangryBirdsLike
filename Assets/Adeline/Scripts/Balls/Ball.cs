﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


    public float smoothTime = 0.3F;
    public Vector3 velocity = Vector3.zero;
    public int price;
    public bool isUnlock;
    public bool isSelected;

    // Use this for initialization
    void Start () {
        isUnlock = false;
        if (PlayerPrefs.GetInt(this.name + "isunlock") == 1)
        {
            this.isUnlock = true;
        }
        else
        {
            this.isUnlock = false;
        }

        if (PlayerPrefs.GetInt(this.name) == 1)
        {
            this.isSelected = true;
        }
        else
        {
            this.isSelected = false;
        }

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
        BallsInventory.AddBallToSelected(this);
    }
    public void UnEquip()
    {
        BallsInventory.RemoveBallToSelected(this);
    }


}
