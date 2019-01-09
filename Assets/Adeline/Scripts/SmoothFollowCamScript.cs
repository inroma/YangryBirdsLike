
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Place the script in the Camera-Control group in the component menu
[AddComponentMenu("Camera-Control/Smooth Follow CSharp")]

public class SmoothFollowCamScript : MonoBehaviour
{
    Vector3 TargetPosition;
    public GameObject SelectionBall;
    
        
    void Start() {
        
    }

    void LateUpdate()
    {
        if (SelectionBall.activeInHierarchy)
        {
            TargetPosition = SelectionBall.GetComponent<SelectionBallScript>().SelectedBall.transform.position + new Vector3(0, 60, 0);
            transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref SelectionBall.GetComponent<SelectionBallScript>().SelectedBall.velocity, SelectionBall.GetComponent<SelectionBallScript>().SelectedBall.smoothTime);
        }
        
        else
        {
            transform.position = new Vector3(SelectionBall.GetComponent<SelectionBallScript>().SelectedBall.transform.position.x, transform.position.y, SelectionBall.GetComponent<SelectionBallScript>().SelectedBall.transform.position.z);            
        }

    }





   
}