using UnityEngine;
using System.Collections;



public class sphereController : MonoBehaviour {

	private enum PowerUp { ScoreUp, ScoreDown, LifeUp, LifeDown }

	float tiempo;

	PowerUp _powerUp;

	public Color[] colorValue;
	
	// Use this for initialization
	void Start () {	
		colorValue = new Color[4] {Color.red, Color.blue, Color.green, Color.yellow};
		tiempo = Time.realtimeSinceStartup;
		changeColor ();	
	}
	
	// Update is called once per frame
	void Update () {

		//Change Tag according to the color
		float tiempoNow = Time.realtimeSinceStartup;
		if (tiempoNow - tiempo > (5+UnityEngine.Random.value*5)) {
			GameObject.Destroy(gameObject);
			soundScript.numBalls--;
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		changeColor ();
	}

	public void DestroyObject(){

		gameObject.GetComponent<Renderer> ().material.color = new Color (0, 0, 0);

		//Here goes the function
		print ("La funcion de esa esfera sera:" + _powerUp);

		switch (_powerUp) {
		case PowerUp.ScoreUp:
			GameStatus.score += 10;
			break;
		case PowerUp.ScoreDown:
			if(GameStatus.score > 5)
				GameStatus.score -= 5;
			break;
		default:
			break;
		}

		print ("---- El score es de: ----  " + GameStatus.score); 

		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		gameObject.GetComponent<SphereCollider> ().attachedRigidbody.detectCollisions = false;

		soundScript.numBalls--; 
		
		StartCoroutine( cuenta ());

	}


	IEnumerator cuenta(){
		yield return new WaitForSeconds (1);
		Rigidbody.Destroy (gameObject);
	}

	private void changeColor(){

		//Select a random color between 0 and colorValue.Length - 1;
		_powerUp = (PowerUp)UnityEngine.Random.Range(0f, 4f);
		//Color the sphere
		GetComponent<Renderer>().material.color = colorValue[(int)_powerUp];
	}

}
