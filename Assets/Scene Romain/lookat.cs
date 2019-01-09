using UnityEngine;

public class lookat : MonoBehaviour {
    public Vector3 mouse_pos;
    public Transform target; //Assign to the object you want to rotate
    public Vector3 object_pos;
    public float angle;

    public float lookFactor = 0.8f;

    void Update()
    {
        float distance = (transform.position.z - Camera.main.transform.position.z) * lookFactor;
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 51);
        position = Camera.main.ScreenToWorldPoint(position);
        transform.LookAt(position);
    }
}