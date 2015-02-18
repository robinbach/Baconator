using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	private Text txt;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
		float record = 999f;
		string key = "HighScore" + Application.loadedLevel.ToString("D2");
		print (key);
		if(PlayerPrefs.HasKey(key))
			record = PlayerPrefs.GetFloat(key);

		txt.text = "Record:\t" + record.ToString("f1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
