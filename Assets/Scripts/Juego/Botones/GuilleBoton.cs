using UnityEngine;
using System.Collections;

public class GuilleBoton : MonoBehaviour {

	// ## VARIABLES ##
	public Entity adso;
	public Entity guille;
	public GameObject aQuienMiro;
	public GameObject compGame;
	//Las imagenes del opuesto
	public GameObject guiCol;
	public GameObject guiBN;
	//Las imagenes de adso
	public GameObject adsoCol;
	public GameObject adsoBN;
	
	
	public void OnMouseDown() {
		//miro si Guille no esta activo
		if (guiBN.activeInHierarchy) {
			//desactivo la cara de Adso a color
			adsoCol.SetActive(false);
			//activo la cara de Adso gris
			adsoBN.SetActive(true);
			//desactivo la cara gris de Guille
			guiBN.SetActive(false);
			//activo la cara de color de Guille
			guiCol.SetActive(true);
			//desactivo el componente player de guille
			//Destroy (guille.GetComponent<Player>());
				//adso.GetComponent<Player>().Activar(false);
			//creo el componente player de adso
				//guille.GetComponent<Player>().Activar (true);
			//desactivo el componente perseguir de Guille
			guille.GetComponent<Perseguir>().enabled = false;
			//activo el componente perseguid de Adso
			adso.GetComponent<Perseguir>().enabled = true;
			//cambio a quien miro de game
			compGame.GetComponent<Game>().look = aQuienMiro;
		}
	}
	
}
