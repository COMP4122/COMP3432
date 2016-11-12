using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject welcomeCanvas;
    public GameObject hudCanvas;
    public GameObject endCanvas;

    public Text scoreText;
    public Text endText;

    public GameObject nextLevelButton;
    public GameObject playAgainButton;

    public int levelNo;
    public bool isLastLevel;

    private int score;

	void Start () {
        hudCanvas.SetActive(false);
        welcomeCanvas.SetActive(true);
        endCanvas.SetActive(false);
		Time.timeScale = 0;

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

    public void ReloadLevel() {
        SceneManager.LoadScene("Level" + levelNo);
    }

    public void LoadNextScene() {
        if (!isLastLevel) {
            int nextLevelNo = levelNo + 1;
            SceneManager.LoadScene("Level" + nextLevelNo);
        }
    }

    private void SetScore(int score) {
        this.score = score;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }
}
