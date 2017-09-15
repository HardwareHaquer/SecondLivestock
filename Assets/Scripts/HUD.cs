using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour{
	protected int state = 0;
	void OnGUI () {
		//if (GUI.Button (new Rect (10,10,150,100), "I am a button")) {
		//	print ("You clicked the button!");
		//}
		switch(state)
		{
		case 0:
			GUI.TextArea( new Rect (10,10,100,50), "Escape The Barn");
			break;
		case 1:
			GUI.TextArea( new Rect(10,10,100,50), "Press Jump when near the Tractor to Ride it");
			break;
		case 2:
			GUI.TextArea( new Rect(10,10,100,50), "Achievement Unlocked: Eat Food");
			break;
		}

	}
	void setState(int tState)
	{
		state = tState;
	}
}