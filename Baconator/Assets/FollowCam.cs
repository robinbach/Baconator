using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	static public FollowCam  S; // a FollowCam Singleton

	// fields set in the Unity Inspector pane
	public float             easing = 0.05f;
	public Vector2          minXY;
	public bool              _____________________________;
	
	// fields set dynamically
	public GameObject        poi; // The point of interest
	public float             camZ; // The desired Z pos of the camera
	
	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}
	
	void FixedUpdate () {
		// if there's only one line following an if, it doesn't need braces
		if (poi == null) return; // return if there is no poi
		
		// Get the position of the poi
		Vector3 destination = poi.transform.position;

		// Limit the X & Y to minimum values
		destination.x = Mathf.Max( minXY.x, destination.x );
		destination.y = Mathf.Max( minXY.y, destination.y );

		// Interpolate from the current Camera position toward destination
		destination = Vector3.Lerp(transform.position, destination, easing);
			
		// Retain a destination.z of camZ
		destination.z = camZ;
		// Set the camera to the destination
		transform.position = destination;

		// Set the orthographicSize of the Camera to keep Ground in view
			this.camera.orthographicSize = destination.y + 10;
			
	}
		
}
