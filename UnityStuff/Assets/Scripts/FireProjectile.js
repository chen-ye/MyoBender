#pragma strict

public var projectile : Rigidbody;
public var velocity : float = 50;

function Update() {
	if (Input.GetMouseButtonDown(0)) {
		var clone : Rigidbody;
		clone = Instantiate(projectile, transform.position, transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward * velocity);
	}
}