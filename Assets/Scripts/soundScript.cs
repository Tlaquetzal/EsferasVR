using UnityEngine;
using System.Collections;

public class soundScript : MonoBehaviour {

	public static int numBalls = 0;
	public AudioSource audio;
	float[] spectrum = new float[1024];
	public GameObject obj;



	private float timeNow;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		timeNow = Time.realtimeSinceStartup;

	}
	
	// Update is called once per frame
	void Update () {

		audio.GetSpectrumData (spectrum, 1, FFTWindow.Hanning);

		float[] sumas = new float[3];
		sumas [0] = 0;
		sumas [1] = 0;
		sumas [2] = 0;
		for (int i = 0; i < 1024; i++) {
			if (i < 340) {
				sumas [0] += spectrum [i];
			} else if (i > 340 && i < 680) {
				sumas [1] += spectrum [i];
			} else {
				sumas [2] += spectrum [i];
			}
		
		}
		float sumaT = Mathf.Pow(2,(sumas[2]+sumas[1]+sumas[0]));
		float t = Time.realtimeSinceStartup;
		if(t - timeNow > 1){
			int c = (int)(sumaT*10*0.3f);
			for(int i = 0; i < c; i++){
				if (numBalls > 50)
					break;	
				GameObject inst = Instantiate (obj);
				inst.transform.localScale = new Vector3 (100,100,100);
				int rd = (int)UnityEngine.Random.value * 250;
				inst.transform.position = new Vector3(Mathf.Log(sumas[0]*10,2)*neg(),(Mathf.Sin(sumas[2]*4000)*10+10),Mathf.Log(sumas[1]*3)*neg());
				numBalls++;
			}

			timeNow = t;
		}

	}

	private int neg(){
		return Random.value > 0.49 ? 1 : -1;
	}
}
