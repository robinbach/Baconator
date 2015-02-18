using UnityEngine;
using System.Collections;

public class EnvirStatus : MonoBehaviour {


	public int totalFreeEnergy;
	public int totalInnerEnergy;

	public float startTime, costTime;

	public bool isWorldBurning;

	public bool isGameOver;
	public bool isWon;
	public int lighterNum = 1;

	// Use this for initialization
	void Start () {
		totalFreeEnergy = 0;
		totalInnerEnergy = 0;
		startTime = 0;
		isWorldBurning = false;
		isGameOver = false;
		isWon = true;
	}
	
	// Update is called once per frame
	void Update () {

		updateEnvirStatus ();
		updateGameStatus ();

	}
	
	void updateEnvirStatus()
	{
		totalFreeEnergy = GameObject.FindGameObjectsWithTag (Constants.FiretonTag).Length;

		totalInnerEnergy = 0;
		foreach(GameObject fuel in GameObject.FindGameObjectsWithTag(Constants.ConbustibleTag))
		{
			Combustible heatModel = fuel.GetComponent<Combustible>();
			if(heatModel)
				totalInnerEnergy += heatModel.energy;
		}

		isWorldBurning = totalFreeEnergy + totalInnerEnergy > 0;

	}

	void updateGameStatus ()
	{
		costTime = Time.timeSinceLevelLoad - startTime;

		if(!isGameOver && Time.timeSinceLevelLoad - startTime > 7f 
		   && totalFreeEnergy == 0 && lighterNum == 0)
		{
			isGameOver = true;

			foreach(GameObject fuel in GameObject.FindGameObjectsWithTag(Constants.ConbustibleTag))
			{
				Combustible heatModel = fuel.GetComponent<Combustible>();
				if(heatModel && !heatModel.isBurned)
				{
					isWon = false;
					break;
				}
			}
			if(isWon)
			{
				float record = 999f;
				string key = "HighScore" + Application.loadedLevel.ToString("D2");
//				print (key);
				if(PlayerPrefs.HasKey(key))
					record = PlayerPrefs.GetFloat(key);
				if(costTime < record)
					PlayerPrefs.SetFloat(key,costTime);
			}
		}
	}

	public void lightingUp()
	{
		if(startTime == 0)
		{
			startTime = Time.timeSinceLevelLoad;
		}
	}

}
