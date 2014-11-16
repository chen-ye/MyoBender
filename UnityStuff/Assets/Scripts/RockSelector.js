﻿#pragma strict

function Start () {
	var n : int = Random.Range(1, 20);
	var mesh : Mesh;
	var children : Component[] = this.GetComponentsInChildren(Transform, false);
	print(children.Length);
	for (var i = 1; i < children.Length; i++) {
		if (i == n) {
		} else {
			Destroy(children[i].gameObject);
		}
	}
}

function Update () {
	
}

function OnCollisionEnter (col : Collision) {
	print(col.relativeVelocity.magnitude);
	if (col.relativeVelocity.magnitude > 10) {
			Destroy(this);
	}
}