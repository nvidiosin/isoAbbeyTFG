using UnityEngine;
using System.Collections;

public class GuilleColision : MonoBehaviour {
	
	private int entrae1d1c = 0;
	private Protagonista protagonista;

	// Use this for initialization
	void Start () {
		protagonista = GetComponent<Protagonista> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Detectar que se entra en el collider
	void OnTriggerEnter (Collider other)
	{
		if (entrae1d1c == 0) {
			if (other.name.Equals("CeldaE1D1")){
				protagonista.entrae1d1 = true;
				entrae1d1c++;
			}
		}
	}


}
