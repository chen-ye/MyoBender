#pragma strict

public var projectile : Rigidbody;
public var velocity : float = 40;

function Update () {
 if (Input.GetKeyDown("enter") || Input.GetKeyDown("return")) {
     var clone : Rigidbody;
     clone = Instantiate(projectile, transform.position, transform.rotation);
     clone.velocity = transform.TransformDirection (Vector3.forward * velocity);
 }
}