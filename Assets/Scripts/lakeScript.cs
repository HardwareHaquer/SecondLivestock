using UnityEngine;
using System.Collections;

public class lakeScript : MonoBehaviour {

	public Transform lake;
	public Transform player;
	public AudioClip waveAudio;
	void Start () {
		player.SendMessage("setLake",lake);
	}
	void EatFood()
	{
		AudioSource tractorSound = lake.GetComponent<AudioSource>();
		tractorSound.clip = waveAudio;
		tractorSound.loop = false;
		tractorSound.Play();
	}
}
