/* 
* The Source File Name: COMP305_Midterm_JihoYoo_300813612
* Author's name: Jiho Yoo
* March 02, 2016 
*/
using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    //  PRIVATE INSTANCE VARIABLES
    private GameController _GameController;
    private int _minusLife = 1;
    private AudioSource[] _audioSources;
    private AudioSource _collision;


	// Use this for initialization
	void Start ()
	{
	    _GetGameController();
        this._audioSources = gameObject.GetComponents<AudioSource>(); 
        this._collision = this._audioSources[1];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this._GameController.LivesValue -= 1;
            this._collision.Play();
        }
    }

    private void _GetGameController ()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if ( gameControllerObject != null )
        {
            this._GameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {

        }
    }

    


}
