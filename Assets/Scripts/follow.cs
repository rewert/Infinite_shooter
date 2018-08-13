using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	Vector3 mod;

	// Use this for initialization
	void Start () {
		mod = this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Player") == null){
			return;
		}
		this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + mod;
	}
}
