#pragma strict

public var airProjectile : Rigidbody;
public var fireProjectile : Rigidbody;
public var earthProjectile : Rigidbody;
public var waterProjectile : Rigidbody;

private var projectile : Rigidbody;
private var activeElement : int = 2;

public var airVelocity : float = 200;
public var fireVelocity : float = 100;
public var earthVelocity : float = 50;
public var waterVelocity : float = 40;

private var rock : boolean = false;
private var air : boolean = false;
private var water : boolean = false;

function Update() {
	if (Input.GetKeyDown("1")) {
		activeElement = 1;
	}
	if (Input.GetKeyDown("2")) {
		activeElement = 2;
	}
	if (Input.GetKeyDown("3")) {
		activeElement = 3;
	}
	if (Input.GetKeyDown("4")) {
		activeElement = 4;
	}
	
	
	if (Input.GetMouseButtonDown(0)) {
		switch(activeElement) {
			case 1:
				//fireAir();
				break;
			case 2:
				fireFire();
				break;
			case 3:
				fireEarth();
				break;
			case 4:
				fireWater();
				break;
		}
	}
	if (Input.GetMouseButtonDown(1)) {
		switch(activeElement) {
			case 1:
				//chargeAir();
				break;
			case 2:
				//chargeFire();
				break;
			case 3:
				chargeEarth();
				break;
			case 4:
				chargeWater();
				break;
		}
	}
}

function fireFire() {
	var clone : Rigidbody;
	clone = Instantiate(fireProjectile, transform.position + transform.TransformDirection(Vector3.forward * .5), transform.rotation);
	clone.velocity = transform.TransformDirection (Vector3.forward * fireVelocity);
}

function fireEarth() {
	if (rock) {
		projectile.AddForce (transform.TransformDirection(Vector3.forward * earthVelocity * 100000));
		rock = false;
	}
}

function chargeEarth() {
	rock = true;
	projectile = Instantiate(earthProjectile, transform.position + transform.TransformDirection((Vector3.forward * 4) + (Vector3.down * 2)), transform.rotation);
	//projectile.collider.active = false;
	projectile.AddForce (Vector3.up * earthVelocity * 5000);
	//yield new WaitForSeconds(0.5);
	//projectile.collider.active = true;
}

function fireWater() {
	if (water) {
		projectile.AddForce (transform.TransformDirection(Vector3.forward * waterVelocity * 100));
	}
}

function chargeWater() {
	water = true;
	projectile = Instantiate(waterProjectile, transform.position + transform.TransformDirection((Vector3.forward * 4) + (Vector3.down * 1)), transform.rotation);
	//projectile.collider.active = false;
	projectile.AddForce (Vector3.up * waterVelocity * 50);
	//yield new WaitForSeconds(0.5);
	//projectile.collider.active = true;
}