using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScriptBotonSiguiente : MonoBehaviour {

	public int contadorClicks = 0;
	public GameObject TextoEscribir;
	public GameObject BotonPortada;
	public GameObject BotonJugar;
	private Text text; //Para modificar el texto

	public void OnMouseDown() {
		contadorClicks++;
		text = TextoEscribir.GetComponent<Text>(); 
		if (contadorClicks == 1) {
			text.text = "me dispongo a dejar constancia en este pergamino" +
				" de los hechos asombrosos y terribles que me fue dado" +
				" presenciar en mi juventud.";
		}
		if (contadorClicks == 2) {
			text.text = "El Señor me concede la gracia de dar fiel testimonio" +
				" de los acontecimientos que se produjeron en la abadia cuyo nombre" +
				" incluso conviene ahora cubrir con un piadoso manto de silencio;";
		}
		if (contadorClicks == 3) {
			text.text = "hacia finales de 1327, cuando mi padre decidio que acompañara" +
				" a fray Guillermo de Occam, sabio franciscano que estaba a punto de " +
				"iniciar una mision en el desempeño de la cual tocaria muchas ciudades" +
				"famosas y abadias antiquisimas.";
		}
		if (contadorClicks == 4) {
			text.text = "Asi fue como me converti al mismo tiempo en su amanuense y discipulo;" +
				" y no tuve que arrepentirme, porque con el fui testigo de acontecimientos dignos" +
				" de ser registrados, para memoria de los que vengan despues.";
		}
		if (contadorClicks == 5) {
			text.text = "Asi, mientras con los dias iba conociendo mejor a mi maestro, llegamos a las" +
				" faldas del monte donde se levantaba la abadia. Y ya es hora de que, como nosotros entonces," +
				" a ella se acerque mi relato,";
		}
		if (contadorClicks == 6) {
			text.text = "y ojala mi mano no tiemble cuando me dispongo a narrar lo que sucedio despues...";
		}
		if (contadorClicks == 7) {
			BotonPortada.SetActive(false);
			BotonJugar.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
