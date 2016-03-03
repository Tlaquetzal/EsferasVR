using UnityEngine;
using System.Collections;

public class sphereController : MonoBehaviour {

	float tiempo;
	// Use this for initialization
	void Start () {
		tiempo = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		float tiempoNow = Time.realtimeSinceStartup;
		if (tiempoNow - tiempo > (5+UnityEngine.Random.value*5)) {
			GameObject.Destroy(gameObject);
			soundScript.numBalls--;
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		
		col.gameObject.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value, 
		                                                                   UnityEngine.Random.value, 
		                                                                   UnityEngine.Random.value);
		
	}

	public void DestroyObject(){
		
		gameObject.GetComponent<Renderer> ().material.color = new Color (0, 0, 0);
		
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		gameObject.GetComponent<SphereCollider> ().attachedRigidbody.detectCollisions = false;
		
		
		StartCoroutine( cuenta ());
		
		
	}

	IEnumerator cuenta(){
		yield return new WaitForSeconds (1);
		Rigidbody.Destroy (gameObject);
	}
}
