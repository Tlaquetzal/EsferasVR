using UnityEngine;
using System.Collections;

public class cambioPiso : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{

		GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, 
			UnityEngine.Random.value, 
			UnityEngine.Random.value);



	}
}
