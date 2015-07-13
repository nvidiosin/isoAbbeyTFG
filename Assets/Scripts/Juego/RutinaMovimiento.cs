using UnityEngine;
using System.Collections;

public class RutinaMovimiento : MonoBehaviour {


	public Cell destino; //la celda a la que se mueve
	public Entity quien; //quien se mueve


	public RutinaMovimiento(Cell celda, Entity ese)
	{
		destino = celda;
		quien = ese;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {

	}

	public void comienzo(){
		GameEvent ge = ScriptableObject.CreateInstance<GameEvent>();
		ge.setParameter("entity", quien);
		ge.setParameter("cell", destino);
		ge.setParameter("synchronous", true);
		ge.setParameter("distance", 1);
		ge.Name = "move";
		Game.main.enqueueEvent(ge);
	}


}
