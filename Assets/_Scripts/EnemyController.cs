/* 
* The Source File Name: COMP305_Midterm_JihoYoo_300813612
* Author's name: Jiho Yoo
* March 02, 2016 
*/
using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
    private GameController _GameController; 
    private AudioSource[] _audioSources;
    private AudioSource _pointSound;

	// Use this for initialization
	void Start () {
		this._Reset ();

        // Get Reference to GameController
	    this._GetGameController();

        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._pointSound = this._audioSources[1];

	}
	
	
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();

            this._GameController.ScoreValue += 10;
            this._pointSound.Play();
		}
	}


	// resets the gameObject
	void _Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
    }

    
    private void _GetGameController()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if ( gameControllerObject != null )
        {
            this._GameController = gameControllerObject.GetComponent<GameController>();
        }
        if ( gameControllerObject == null )
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    
    void OnTriggerEnter2D ( Collider2D otherGameObject )
    {
        // Reset position on player collision
        if ( otherGameObject.tag == "Player" )
        {
            this._Reset();
        }
    }
}
