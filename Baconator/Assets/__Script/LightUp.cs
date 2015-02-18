using UnityEngine;
using System.Collections;

public class LightUp : MonoBehaviour {

	public GameObject prefabLighter;

	private EnvirStatus status;
	// Use this for initialization
	void Start () {
		status = Camera.main.GetComponent<EnvirStatus>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{

		print ("mouse down");
		if(status.lighterNum > 0)
		{
			status.lighterNum--;

			// Instantiate a lighter
			GameObject lighter = Instantiate( prefabLighter ) as GameObject;
			// Start it at here
			Vector3 mousePos2D = Input.mousePosition;
			// Convert the mouse position to 3D world coordinates
			mousePos2D.z = -Camera.main.transform.position.z;
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
			lighter.transform.position = mousePos3D;

			status.lightingUp ();
		}
	}
}
