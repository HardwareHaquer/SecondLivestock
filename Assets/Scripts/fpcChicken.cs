using UnityEngine;
using System.Collections;

public class fpcChicken : MonoBehaviour {

	public GameObject chicken;
	public Transform player;
	// Use this for initialization
	void Start () {
		player.SendMessage ("setChicken", chicken);
	}
}
