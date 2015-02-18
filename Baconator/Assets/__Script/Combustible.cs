using UnityEngine;
using System.Collections;

public class Combustible : MonoBehaviour {

	public GameObject prefabFireton;
	public int lightEnergy = Constants.lightEnergy;
	public int energyPerUnit = Constants.unitEnergy;


	public int energy;
	public bool isBurning;
	public bool isBurned;

	private float radioRange = 1.0f;
	private int energyUnits;
	private Vector3 initScale;
//	private int firecount = 0;

	// Use this for initialization
	void Start () {
		energy = 0;
		isBurning = false;
		isBurned = false;
		energyUnits = Mathf.RoundToInt(transform.localScale.x * transform.localScale.y);
		initScale = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void heated()
	{
		energy++;
		if(!isBurning && energy > lightEnergy * energyUnits/5f)
		{
			isBurning = true;
			renderer.material.color = Color.Lerp(renderer.material.color, Color.red, 0.5f);
			StartCoroutine (burning());
		}
	}

	IEnumerator burning()
	{
		energy = energyPerUnit * energyUnits;
		radioRange = Mathf.Clamp(energy / 25f, 1.0f, 50.0f);
		float releaseDelay = Mathf.Clamp(0.25f/radioRange ,0.02f, 0.3f);

		while(energy > 0) {
			--energy;
			float degreeDelta = Random.value * 6.28f;
			yield return new WaitForSeconds (releaseDelay);
			GameObject fireton 
				= Instantiate (prefabFireton, transform.position, Quaternion.identity) as GameObject;
//			fireton.transform.parent = this.gameObject.transform;
			Fireton firetonScript = fireton.GetComponent<Fireton>();

			firetonScript.initParent(this.gameObject.GetInstanceID());
			fireton.rigidbody.velocity 
//				= new Vector2 (transform.localScale.x * Mathf.Sin(degreeDelta),
//				               transform.localScale.y * Mathf.Cos(degreeDelta)).normalized;
				= new Vector2 (Mathf.Sin(degreeDelta),
				               Mathf.Cos(degreeDelta)).normalized;
			fireton.rigidbody.velocity *= radioRange;

			if(energy < 25)
			{
				this.gameObject.transform.localScale 
					= initScale * (energy/50f + 0.5f);
			}
		}
		renderer.material.color = Color.Lerp(Color.white, Color.black, renderer.material.color.g);
		isBurned = true;
	}



}
