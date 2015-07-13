using UnityEngine;
using System.Collections;

public class Protagonista : MonoBehaviour {

	public bool entrae1d1 = false;
	public int hp = 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool getEntradae1d1(){
		return entrae1d1;
	}

	void setEntradae1d1(bool aux){
		entrae1d1 = aux;
	}

}
