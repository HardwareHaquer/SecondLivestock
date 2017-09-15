using UnityEngine;
using System.Collections;

public class FoodScript : MonoBehaviour {

	public Transform foodTrough;
	public Transform player;
	public AudioClip eatAudio;
	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		other.SendMessage ("setFoodTrigger", true);
	}
	void OnTriggerExit(Collider other)
	{
		other.SendMessage ("setFoodTrigger",false);
	}
	void EatFood()
	{
		AudioSource tractorSound = foodTrough.GetComponent<AudioSource>();
		tractorSound.clip = eatAudio;
		tractorSound.loop = false;
		tractorSound.Play();
	}
}
