using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NFireElement : MonoBehaviour {

	public GestureController gestureController;
	public Limb limb = Limb.LeftArm;

	public Rigidbody airProjectile;
	public Rigidbody fireProjectile;
	public Rigidbody earthProjectile;
	public Rigidbody waterProjectile;

	public GameObject forcePoint;

	private Rigidbody projectile;
	
	public float airVelocity = 200;
	public float fireVelocity = 100;
	public float earthVelocity = 50;
	public float waterVelocity = 40;
	
	private bool rock = false;
	private bool air = false;
	private bool water = false;

	private Combo firePunch;
	private Combo summonRock;
	private Combo rockPunch;
	private Combo summonWater;
	private Combo waterPunch;
	
	// Use this for initialization
	void Start () {
		firePunch = new Combo(new GestureMeta[] {new GestureMeta(new List<Limb> {limb}, Gesture.Fist)}, gestureController);
		summonRock = new Combo(new GestureMeta[] {new GestureMeta(new List<Limb> {limb}, Gesture.FingersSpread)}, gestureController);
		summonWater = new Combo(new GestureMeta[] {new GestureMeta(new List<Limb> {limb}, Gesture.WaveIn)}, gestureController);
		waterPunch = new Combo(new GestureMeta[] {new GestureMeta(new List<Limb> {limb}, Gesture.WaveIn), new GestureMeta(new List<Limb> {limb}, Gesture.Fist)}, gestureController);
		rockPunch = new Combo(new GestureMeta[] {new GestureMeta(new List<Limb> {limb}, Gesture.FingersSpread), new GestureMeta(new List<Limb> {limb}, Gesture.Fist)}, gestureController);
	}

	void OnEnable() {
		gestureController.OnLLGesture += FireCheck;
	}

	void FireCheck() {
		if (summonWater.Check ()) {
			chargeWater();
		}
		if (summonRock.Check ()) {
			chargeEarth();
		}
		if (rockPunch.Check ()) {
			fireEarth();
		} else if (waterPunch.Check ()) {
			fireWater();
		} else if (firePunch.Check ()) {
			fireFire();
		}
	}

	void fireAir() {
		Rigidbody clone;
		clone = (Rigidbody) Instantiate(airProjectile, transform.position + transform.TransformDirection(Vector3.forward * (float) 0.5), transform.rotation);
		clone.AddForce(transform.TransformDirection (Vector3.forward * airVelocity * 500000));
		//trust.AddImpact (transform.TransformDirection (Vector3.back * airVelocity * 50000));
	}
	
	void fireFire() {
		Rigidbody clone;
		clone = (Rigidbody) Instantiate(fireProjectile, transform.position + transform.TransformDirection(Vector3.forward * (float) 0.5), transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward * fireVelocity);
	}
	
	void fireEarth() {
		if (rock) {
			projectile.AddForce (transform.TransformDirection(Vector3.forward * earthVelocity * 100000));
			rock = false;
		}
	}
	
	void chargeEarth() {
		rock = true;
		projectile = (Rigidbody) Instantiate(earthProjectile, transform.position + transform.TransformDirection((Vector3.forward * 4) + (Vector3.down * 2)), transform.rotation);
		//this.gameObject.Find("ForcePoint").SetActive(true);
		projectile.AddForce (Vector3.up * earthVelocity * 5000);
	}
	
	void fireWater() {
		print ("firing water");
		if (water) {
			projectile.AddForce (transform.TransformDirection(Vector3.forward * waterVelocity * 1000));
			forcePoint.SetActive(false);
		}
	}
	
	void chargeWater() {
		water = true;
		projectile = (Rigidbody) Instantiate(waterProjectile, transform.position + transform.TransformDirection((Vector3.forward * 4) + (Vector3.down * 1)), transform.rotation);
		//projectile.collider.active = false;
		forcePoint.SetActive(true);
		projectile.AddForce (Vector3.up * waterVelocity * 50);
		//yield new WaitForSeconds(0.5);
		//projectile.collider.active = true;
	}
	
	
	
	
}

