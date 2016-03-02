using UnityEngine;
using System.Collections;

public class cloner : MonoBehaviour {

	public GameObject esfera;
	public float tiempoAEsperar;
	public float size;
	private float timeNow;

	// Use this for initialization
	void Start () {
		timeNow = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.realtimeSinceStartup;

		if (t - timeNow > tiempoAEsperar) {
			GameObject inst = Instantiate (esfera);
			float radius = Random.value * size;

			inst.transform.localScale = new Vector3(radius, radius, radius);
			inst.GetComponent<Renderer>().material.color = new Color (Random.value, Random.value, Random.value);
			Color emission = new Color (UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
			inst.gameObject.GetComponent<Renderer> ().material.SetColor ("_EmissionColor", emission);
			inst.transform.position = new Vector3 (Random.value * 9 * neg(), 20, Random.value * 10 * neg());
			timeNow = t;
		}
	}

	private int neg(){
		return Random.value > 0.49 ? 1 : -1;
	}
}
