var TelePosition : Transform; // drag the destination empty here
  
 function OnTriggerEnter(other : Collider) 
 {
     if (other.tag == "Player") 
     {   
      // move and align the player to the destination empty GO
         other.transform.position = TelePosition.position;
         other.transform.rotation = TelePosition.rotation;
     }        
 }
