using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{

	public GameObject bullet;
	public Transform barrel;
	public ParticleSystem muzzleFlash;
	public float fireRate = 15f;
	public float nextTimeToFire = 0f;
	
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	public bool gripButtonDown = false;
	public bool gripButtonUp = false;
	public bool gripButtonPressed = false;


	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	public bool triggerButtonDown = false;
	public bool triggerButtonUp = false;
	public bool triggerButtonPressed = false;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }

	private SteamVR_TrackedObject trackedObj;

	void Start(){
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update ()
	{

		gripButtonDown = controller.GetPressDown (gripButton);
		gripButtonUp = controller.GetPressUp (gripButton);
		gripButtonPressed = controller.GetPress (gripButton);

		triggerButtonDown = controller.GetPressDown (triggerButton);
		triggerButtonUp = controller.GetPressUp (triggerButton);
		triggerButtonPressed = controller.GetPress (triggerButton);

		if (gripButtonDown) {

		}
		if (gripButtonUp) {
			
		}
		if (triggerButtonPressed && Time.time >= nextTimeToFire) {
			muzzleFlash.Play ();
			nextTimeToFire = Time.time + 1f / fireRate;
			controller.TriggerHapticPulse (3000);

			Transform pos = barrel.gameObject.transform;
			GameObject obj = (GameObject)Instantiate(bullet,new Vector3(pos.position.x,pos.position.y,pos.position.z),barrel.rotation);
			obj.GetComponent<Rigidbody> ().velocity = pos.up*30f;
		}
	}
}
	





