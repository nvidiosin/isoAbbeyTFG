using UnityEngine;
using System.Collections;

public class ScriptBotonUnmute : MonoBehaviour {

	// ## VARIABLES ##
	public GameObject laUi;
	public GameObject botonMute;
	public GameObject botonUnMute;
	
	public void OnMouseDown() {
		//Activamos el sonido
		laUi.GetComponent<AudioSource> ().enabled = true;
		laUi.GetComponent<AudioListener> ().enabled = true;
		botonMute.SetActive (true);
		botonUnMute.SetActive (false); 
		 
	}
}
