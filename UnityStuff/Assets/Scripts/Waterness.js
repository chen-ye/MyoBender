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
		var psystem : Component = this.gameObject.GetComponentInChildren(ParticleSystem);
		if (psystem != null) {
			psystem.particleSystem.enableEmission = false;
		}
	}
}