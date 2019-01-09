using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class DragScript : MonoBehaviour {

    public enum SnapDir { toward, away }

    public float magBase = 2;
    public float magMultiplier = 5;
    public Vector3 dragPlaneNormal = Vector3.up;
    public SnapDir snapDirection = SnapDir.away;
    public ForceMode forceTypeToApply = ForceMode.VelocityChange;
    private Ray mouseRay;
    public Plane dragPlane { get; private set; }

    private bool mouseDragging = false;
    private Vector3 mousePos3D;
    private float dragDistance;
    private Vector3 forceVector;


    // Use this for initialization
    void Start () {
        // create the dragplane
        dragPlane = new Plane(dragPlaneNormal, transform.position);


    }
	

    void OnMouseDown()
    {
        if (!this.enabled)
        {
            return;
        }
        dragPlane = new Plane(dragPlaneNormal, transform.position);


    }

    void OnMouseDrag()
    {
        if (!this.enabled)
        {
            return;
        }

        if (dragPlane.GetDistanceToPoint(transform.position) != 0)
        {
            dragPlane = new Plane(dragPlaneNormal, transform.position);
        }
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        float intersectDist = 0.0f;
        if (dragPlane.Raycast(mouseRay, out intersectDist))
        {
            // update the world space point for the mouse position on the dragPlane
            mousePos3D = mouseRay.GetPoint(intersectDist);

            // calculate the distance between the 3d mouse position and the object position
            dragDistance = Mathf.Clamp((mousePos3D - transform.position).magnitude, 0, magBase);

            // calculate the force vector
            if (dragDistance * magMultiplier < 1) dragDistance = 0; // this is to allow for a "no move" buffer close to the object
            forceVector = mousePos3D - transform.position;
            forceVector.Normalize();
            forceVector *= dragDistance * magMultiplier;

        }
    }

    void OnMouseUp()
    {
        if (!this.enabled)
        {
            return;
        }

       
        this.GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
        int snapD = 1;
        if (snapDirection == SnapDir.away) snapD = -1; // if snapdirection is "away" set the force to apply in the opposite direction
        GetComponent<Rigidbody>().AddForce(snapD * forceVector, forceTypeToApply);

        

    }
}
