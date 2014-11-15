#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter(collider : Collider) {
	Debug.Log("Name is " + collider.gameObject.name + "!");
	Debug.Log(collider.tag);
	if(collider.gameObject.name == "Fireball(Clone)") {	
	    yield new WaitForSeconds(1.0);
		Destroy(collider.gameObject);
	}
}