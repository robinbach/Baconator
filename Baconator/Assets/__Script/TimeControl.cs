using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		Time.timeScale = speed;
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = speed;
	
	}

}
