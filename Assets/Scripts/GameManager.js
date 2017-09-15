#pragma strict

var fpc : GameObject;

function Start () {

	// Hide Cursor
	Screen.showCursor = false;

}

function Update () {

	if (Input.GetKeyDown ("escape")){
			if (Screen.showCursor == false) {
			fpc.SendMessage("ToggleInput", true);
			Screen.showCursor = true;
			}
			else {
				Screen.showCursor = false;
				fpc.SendMessage("ToggleInput", false);
			}
		}




}