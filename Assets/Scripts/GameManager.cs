using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {

    public GameObject welcomeCanvas;
    public GameObject hudCanvas;
    public GameObject endCanvas;
    public Text scoreText;
    public Text endText;

    public GameObject nextLevelButton;
    public GameObject playAgainButton;

    private PCController networkController;

    public int levelNo;
    public bool isLastLevel;
    public string localip;
    private int score;
    private int num;

	void Start () {
        //num = GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().numPlayers;
        //Debug.Log(GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().IsClientConnected());
        //Debug.Log(GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().numPlayers); 

        if(levelNo == 0)
        {
            if (!GameObject.FindGameObjectWithTag("Network").GetComponent<MyNetworkManager>().IsClientConnected())
            {
                hudCanvas.SetActive(false);
                endCanvas.SetActive(false);
                welcomeCanvas.SetActive(true);
                Time.timeScale = 0;
                
            }
            else
            {
                hudCanvas.SetActive(true);
                endCanvas.SetActive(false);
                welcomeCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        else
        {
            endCanvas.SetActive(false);
            hudCanvas.SetActive(true);
            Time.timeScale = 1f;
            
        }
        
        

	}

    void Update() {
       
    }
	
	public void StartGame() {
        Time.timeScale = 1f;
        welcomeCanvas.SetActive(false);
        hudCanvas.SetActive(true);
    }

    public void Win() {
        Time.timeScale = 0;
        hudCanvas.SetActive(false);
        endCanvas.SetActive(true);
        playAgainButton.SetActive(true);
        if (!isLastLevel) {
            nextLevelButton.SetActive(true);
            endText.text = "Congratulations!\nYou won!";
        } else {
            nextLevelButton.SetActive(false);
            endText.text = "Congratulations!\nYou've beat all levels!";
        }
    }

    public void Lose() {
        Time.timeScale = 0;
        hudCanvas.SetActive(false);
        endCanvas.SetActive(true);
        nextLevelButton.SetActive(false);
        playAgainButton.SetActive(true);
        endText.text = "Oh! You lost!";
    }

    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
        UpdateScoreText();
    }

    private void SetScore(int score) {
        this.score = score;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }

    public void ReloadLevel() {
        networkController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PCController>();
        networkController.ReloadLevel();
    }

    public void LoadNextScene() {
        networkController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PCController>();
        networkController.LoadNextScene();
    }

}
