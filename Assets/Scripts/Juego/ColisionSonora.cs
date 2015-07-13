using UnityEngine;
using System.Collections;

public class ColisionSonora : MonoBehaviour {

	private int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Detectar que se entra en el collider
	void OnTriggerEnter (Collider other)
	{
		GetComponent<AudioSource>().Play();
	}

}
