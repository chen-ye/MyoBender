#pragma strict

function Start () {
	var n : int = Random.Range(1, 20);
	print(n);
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