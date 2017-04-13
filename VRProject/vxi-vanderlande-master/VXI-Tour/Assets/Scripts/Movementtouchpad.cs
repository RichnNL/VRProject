using UnityEngine;
using System.Collections;
using Valve.VR;

public class Movementtouchpad : MonoBehaviour
{
	public GameObject player;
	//player is the camerarig
	SteamVR_Controller.Device device;
	SteamVR_TrackedObject controller;

	Vector2 touchpad;

	void Start()
	{
		controller = gameObject.GetComponent<SteamVR_TrackedObject>();
	}

	// Update is called once per frame
	void Update()
	{
		device = SteamVR_Controller.Input((int)controller.index);
		//If finger is on touchpad
		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
		{
			//Read the touchpad values
			touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);

			player.transform.position = new Vector3(player.transform.position.x + (-touchpad.y/25f), player.transform.position.y, player.transform.position.z + (touchpad.x/25f));
		}
	}
}