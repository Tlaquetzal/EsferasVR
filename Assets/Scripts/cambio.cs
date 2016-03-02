using UnityEngine;
using System.Collections;
using System;

public class cambio : MonoBehaviour {

	float tiempo;
	// Use this for initialization
	void Start () {
		tiempo = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		

	}
		  
	void OnCollisionEnter (Collision col)
	   {

	col.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, 
			                                                                   UnityEngine.Random.value, 
			                                                                   UnityEngine.Random.value);
		float tiempoNow = Time.realtimeSinceStartup;

		if (tiempoNow - tiempo > (7+-UnityEngine.Random.value*5)) {
			GameObject.Destroy(gameObject);
		}

	}

}
