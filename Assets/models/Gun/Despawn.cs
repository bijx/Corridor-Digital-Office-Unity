using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (despawn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator despawn(){
		yield return new WaitForSeconds (5f);
		Destroy (this.gameObject);
	}
}
