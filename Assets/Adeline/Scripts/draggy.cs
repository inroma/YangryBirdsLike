

using UnityEngine;
using System.Collections;



 
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class draggy : MonoBehaviour
{


    public float magBase = 2; // this is the base magnitude and the maximum length of the line drawn in the user interface
    public float magMultiplier = 5; // multiply the line length by this to allow for higher force values to be represented by shorter lines
    public Vector3 dragPlaneNormal = Vector3.up; // a vector describing the orientation of the drag plan relative to world-space but centered on the target
    public SnapDir snapDirection = SnapDir.away; // force is applied either toward or away from the mouse on release
    public ForceMode forceTypeToApply = ForceMode.VelocityChange;

    public bool overrideVelocity = true; // cancel the existing velocity before applying the new force
    public bool pauseOnDrag = true; // causes the simulation to pause when the object is clicked and unpause when released
    public enum SnapDir { toward, away }

    private Vector3 forceVector;
    private float magPercent = 0;

    private bool mouseDragging = false;
    private Vector3 mousePos3D;
    private float dragDistance;
    private Plane dragPlane;
    private Ray mouseRay;
    private GameObject dragZone;

    private string shaderString = "Transparent/Diffuse";
    private Material dzMat;
      
    void Start()
    {
    

        dzMat = new Material(Shader.Find(shaderString));

        // create the dragzone visual helper
        dragZone = new GameObject("dragZone_" + gameObject.name);
        dragZone.AddComponent<MeshRenderer>();
        dragZone.GetComponent<Renderer>().enabled = false;

        dragZone.name = "dragZone_" + gameObject.name;
        dragZone.transform.localScale = new Vector3(magBase * 2, 0.025f, magBase * 2);
        dragZone.GetComponent<Renderer>().material = dzMat;
       

        // create the dragplane
        dragPlane = new Plane(dragPlaneNormal, transform.position);

        // orient the drag plane
        if (dragPlaneNormal != Vector3.zero)
        {
            dragZone.transform.rotation = Quaternion.LookRotation(dragPlaneNormal) * new Quaternion(1, 0, 0, 1);
        }
        else Debug.LogError("Drag plane normal cannot be equal to Vector3.zero.");

        //update the position of the dragzone
        dragZone.transform.position = transform.position;
    }


    void OnMouseDown()
    {
        if (!this.enabled)
        {
            return;
        }
        mouseDragging = true;

        if (pauseOnDrag)
        {
            // pause the simulation
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        // update the dragplane
        dragPlane = new Plane(dragPlaneNormal, transform.position);

        // orient the drag plane
        if (dragPlaneNormal != Vector3.zero)
        {
            dragZone.transform.rotation = Quaternion.LookRotation(dragPlaneNormal) * new Quaternion(1, 0, 0, 1);
        }
        else Debug.LogError("Drag plane normal cannot be equal to Vector3.zero.");

        //update the position of the dragzone
        dragZone.transform.position = transform.position;

        dragZone.GetComponent<Renderer>().enabled = true;
    }



    void OnMouseDrag()
    {
        if (!this.enabled)
        {
            return;
        }

        // update the plane if the target object has left it
        if (dragPlane.GetDistanceToPoint(transform.position) != 0)
        {
            // update dragplane by constructing a new one -- I should check this with a profiler
            dragPlane = new Plane(dragPlaneNormal, transform.position);
        }

        // create a ray from the camera, through the mouse position in 3D space
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // if mouseRay intersects with dragPlane
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

            // update color the color
            // calculate the percentage value of current force magnitude out of maximum
            magPercent = (dragDistance * magMultiplier) / (magBase * magMultiplier);
            // choose color based on how close magPercent is to either 0 or max
         

            // draw the line
            Debug.DrawRay(transform.position, forceVector / magMultiplier);
        }

        //update the position of the dragzone
        //dragZone.transform.position = transform.position;
    }

    void OnMouseUp()
    {
        if (!this.enabled)
        {
            return;
        }
        mouseDragging = false;

        if (overrideVelocity)
        {
            // cancel existing velocity
            GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity, ForceMode.VelocityChange);
  

        }

        // add new force
        int snapD = 1;
        if (snapDirection == SnapDir.away) snapD = -1; // if snapdirection is "away" set the force to apply in the opposite direction
        GetComponent<Rigidbody>().AddForce(snapD * forceVector, forceTypeToApply);

        // cleanup
        dragZone.GetComponent<Renderer>().enabled = false;

        if (pauseOnDrag)
        {
            // un-pause the simulation
            Time.timeScale = 1;
        }
        
    }


}
