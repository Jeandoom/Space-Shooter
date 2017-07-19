using UnityEngine;
using System.Collections;

public class Destorier : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Shot")) 
		{
			Destroy (other.gameObject);
		}
	}
}
