using UnityEngine;
using System.Collections;

public class HeatTrans : MonoBehaviour {

	public GameObject prefabFireton;

	public int energy;
	public bool isBurning;


//	private int firecount = 0;

	// Use this for initialization
	void Start () {
		energy = 0;
		isBurning = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void heated()
	{
		energy++;
		if(!isBurning && energy > Constants.lightEnergy)
		{
			isBurning = true;
			renderer.material.color = new Color(1.0f, 0, 0, 1.0f);
			StartCoroutine (burning());
		}
	}

	IEnumerator burning()
	{
		energy = Constants.maxEnergy;

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
			fireton.rigidbody.velocity *= 1.8f;
		}
		renderer.material.color = new Color(0, 0, 0, 1.0f);

	}



}
