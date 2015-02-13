using UnityEngine;
using System.Collections;

public class PurishByTime : MonoBehaviour {

	public float lifeTime = 5.0f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, lifeTime);
	}

}
