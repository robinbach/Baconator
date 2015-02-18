using UnityEngine;
using System.Collections;

public class Lighter: Combustible {
	
	void Start () {
		isBurning = true;
		StartCoroutine (burning());
	}

	IEnumerator burning()
	{
		energy = energyPerUnit;

//		int fireNum = 10;

		while(energy > 0) {
			--energy;
			float degreeDelta = Random.value * 6.28f;
			yield return new WaitForSeconds (0.1f);
			GameObject fireton 
				= Instantiate (prefabFireton, transform.position, Quaternion.identity) as GameObject;
			fireton.transform.parent = this.gameObject.transform;
			Fireton firetonScript = fireton.GetComponent<Fireton>();

			firetonScript.initParent(this.gameObject.GetInstanceID());
			fireton.rigidbody.velocity = new Vector2 (Mathf.Sin(degreeDelta), Mathf.Cos(degreeDelta)).normalized;
			fireton.rigidbody.velocity *= 10f;
		}
	}



}
