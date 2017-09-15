#pragma strict
var SpawnPoint: Transform; // drag the destination empty here
function Start () {

}

function Update () {
  if (Input.GetKey("0")){
  	// move and align the player to the destination empty GO
         this.transform.position = SpawnPoint.position;
         this.transform.rotation = SpawnPoint.rotation;
  }
}