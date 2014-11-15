using UnityEngine;
using System.Collections;

public class ChangePivot : MonoBehaviour
{
	private GameObject player;
	Vector3 pivotTransVector;

	void Start () {
		player = GameObject.Find ("Main Camera");
		if (player == null) {
			Debug.Log ("player is null");
		}

		pivotTransVector.x = transform.position.x;
		pivotTransVector.y = transform.position.y;
		pivotTransVector.z = transform.position.z;
	}

	void Update() {
		transform.RotateAround (player.transform.position, Vector3.up, 20 * Time.deltaTime);
	}

}