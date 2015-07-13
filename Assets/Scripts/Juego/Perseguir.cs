using UnityEngine;
using System.Collections;

public class Perseguir : MonoBehaviour {

	public Entity perseguidor; //quien persigue
	public Entity perseguido; //a quien persigo
	public Cell destino;
	private float distance;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (perseguidor.transform.position, perseguido.transform.position);
		//Debug.Log (distance);
		if (distance > 1) {
			StartCoroutine("Run");	
		}
		destino = perseguido.Position;
	}



	IEnumerator Run()
	{
		yield return new WaitForSeconds (1);
		GameEvent ge = ScriptableObject.CreateInstance<GameEvent>();
		ge.setParameter("entity", perseguidor);
		ge.setParameter("cell", destino);
		ge.setParameter("distance", 2);
		ge.Name = "move";
		Game.main.enqueueEvent(ge);
		yield return  null;
	}


}
