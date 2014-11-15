#pragma strict

private var life : int = 0;
public var duration : int = 3000;

function Start () {
	life = Time.time * 1000;
}

function Update () {
	if (Time.time * 1000 - life  > duration)
		Destroy(this.gameObject);
}