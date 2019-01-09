#pragma strict
 var mouse_pos : Vector3;
 var target : Transform; //Assign to the object you want to rotate
 var object_pos : Vector3;
 var angle : float;
 
 var lookFactor = 0.8;
 
 function Update () {
     var distance = (transform.position.z - Camera.main.transform.position.z) * lookFactor;
     var position = Vector3(Input.mousePosition.x, Input.mousePosition.y, 55);
     position = Camera.main.ScreenToWorldPoint(position);
     transform.LookAt(position);
 }