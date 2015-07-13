using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour {

	//Personajes
	public Protagonista prota; // Guillermo como protagonista
	public Entity guille; // La entidad de Guillermo
	public Entity adso;
	public Entity abad; //La entidad del abad
	public Entity Berengario;
	public Entity Bernardo;
	public Entity Jorge;
	public Entity Malaquias;
	public Entity Severino;
	public string Nona = "Nona";
	//Luz direccional
	public GameObject Luz;
	//HUD
	public Canvas interfaz; //el HUD del juego
		//Carteles con los dias
		public GameObject CartelDIA1; //para mostrar u ocultar el cartel del dia 1
		public AudioSource audioCartelDia1;
		//Lo necesario para escribir en pantalla
		public GameObject ImagenEscribir;
		public GameObject TextoEscribir;
		//Lo necesario para escribir en las horas
		public GameObject TextoHoras;
		//Lo necesario para escribir en los dias
		public GameObject TextoDias;
		//Carteles de vida
		public GameObject CartelVida8;
		public GameObject CartelVida7;
		public GameObject CartelVida6;
		public GameObject CartelVida5;
		public GameObject CartelVida4;
		public GameObject CartelVida3;
		public GameObject CartelVida2;
		public GameObject CartelVida1;
		public GameObject CartelVida0;
	//Dia 1 Celdas Maquina Guille
		//Estas celdas controlan el movimiento del abad hacia la celda de guille
		public Cell celdaAbadEstado3Dia1;
		public Cell celdaAbadEstado6Dia1;
		public Cell celdaAbadEstado9Dia1;
		public Cell celdaAbadEstado12Dia1;
		public Cell celdaAbadEstado15Dia1;
		public Cell abadMisa;
	//Celdas de Adso
	public Cell AdsoMisa;
	//Celdas de Severino 
	public Cell SeverNona1; //Su celda Inicial
	public Cell SeverNona2; //Su celda Intermedia
	public Cell SeverNona3; //Su celda destino
	//Declaro la maquina de estados
	private List<MaquinaEstados> m_dias;
	private int m_diaActual;
	//Declaro la maquina de estados de los monjes
	private List<MaquinaEstados> m_monjes;

	/// <summary>
	/// Gets or sets the dia actual.
	/// </summary>
	/// <value>The dia actual.</value>
	public int DiaActual
	{
		get{return m_diaActual;}
		set{m_diaActual = value;}
	}

	private const int NUM_DIAS = 6;


	// Use this for initialization
	void Start () {
		DiaActual = 0; //Selecciono cual es el dia actual
		m_dias = new List<MaquinaEstados> ();
		m_dias.Add (new Dia1 (this));
		/**********/ 
		//La maquina de los monjes
		m_monjes = new List<MaquinaEstados> ();
		m_monjes.Add (new DiaM1 (this));
	}
	
	// Update is called once per frame
	void Update () {
		m_dias [DiaActual].EjecutarMaquina (); //Ejecuto la maquina de estados
		m_monjes [DiaActual].EjecutarMaquina (); //Ejecuto la maquina de los monjes
	}

	/* Esta funcion de encarga de controlar la barra de vida,
	 * se basa en ver que imagen esta activa actualmente,
	 * la desactiva y activa la siguiente
	 * */
	public void cambiaBarraVida() {
		int aux = 0;
		if ( (CartelVida8.activeInHierarchy) && (aux == 0) ) { // vida a 7
			CartelVida8.SetActive(false); //Desactiva la actual
			CartelVida7.SetActive(true);  //Activa la siguiente
			aux++;
		}
		if ( (CartelVida7.activeInHierarchy) && (aux == 0) ) { // vida a 6
			CartelVida7.SetActive(false);
			CartelVida6.SetActive(true);
			aux++;
		}
		if ( (CartelVida6.activeInHierarchy) && (aux == 0) ) { // vida a 5
			CartelVida6.SetActive(false);
			CartelVida5.SetActive(true);
			aux++;
		}
		if ( (CartelVida5.activeInHierarchy) && (aux == 0) ) { // vida a 4
			CartelVida5.SetActive(false);
			CartelVida4.SetActive(true);
			aux++;
		}
		if ( (CartelVida4.activeInHierarchy) && (aux == 0) ) { // vida a 3
			CartelVida4.SetActive(false);
			CartelVida3.SetActive(true);
			aux++;
		}
		if ( (CartelVida3.activeInHierarchy) && (aux == 0) ) { // vida a 2
			CartelVida3.SetActive(false);
			CartelVida2.SetActive(true);
			aux++;
		}
		if ( (CartelVida2.activeInHierarchy) && (aux == 0) ) { // vida a 1
			CartelVida2.SetActive(false);
			CartelVida1.SetActive(true);
			aux++;
		}
		if ( (CartelVida1.activeInHierarchy) && (aux == 0) ) { // vida a 0
			CartelVida1.SetActive(false);
			CartelVida0.SetActive(true);
			aux++; 
			Application.LoadLevel("GameOver");
		}
	}
}



public class MaquinaEstados
{
	protected List<Estados> m_estados;
	protected int m_estadoActual = 0;
	protected int m_estadoAnterior = -1;
	protected ControladorJuego m_controlador;
	public MaquinaEstados(ControladorJuego controlador)
	{
		m_controlador = controlador;
		m_estados = new List<Estados> ();
	}

	public void EjecutarMaquina()
	{
		m_estados [m_estadoActual].Ejecutar ();
		int prev = m_estadoActual;
		m_estadoActual = m_estados [m_estadoActual].Transicion (m_estadoActual, m_estadoAnterior);
		if (m_estadoActual != prev)
			m_estadoAnterior = prev;
	}
}

//Declaro el dia uno y los estados que le pertenecen
public class Dia1 : MaquinaEstados
{
	public Dia1(ControladorJuego controlador) : base(controlador)
	{
		m_estados.Add (new Dia1Stado0 (this.m_controlador));
		m_estados.Add (new Dia1Stado1 (this.m_controlador));
		m_estados.Add (new Dia1Stado2 (this.m_controlador));
		m_estados.Add (new Dia1Stado3 (this.m_controlador));
		m_estados.Add (new Dia1Stado4 (this.m_controlador));
		m_estados.Add (new Dia1Stado5 (this.m_controlador));
		m_estados.Add (new Dia1Stado6 (this.m_controlador));
		m_estados.Add (new Dia1Stado7 (this.m_controlador));
		m_estados.Add (new Dia1Stado8 (this.m_controlador));
		m_estados.Add (new Dia1Stado9 (this.m_controlador));
		m_estados.Add (new Dia1Stado10 (this.m_controlador));
		m_estados.Add (new Dia1Stado11 (this.m_controlador));
		m_estados.Add (new Dia1Stado12 (this.m_controlador));
		m_estados.Add (new Dia1Stado13 (this.m_controlador));
		m_estados.Add (new Dia1Stado14 (this.m_controlador));
		m_estados.Add (new Dia1Stado15 (this.m_controlador));
		m_estados.Add (new Dia1Stado16 (this.m_controlador));
		m_estados.Add (new Dia1Stado17 (this.m_controlador));
		m_estados.Add (new Dia1Stado18 (this.m_controlador));
	}
}

//Declaro el dia uno de los monjes y los estados que le pertenecen
public class DiaM1 : MaquinaEstados
{
	public DiaM1(ControladorJuego controlador) : base(controlador)
	{
		m_estados.Add (new DiaM1Nona (this.m_controlador));
	}
}

//La clase de los estados
public abstract class Estados
{
	protected ControladorJuego m_controlador;

	public Estados(ControladorJuego controlador)
	{
		m_controlador = controlador;
	}
	public abstract int Transicion(int state,int previousState);

	public abstract void Ejecutar();
}


/** Estado 0 Dia 1
 * En este estado vamos a mostrar el cartel de Dia1
 * Estara mostrado mientras dura el clip de sonido y tras esto
 * se quitara pasando al siguiente estado.
 **/
public class Dia1Stado0 : Estados
{
  	// ## VARIABLES ##
	float m_time; //Controla el tiempo para el estado
	bool m_init = false; //Para no estar ejecutando continuamente en el update
	GameObject cartel; //Contriene el cartel del dia1
	AudioSource sonido; //El sonido que suena con el dia1
	// ## CONSTRUCTORA ##
	public Dia1Stado0(ControladorJuego controlador): base(controlador){  //Constructora
		m_time = 0; 
		cartel = controlador.CartelDIA1;
		sonido = controlador.audioCartelDia1;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 4) {
			cartel.SetActive(false); //quito cartel
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (!m_init) {
			cartel.SetActive(true);
 			sonido.Play();
			m_init = true;
		}
	}
}

/** Estado 1 Dia 1
 * En este estado vamos a estar mientras el usuario
 * se familiariza con los controles, y permanecemos 
 * aqui hasta que llegamos delante del abad
 **/
public class Dia1Stado1 : Estados
{
	// ## VARIABLES ##
	Protagonista gui;  //Lo vamos a utilizar para saber cuando guille llega delante del abad
	bool m_init = false; //Para no estar ejecutando continuamente en el update
	GameObject escribeHora;
	Text text; //Para modificar el texto
	int aux = 0;
	// ## CONSTRUCTORA ##
	public Dia1Stado1(ControladorJuego controlador): base(controlador){
		gui = controlador.prota;
		escribeHora = controlador.TextoHoras;
		text = escribeHora.GetComponent<Text>(); 
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (gui.entrae1d1 && !m_init) {  //Si Guillermo llega a la celda avanza al siguiente estado
			m_init = true;
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		if (aux == 0) {
			text.text = "Nona";
			aux++;
		}
	}
}

/** Estado 2 Dia 1
 * Al entrar en la habitacion del abad este nos mostrara un texto
 * y se movera hacia la celda de guille.
 **/
public class Dia1Stado2 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo de mostrado de cartel.
	GameObject imgEscribe; //El objeto del controlador de la imagen del cartel
	GameObject textEscribe; //El objeto del controlador del texto
	Text text; //Para modificar el texto
	bool siguiente = false; //Controla el salto al siguiente estado
	// ## CONSTRUCTORA ##
	public Dia1Stado2(ControladorJuego controlador): base(controlador){
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		text = textEscribe.GetComponent<Text>(); 
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 4) {
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		text.text = "Bienvenido a esta abadia, hermano. Os ruego que me sigais." +
			" Ha sucedido algo terrible.";
		imgEscribe.SetActive(true);
		textEscribe.SetActive(true);
	}
}

/** Estado 3 Dia 1
 * El abad comienza a moverse hacia la celda de guille
 * Se mueve a medio pasillo
 **/
public class Dia1Stado3 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo para el estado
	bool cambiarEstado = false;
	Entity quien; //Quien se mueve
	Cell destino; //Hasta donde se mueve
	int i = 0; //Controla para evitar repeticiones
	// ## CONSTRUCTORA ##
	public Dia1Stado3(ControladorJuego controlador): base(controlador){
		m_time = 0;
		quien = controlador.abad;
		destino = controlador.celdaAbadEstado3Dia1;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (cambiarEstado && (m_time > 4)) {
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (i == 0) {
			RutinaMovimiento paraMover = new RutinaMovimiento (destino, quien);
			paraMover.comienzo();
			cambiarEstado = true;
			i++;
		}
	}
}


/** Estado 4 Dia 1
 * El abad se ha movido, ahora compruebo si Guillermo nos sigue
 * si nos sigue avanzo al estado 6
 * si no nos sigue voy al estado 5
 **/
public class Dia1Stado4 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo 
	float laDistancia; //Guarda la distancia con el abad
	Entity guille; //Entidad de Guille
	Entity abad; //Entidad del abad
	int futuroEstado = 0; //Para la eleccion de cual va a ser el proximo estado
	bool siguiente = false; //Controla el avance al estado siguiente
	int aux1 = 0;
	// ## CONSTRUCTORA ##
	public Dia1Stado4(ControladorJuego controlador): base(controlador){
		guille = controlador.guille;
		abad = controlador.abad;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (siguiente) {
			m_time = 0;
			siguiente = false;
			return futuroEstado;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (m_time > 3) {
			Distancia paraDistancia = new Distancia (guille, abad);
			laDistancia = paraDistancia.calculaDist();
			//Aqui se comprueba la distancia a la que se encuentra Guillermo
			if (laDistancia >= 3){ //si no se acerca
				futuroEstado = 5;
				siguiente = true;
			} else { //si se acerca
				futuroEstado = 6;
				siguiente = true;
			}
		}
	}
}

/** Estado 5 Dia 1
 * Amenazamos a Guille con que se acerque y le quitamos un punto de vida
 * si no se nos acerca, en caso de que se acerque avanzamos a estado 6.
 **/
public class Dia1Stado5 : Estados
{
	// ## VARIABLES ##
	int lock1 = 0; //Cerrojo1 para volver al estado con el update 
	int lock2 = 0; //Cerrojo2 para volver al estado con el update
	float m_time; //Para el controlar el tiempo
	GameObject imgEscribe; //La imagen del cartel de texto
	GameObject textEscribe; //El objeto del cartel del texto
	Text text; //Para poder modificar el cartel de texto
	bool siguiente = false; //Controla el estado siguiente
	ControladorJuego vida; //Para modificar la vida
	// ## CONSTRUCTORA ##
	public Dia1Stado5(ControladorJuego controlador): base(controlador){
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		text = textEscribe.GetComponent<Text>(); 
		vida = controlador;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 4) {
			if (lock2 == 0){
				vida.cambiaBarraVida();
				lock2++;
			}
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			m_time = 0;
			lock1 = 0;
			return state = previousState;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (lock1 == 0) {
			text.text = "Guillermo sigueme.";
			imgEscribe.SetActive (true);
			textEscribe.SetActive (true);
			lock2 = 0;
			lock1++;
		}
	}
}

/** Estado 6 Dia 1
 * El abad sigue avanza a la siguiente celda de control
 * la celda es celdaAbadEstado6Dia1
 * tambien muestra el siguiente cartel de introduccion a la abadia
 **/
public class Dia1Stado6 : Estados
{
	// ## VARIABLES ##
	float m_time;
	bool cambiarEstado = false;
	Entity quien;
	Cell destino;
	int i = 0;
	GameObject imgEscribe;
	GameObject textEscribe;
	Text text;
	// ## CONSTRUCTORA ##
	public Dia1Stado6(ControladorJuego controlador): base(controlador){
		m_time = 0;
		quien = controlador.abad;
		destino = controlador.celdaAbadEstado6Dia1;
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		text = textEscribe.GetComponent<Text>(); 
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (cambiarEstado && (m_time > 10)) {
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (i == 0) {
			RutinaMovimiento paraMover = new RutinaMovimiento (destino, quien);
			paraMover.comienzo();
			text.text = "Temo que uno de los monjes haya cometido un crimen." +
				" Os ruego que lo encontréis antes de que llegue Bernardo Gui," +
				" pues no deseo que se manche el nombre de esta abadía";
			imgEscribe.SetActive(true);
			textEscribe.SetActive(true);
			cambiarEstado = true;
			i++;
		}
	}
}

/** Estado 7 Dia 1
 * El abad se ha movido, ahora compruebo si Guillermo nos sigue
 * si nos sigue avanzo al estado 9
 * si no nos sigue voy al estado 8
 **/
public class Dia1Stado7 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo 
	float laDistancia; //Guarda la distancia con el abad
	Entity guille; //Entidad de Guille
	Entity abad; //Entidad del abad
	int futuroEstado = 0; //Para la eleccion de cual va a ser el proximo estado
	bool siguiente = false; //Controla el avance al estado siguiente
	int aux1 = 0;
	// ## CONSTRUCTORA ##
	public Dia1Stado7(ControladorJuego controlador): base(controlador){
		guille = controlador.guille;
		abad = controlador.abad;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (siguiente) {
			m_time = 0;
			siguiente = false;
			return futuroEstado;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		Debug.Log (m_time.ToString());
		if (m_time > 3) {
			Distancia paraDistancia = new Distancia (guille, abad);
			laDistancia = paraDistancia.calculaDist();
			//Aqui se comprueba la distancia a la que se encuentra Guillermo
			if (laDistancia >= 3){ //si no se acerca
				futuroEstado = 5;
				siguiente = true;
			} else { //si se acerca
				futuroEstado = 8;
				siguiente = true;
			}
		}
	}
}

/** Estado 8 Dia 1
 * El avad sigue moviendose hacia la celda de guille
 **/
public class Dia1Stado8 : Estados
{
	// ## VARIABLES ##
	float m_time;
	bool cambiarEstado = false;
	Entity quien;
	Cell destino;
	int i = 0;
	GameObject imgEscribe;
	GameObject textEscribe;
	Text text;
	// ## CONSTRUCTORA ##
	public Dia1Stado8(ControladorJuego controlador): base(controlador){
		m_time = 0;
		quien = controlador.abad;
		destino = controlador.celdaAbadEstado9Dia1;
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		text = textEscribe.GetComponent<Text>(); 
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (cambiarEstado && (m_time > 20)) {
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (i == 0) {
			RutinaMovimiento paraMover = new RutinaMovimiento (destino, quien);
			paraMover.comienzo();
			text.text = "Debéis respetar mis órdenes y las de la abadía. Asistir a los oficios y a la comida." +
				" De noche debéis estar en vuestra celda";
			imgEscribe.SetActive(true);
			textEscribe.SetActive(true);
			cambiarEstado = true;
			i++;
		}
	}
}

/** Estado 10 Dia 1
 * El abad se ha movido, ahora compruebo si Guillermo nos sigue
 * si nos sigue avanzo al estado 6
 * si no nos sigue voy al estado 5
 **/
public class Dia1Stado9 : Estados
{
	// ## VARIABLES ##
	float m_time;
	float laDistancia;
	Entity guille;
	Entity abad;
	int futuroEstado = 0;
	bool siguiente = false;
	// ## CONSTRUCTORA ##
	public Dia1Stado9(ControladorJuego controlador): base(controlador){
		guille = controlador.guille;
		abad = controlador.abad;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (siguiente) {
			return futuroEstado;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (m_time > 2) {
			Distancia paraDistancia = new Distancia (guille, abad);
			laDistancia = paraDistancia.calculaDist();
			if (laDistancia >= 3){ //si no se acerca
				futuroEstado = 5;
				siguiente = true;
			} else { //si se acerca
				futuroEstado = 10;
				siguiente = true;
			}
		}
	}
	
}

/** Estado 10 Dia 1
 * Avanzamos delante del pasillo
 **/
public class Dia1Stado10 : Estados
{
	// ## VARIABLES ##
	float m_time;
	bool cambiarEstado = false;
	Entity quien;
	Cell destino;
	int i = 0;
	// ## CONSTRUCTORA ##
	public Dia1Stado10(ControladorJuego controlador): base(controlador){
		m_time = 0;
		quien = controlador.abad;
		destino = controlador.celdaAbadEstado12Dia1;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (cambiarEstado && (m_time > 20)) {
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (i == 0) {
			RutinaMovimiento paraMover = new RutinaMovimiento (destino, quien);
			paraMover.comienzo();
			cambiarEstado = true;
			i++;
		}
	}
}

/** Estado 13 Dia 1
 * El abad se ha movido, ahora compruebo si Guillermo nos sigue
 * si nos sigue avanzo al estado 15
 * si no nos sigue voy al estado 14
 **/
public class Dia1Stado11 : Estados
{
	// ## VARIABLES ##
	float m_time;
	float laDistancia;
	Entity guille;
	Entity abad;
	int futuroEstado = 0;
	bool siguiente = false;
	// ## CONSTRUCTORA ##
	public Dia1Stado11(ControladorJuego controlador): base(controlador){
		guille = controlador.guille;
		abad = controlador.abad;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (siguiente) {
			return futuroEstado;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (m_time > 2) {
			Distancia paraDistancia = new Distancia (guille, abad);
			laDistancia = paraDistancia.calculaDist();
			if (laDistancia >= 3){ //si no se acerca
				futuroEstado = 5;
				siguiente = true;
			} else { //si se acerca
				futuroEstado = 12;
				siguiente = true;
			}
		}
	}
}

/** Estado 15 Dia 1
 * Avanzamos delante del pasillo
 **/
public class Dia1Stado12 : Estados
{
	// ## VARIABLES ##
	float m_time;
	bool cambiarEstado = false;
	Entity quien;
	Cell destino;
	int i = 0;
	// ## CONSTRUCTORA ##
	public Dia1Stado12(ControladorJuego controlador): base(controlador){
		m_time = 0;
		quien = controlador.abad;
		destino = controlador.celdaAbadEstado15Dia1;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (cambiarEstado && (m_time > 20)) {
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (i == 0) {
			RutinaMovimiento paraMover = new RutinaMovimiento (destino, quien);
			paraMover.comienzo();
			cambiarEstado = true;
			i++;
		}
	}
}

/** Estado 16 Dia 1
 * El abad se ha movido, ahora compruebo si Guillermo nos sigue
 * si nos sigue avanzo al estado 6
 * si no nos sigue voy al estado 5
 **/
public class Dia1Stado13 : Estados
{
	// ## VARIABLES ##
	float m_time;
	float laDistancia;
	Entity guille;
	Entity abad;
	int futuroEstado = 0;
	bool siguiente = false;
	// ## CONSTRUCTORA ##
	public Dia1Stado13(ControladorJuego controlador): base(controlador){
		guille = controlador.guille;
		abad = controlador.abad;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (siguiente) {
			return futuroEstado;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		if (m_time > 2) {
			Distancia paraDistancia = new Distancia (guille, abad);
			laDistancia = paraDistancia.calculaDist();
			if (laDistancia >= 3){ //si no se acerca
				futuroEstado = 5;
				siguiente = true;
			} else { //si se acerca
				futuroEstado = 14;
				siguiente = true;
			}
		}
	}
}

/** Estado 14 Dia 1
 * El abad nos enseña nuestra habitacion y se marcha
 **/
public class Dia1Stado14 : Estados
{
	// ## VARIABLES ##
	float m_time;
	GameObject imgEscribe;
	GameObject textEscribe;
	Text text;
	bool siguiente = false;
	// ## CONSTRUCTORA ##
	public Dia1Stado14(ControladorJuego controlador): base(controlador){
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		text = textEscribe.GetComponent<Text>(); 
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 4) {
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		text.text = "Esta es vuestra celda. Debo irme";
		imgEscribe.SetActive(true);
		textEscribe.SetActive(true);
	}
}

/** Estado 15 Dia 1
 * Adso nos dice que tenemos tiempo para explorar la abadia hasta la proxima misa
 **/
public class Dia1Stado15 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo de mostrado de cartel.
	GameObject imgEscribe; //El objeto del controlador de la imagen del cartel
	GameObject textEscribe; //El objeto del controlador del texto
	Text text; //Para modificar el texto
	bool siguiente = false; //Controla el salto al siguiente estado
	// ## CONSTRUCTORA ##
	public Dia1Stado15(ControladorJuego controlador): base(controlador){
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		text = textEscribe.GetComponent<Text>(); 
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 4) {
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		text.text = "Guille, nos queda algo de tiempo hasta la siguiente misa, exploremos";
		imgEscribe.SetActive(true);
		textEscribe.SetActive(true);
	}
}

/** Estado 16 Dia 1
 * Paseamos por la abadia durante 3 minutos
 **/
public class Dia1Stado16 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo de mostrado de cartel.
	bool siguiente = false; //Controla el salto al siguiente estado
	GameObject laLuz; //este GameObject controla el acceso a la luz
	int r = 255;
	int g = 255;
	int b = 255;
	// ## CONSTRUCTORA ##
	public Dia1Stado16(ControladorJuego controlador): base(controlador){
		laLuz = controlador.Luz;
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 10) {
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
	}
}

/** Estado 17 Dia 1
 * Adso nos dice que debemos ir a la iglesia
 **/
public class Dia1Stado17 : Estados
{
	// ## VARIABLES ##
	float m_time; //Controla el tiempo de mostrado de cartel.
	GameObject imgEscribe; //El objeto del controlador de la imagen del cartel
	GameObject textEscribe; //El objeto del controlador del texto
	GameObject horas; //Para modificar las horas
	Text text; //Para modificar el texto de las ventanas
	Text text1; //Para modificar el texto de las horas
	bool siguiente = false; //Controla el salto al siguiente estado
	// ## CONSTRUCTORA ##
	public Dia1Stado17(ControladorJuego controlador): base(controlador){
		imgEscribe = controlador.ImagenEscribir;
		textEscribe = controlador.TextoEscribir;
		horas = controlador.TextoHoras;
		text = textEscribe.GetComponent<Text>(); 
		text1 = horas.GetComponent<Text>();
		m_time = 0;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (m_time > 4) {
			imgEscribe.SetActive(false);
			textEscribe.SetActive(false);
			return state = state + 1;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		m_time += Time.deltaTime;
		text.text = "Debemos ir a la iglesia maestro";
		text1.text = "Visperas";
		imgEscribe.SetActive(true);
		textEscribe.SetActive(true);
	}
}

/** Estado 18 Dia 1
 * Adso nos guia a la misa
 **/
public class Dia1Stado18 : Estados
{
	// ## VARIABLES ##
	Entity abad; 
	Cell destinoAbad;
	Entity quien; //Quien se mueve
	Cell destino; //Hasta donde se mueve
	int i = 0; 
	bool cambiarEstado = false; 
	// ## CONSTRUCTORA ##
	public Dia1Stado18(ControladorJuego controlador): base(controlador){
		quien = controlador.adso;
		abad = controlador.abad;
		destinoAbad = controlador.abadMisa;
		destino = controlador.AdsoMisa;
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		quien.GetComponent<Perseguir>().enabled = false; 
		if (i == 0) {
			RutinaMovimiento paraMover = new RutinaMovimiento (destino, quien);
			paraMover.comienzo();
			RutinaMovimiento paraMover2 = new RutinaMovimiento (destinoAbad, abad);
			paraMover2.comienzo();
			cambiarEstado = true;
			i++;
		}
	}
}


// ###########################################################################################################
// ################################### MAQUINA DE ESTADOS DE LOS OTROS MONJES ################################
// ###########################################################################################################

/** Estado Nona Dia 1 Monjes
 * Severino da paseos por la abadia
 **/
public class DiaM1Nona : Estados
{
	// ## VARIABLES ##
	Entity severino;
	Cell celdaSeverino1; //Su inicial
	Cell celdaSeverino2; //Su destino
	GameObject horas;
	GameObject dias;
	Text textoHoras;
	Text textoDias;
	int aux = 0;
	// ## CONSTRUCTORA ##
	public DiaM1Nona(ControladorJuego controlador): base(controlador){  //Constructora
		severino = controlador.Severino;
		celdaSeverino1 = controlador.SeverNona1;
		celdaSeverino2 = controlador.SeverNona2;
		horas = controlador.TextoHoras;
		dias = controlador.TextoDias;
		textoHoras = horas.GetComponent<Text>(); 
		textoDias = dias.GetComponent<Text>(); 
	}
	// ## FUNCION TRANSICION ##
	public override int Transicion(int state, int previousState){
		if (textoHoras.text.Equals ("Completas")) {
			return state++;
		}
		return state;
	}
	// ## FUNCION EJECUTAR ##
	public override void Ejecutar(){
		//Chequeo que estoy en nona
		if (textoHoras.text.Equals("Nona")) {
			if (aux== 0){
				RutinaMovimiento paraMover = new RutinaMovimiento (celdaSeverino2, severino);
				paraMover.comienzo();
				aux++;
			}
		}
	}
}