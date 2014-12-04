using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Pose = Thalmic.Myo.Pose;

public class MyoGestureController : MonoBehaviour {
	
	public GestureController gestureController;
	public Limb limb = Limb.LeftArm;
	public GameObject myo = null;

	private ThalmicMyo thalmicMyo;
	private Pose _lastPose = Pose.Unknown;
	private List<Gesture> myoPoses = new List<Gesture>() 
	{
		Gesture.FingersSpread,
		Gesture.Fist,
		Gesture.DoubleTap,
		Gesture.WaveIn,
		Gesture.WaveOut
	};

	private Dictionary<Pose,Gesture> poseToGesture = new Dictionary<Pose,Gesture>() 
	{
		{Pose.FingersSpread, Gesture.FingersSpread},
		{Pose.Fist, Gesture.Fist},
		{Pose.DoubleTap, Gesture.DoubleTap},
		{Pose.WaveIn, Gesture.WaveIn},
		{Pose.WaveOut, Gesture.WaveOut},
		{Pose.Rest, Gesture.None},
		{Pose.Unknown, Gesture.None}
	} ;

	// Use this for initialization
	void Start () {
		thalmicMyo = myo.GetComponent<ThalmicMyo> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			print (thalmicMyo.name + " pose: " + thalmicMyo.pose); //Replace with diagnostic UI

			/* Thalmic Gestures are mutually exclusive.  So run through the poseToGesture dictionary and set everything which isn't currently active to false */
			foreach (KeyValuePair<Pose,Gesture> kvp in poseToGesture) {
				if(kvp.Value != Gesture.None) {
					gestureController.Gestures[limb][kvp.Value] = (kvp.Key == thalmicMyo.pose) ? true : false;
				}
			}

			print (thalmicMyo.name + " gesture: " + poseToGesture[thalmicMyo.pose] + " - " + gestureController.Gestures[limb][poseToGesture[thalmicMyo.pose]]);

			/* Now call the LL Gesture event */
			gestureController.fireLLGesture();
		}
	}
}
