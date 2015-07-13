using UnityEngine;
using System.Collections;

public class ScriptBotonMute : MonoBehaviour {

	// ## VARIABLES ##
	public GameObject laUi;
	public GameObject botonMute;
	public GameObject botonUnMute;

	public void OnMouseDown() {
		//Desactivamos el sonido
		laUi.GetComponent<AudioSource> ().enabled = false;
		laUi.GetComponent<AudioListener> ().enabled = false;
		botonUnMute.SetActive (true); 
		botonMute.SetActive (false); 
	}
	
}
