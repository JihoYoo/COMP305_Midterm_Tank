/* 
* The Source File Name: COMP305_Midterm_JihoYoo_300813612
* Author's name: Jiho Yoo
* March 02, 2016 
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    public PlayerController Player;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public Button RestartButton;
    public Text ScoreLabel;
    public Text livesLabel;

    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;
	
	// Use this for initialization
	void Start () {
		this._GenerateTanks ();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	// generate Clouds
	private void _GenerateTanks() {
        this._scoreValue = 0;
        this._livesValue = 5;
        this.GameOverLabel.gameObject.SetActive(false);
        this.HighScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
		
        for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}

    private void _endGame()
    {
        this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this.GameOverLabel.gameObject.SetActive(true);
        this.HighScoreLabel.gameObject.SetActive(true);  
        this.Player.gameObject.SetActive(false);
        this.livesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        //this._gameOverSound.Play();
        this.RestartButton.gameObject.SetActive(true);
    }

    
    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    //Public Lives value
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.livesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    // PUBLIC METHODS

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
