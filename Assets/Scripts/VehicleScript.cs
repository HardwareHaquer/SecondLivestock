using UnityEngine;
using System.Collections;

public class VehicleScript : MonoBehaviour {

	public Transform vehicle;
	public Transform player;
	public AudioClip vehicleRunningAudio;
	public AudioClip vehicleStopAudio;
	// Use this for initialization
	void Start () {
		player.SendMessage("setVehicle",vehicle);
	}
	void OnTriggerEnter(Collider other) {
		other.SendMessage ("setVehicleTrigger", true);
	}
	void OnTriggerExit(Collider other)
	{
		other.SendMessage ("setVehicleTrigger",false);
	}
	void StartVehicle()
	{
		AudioSource tractorSound = vehicle.GetComponent<AudioSource>();
		tractorSound.clip = vehicleRunningAudio;
		tractorSound.loop = true;
		tractorSound.Play();
	}
	void StopVehicle()
	{
		AudioSource tractorSound = vehicle.GetComponent<AudioSource>();
		tractorSound.clip = vehicleStopAudio;
		tractorSound.loop = false;
		tractorSound.Play();
	}
}
