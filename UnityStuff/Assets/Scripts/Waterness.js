#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter(collider : Collider) {
	//Debug.Log("Name is " + collider.gameObject.name + "!");
	//Debug.Log(collider.tag);
	if(collider.gameObject.name == "Fireball(Clone)") {	
		var emitters : Component[] = collider.gameObject.GetComponentsInChildren(ParticleEmitter, false);
		if (emitters != null) {
			for(var i = 0; i < emitters.length; i++) {
				emitters[i].particleEmitter.emit = false;
			}
		}
		var psystem : ParticleSystem = this.gameObject.GetComponentInChildren(ParticleSystem).particleSystem;
		if (psystem != null) {
			psystem.enableEmission = false;
		}
	}
}