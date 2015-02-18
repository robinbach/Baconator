using UnityEngine;
using System.Collections;

public class Fireton : MonoBehaviour {

	private int parentID;

	public void initParent(int parentID_in)
	{
		parentID = parentID_in;
	}

	void OnTriggerEnter(Collider coll)
	{
		GameObject collObj = coll.gameObject;
		Combustible heatModel = collObj.GetComponent<Combustible>();

		if(heatModel && collObj.GetInstanceID() != parentID)
		{
//			print (collObj.name +","+ parentID +","+collObj.GetInstanceID());
			if(!heatModel.isBurned)
			{
				heatModel.heated();
				Destroy(this.gameObject);
			}
		}
	}

}
