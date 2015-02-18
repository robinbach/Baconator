using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ShowInstruction : MonoBehaviour {

	private Text txt;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowText()
	{
		string instructions = "";
		switch(Application.loadedLevel)
		{
		case 1:
			instructions="Light up the grass by one click,  Only one chance! ";
			break;
		case 2:
			instructions="Darker color material: wood. Harder to be lighted but provide more" +
				" energy!";

			break;
		case 3:
			instructions="The coal. Really hard to burn but I provide you an amount of grass to the rescue.";

			break;
		case 4:
			instructions="A complete building consists of all the materials. Have a good burn!";

			break;
		case 5:
			instructions="Let's burn something new here. Something may called your GPU or CPU or RAM...";

			break;
		default:
			break;
		}
		txt.text = instructions;
	}
}
