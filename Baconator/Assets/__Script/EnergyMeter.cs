using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnergyMeter : MonoBehaviour {

	private int totalFreeEnergy;
	private int totalInnerEnergy;
	
	private EnvirStatus status;
	private Text txt;
	private float timeCost;
	// Use this for initialization
	void Start () {
		totalFreeEnergy = 0;
		totalInnerEnergy = 0;
		status = Camera.main.GetComponent<EnvirStatus> ();
		txt = GetComponent<Text>();
		timeCost = 0f;

	}
	
	// Update is called once per frame
	void Update () {

		updateStatus ();
		updateUI ();
	}
	
	void updateUI ()
	{

		txt.text = "Free Energy:\t" + totalFreeEnergy
						+ "\r\n" + "Inner Energy:\t" + totalInnerEnergy;


		if (status.isWorldBurning && !status.isGameOver) {
			timeCost = status.costTime;
		}

		txt.text += "\r\n" + "Time:\t" + timeCost.ToString("f1");

		if(status.isGameOver)
		{
			if(status.isWon)
			{
				txt.text = "You Win!\r\n";
			}
			else
			{
				txt.text = "Game Over!\r\n";
			}
			txt.text += "Total time cost:\t" + timeCost.ToString("f1");
			txt.fontSize = 25;
			txt.color = Color.red;
		}

	}
	
	void updateStatus()
	{
		totalFreeEnergy = status.totalFreeEnergy;
		totalInnerEnergy = status.totalInnerEnergy;
	}
}
