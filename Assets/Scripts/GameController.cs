using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {

	public float lifetime;
	public float wavesRate;
	public float waitTime;
	public GameObject hazard;
	public Vector3 spawnValues;
	public GUIText scoreText;
	public GUIText endText;
	public GUIText restartText;


	private float endtime;
	private int score;
	private float nextTime;
	private bool gameOver;
	private bool restart;

	void Start()
	{
		score = 0;
		endText.text = "";
		restartText.text = "";
		gameOver = false;
		restart = false;
		UpdateScore ();
		SpawnWaves ();
		nextTime = Time.time + wavesRate;
		endtime = Time.time + lifetime;
	}

	void Update()
	{
		
		if (Time.time >= nextTime && Time.time < endtime && !gameOver) 
		{
			
			SpawnWaves ();
			nextTime = Time.time + wavesRate;

		}

		if(Time.time >= endtime )
		{
			StartCoroutine(GameOver (false));
		}

		if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}

	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;

		Instantiate (hazard, spawnPosition, spawnRotation);
	}

	public void AddScore()
	{
		score = score + 10;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score:" + score.ToString();
	}

	public  IEnumerator  GameOver(bool end)
	{
		gameOver = true;
		restart = true;	

		if (!end) yield return new WaitForSeconds (waitTime);

		endText.text = "Game Over";
		restartText.text = "Press 'R' for Restart";

	}

}
