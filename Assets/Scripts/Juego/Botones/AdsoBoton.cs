using UnityEngine;
using System.Collections;



public class AdsoBoton : MonoBehaviour {

	private class ButtonCapturer : IsoGUI {

		public bool mouseDownFix;

		public override bool captureEvent (ControllerEventArgs args)
		{
			bool r = false;

			if (args.isLeftDown) {
				Debug.Log ("LeftDown");
			}

			if (args.isLeftDown && mouseDownFix) {
				mouseDownFix = false;
				r = true;
			}

			return r;
		}

		public override void fillControllerEvent (ControllerEventArgs args){}
		public override void draw (){}
	}

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
	//prueba de mirar
	public GameObject game;

	// fixing the cell bug
	private ButtonCapturer buttonCapturer;

	void Start(){
		// ScriptableObject not detected if it's a private class
		buttonCapturer = new ButtonCapturer();
		GUIManager.addGUI (buttonCapturer);
	}

	public void OnMouseDown() {

		//miro si adso no esta activo
		if (adsoBN.activeInHierarchy) {
			Debug.Log ("Button Mouse down");
			buttonCapturer.mouseDownFix = true;

			//desactivo la cara de guille a color
			guiCol.SetActive(false);
			//activo la cara de guille gris
			guiBN.SetActive(true);
			//desactivo la cara gris de adso
			adsoBN.SetActive(false);
			//activo la cara de color de adso
			adsoCol.SetActive(true);
			//desactivo el componente player de guille
				//guille.GetComponent<Player>().Activar(false);
			//creo el componente player de adso
				//adso.GetComponent<Player>().Activar (true);
			//desactivo el componente perseguir de adso
			adso.GetComponent<Perseguir>().enabled = false;
			//Modificado por issue
				//activo el componente perseguid de guille
				//guille.GetComponent<Perseguir>().enabled = true;


			//modificar a quien miro
			//aqui quiero decir que quiero mirar a adso
			CameraManager.smoothLookTo(aQuienMiro);



			//cambio a quien miro de game
			compGame.GetComponent<Game>().look = aQuienMiro;
		}
	}

}
