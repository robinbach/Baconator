using UnityEngine;
using System.Collections;

public class ClickHeatcore : MonoBehaviour {

	void OnMouseDown()
	{
		print ("mouse down on heatcore");
		Skills.HeatcoreNum ++;
		Destroy (this.gameObject);
	}
}
