﻿using UnityEngine;
using System.Collections;

public class soundScript : MonoBehaviour {
	public AudioSource audio;
	float[] spectrum = new float[256];
	public GameObject obj;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		audio.GetSpectrumData (spectrum, 0, FFTWindow.Hamming);
		int i = 1;
		while(i < spectrum.Length-1) {
			Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
			Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
			Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
			i++;
		} 
		/*
		GameObject inst = Instantiate (obj);
		inst.GetComponent<Renderer>().material.color = new Color (Random.value, Random.value, Random.value);
		inst.transform.localScale = new Vector3 (1000,1000,1000);
		inst.transform.position = new Vector3(-3,20,-1);

		print (obj.transform.position);*/
			
	}
}
