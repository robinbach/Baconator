using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedMeter : MonoBehaviour {

	private Text txt;
	private TimeControl timeControl;
	private float speed = 1.0f;
	// Use this for initialization
	void Start () {
;
		timeControl = Camera.main.GetComponent<TimeControl> ();
		txt = transform.parent.GetComponent<Text>();
	
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//
//	}
	
	public void updateSliderValue ()
	{
		Slider thisSlider = this.GetComponent<Slider> ();
		int value = Mathf.RoundToInt (thisSlider.value);
		switch(value)
		{
		case 0:
			speed = 0.5f;
			break;
		case 1:
			speed = 1.0f;
//			speed = value * Mathf.Pow(2, value - 2);
			break;
		case 2:
			speed = 2.0f;
			break;
		case 3:
			speed = 4.0f;
			break;
		default:
			speed = value * 2.0f;
			break;
		}

		txt.text = "Speed:\t" + speed.ToString("f1");
		timeControl.speed = speed;
	}

}
