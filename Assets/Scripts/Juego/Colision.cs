using UnityEngine;
using System.Collections;

public class Colision : MonoBehaviour {


	public Cell destino; //la celda a la que se mueve
	public Entity quien; //quien se mueve
	private int i = 0;   //controla que solo se active la primera vez que pasemos

	//Detectar que se entra en el collider
	void OnTriggerEnter (Collider other)
	{
		if (i == 0) {
			//i++;
			StartCoroutine("Run");		
			//GameObject celda = quien.transform.parent;
			//Cell nueva = celda.GetComponent<Cell>();

		}
	}

	IEnumerator Run()
	{
		yield return new WaitForSeconds (1);
		GameEvent ge = ScriptableObject.CreateInstance<GameEvent>();
		ge.setParameter("entity", quien);
		ge.setParameter("cell", destino);
		ge.setParameter("distance", 2);
		ge.Name = "move";
		Game.main.enqueueEvent(ge);
		yield return  null;
	}

	/*Cell _destino;
	void perseguir()
	{
		if (this.transform.position - _destino.transform.position <= 1) {
			GameEvent ge = ScriptableObject.CreateInstance<GameEvent>();
			ge.setParameter("entity", quien);
			ge.setParameter("cell", destino);
			ge.setParameter("distance", 2);
			ge.Name = "move";
			_destino = destino;
			Game.main.enqueueEvent(ge);
		}
	}*/

}
