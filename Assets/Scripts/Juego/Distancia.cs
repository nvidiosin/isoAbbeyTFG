using UnityEngine;
using System.Collections;

public class Distancia : MonoBehaviour {

	public Entity sujeto1;
	public Entity sujeto2;

	public Distancia(Entity uno, Entity dos)
	{
		sujeto1 = uno;
		sujeto2 = dos;
	}

	public float calculaDist(){
		float distance;
		distance = Vector3.Distance (sujeto1.transform.position, sujeto2.transform.position);
		return distance;
	}
}
