using UnityEngine;
using System.Collections;

public class exitBarnTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		other.SendMessage ("setState", 1);
	}
}
