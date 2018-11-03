using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionZone : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.gameObject);
		if (col.gameObject.transform.parent.parent.tag == "MainCamera") {


			col.gameObject.transform.parent.parent.GetComponent<Camera> ().clearFlags = CameraClearFlags.SolidColor;
			col.gameObject.transform.parent.parent.GetComponent<Camera> ().farClipPlane = 0.06f;
		}

	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.transform.parent.parent.tag == "MainCamera") {
			col.gameObject.transform.parent.parent.GetComponent<Camera> ().clearFlags = CameraClearFlags.Skybox;
			col.gameObject.transform.parent.parent.GetComponent<Camera> ().farClipPlane = 300f;
		}
	}
}
