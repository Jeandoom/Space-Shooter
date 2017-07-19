using UnityEngine;
using System.Collections;

public class DestoryByAsteroid : MonoBehaviour {
	
	public GameObject asteroid;
	public GameObject asteroidExplosion;
	public GameObject playerExplosion;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameObject.gameObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		} 
		else
		{
			Debug.Log ("Can not find gameController");
		}

		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Up Boundary") || other.CompareTag ("Asteroid")) 
		{
			return;
		}
		else
		{
			Destroy (asteroid);
			if (other.CompareTag ("Shot")) 
			{
				Instantiate (asteroidExplosion, asteroid.transform.position, asteroid.transform.rotation);
				gameController.AddScore ();
			}
			else if (other.CompareTag ("Player")) 
			{
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				StartCoroutine( gameController.GameOver (true));
			}
			if (other.CompareTag ("Down Boundary")) 
			{
				return;
			}
			Destroy (other.gameObject);
		}



	}


}
