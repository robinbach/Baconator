using UnityEngine;
using System.Collections;

public class Fireton : MonoBehaviour {

	public int parentID;

	public void initParent(int parentID_in)
	{
		parentID = parentID_in;
	}

	void OnTriggerEnter(Collider coll)
	{
		GameObject collObj = coll.gameObject;
		HeatTrans heatModel = collObj.GetComponent<HeatTrans>();

		if(heatModel && collObj.GetInstanceID() != parentID)
		{
			heatModel.heated();
			print (collObj.name +","+ parentID +","+collObj.GetInstanceID());
			Destroy(this.gameObject);
		}
	}

}
