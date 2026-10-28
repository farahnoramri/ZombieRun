using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
[SerializeField]
private ZombieBehavior _zombieBehavior;

[SerializeField]
private TextMeshProUGUI _scoreText;

[SerializeField]
private TextMeshProUGUI _highScoreText;

[SerializeField]
private TextMeshProUGUI _newScoreText;

[SerializeField]
private TextMeshProUGUI _brainText;

[SerializeField]
private GameObject _gameOverPanel;

private float playerScore = 0f;

public float currentSpeed = 5f;

[SerializeField]
private float speedIncrease = 0.2f;

[SerializeField]
private float maxSpeed = 12f;

private bool isGameOver = false;

private int highScore = 0;

private int brainCount = 0;

// NEW: Total brain collected across all runs
private int totalBrain = 0;

private void Start()
{
_gameOverPanel.SetActive(false);

highScore = PlayerPrefs.GetInt("HighScore", 0);

// NEW: Load previously saved total brain
totalBrain = PlayerPrefs.GetInt("TotalBrain", 0);

_newScoreText.gameObject.SetActive(false);

updateScoreText();
UpdateBrainText();
}

private void Update()
{
if (isGameOver)
{
return;
}

currentSpeed += speedIncrease * Time.deltaTime;
currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

playerScore += currentSpeed * Time.deltaTime;

updateScoreText();
}

private void updateScoreText()
{
int currentScore = Mathf.FloorToInt(playerScore);

_scoreText.text = "Score: " + currentScore;

_highScoreText.text = "High Score: " + highScore;
}

private void CheckNewHighScore()
{
int finalScore = Mathf.FloorToInt(playerScore);

if (finalScore > highScore)
{
highScore = finalScore;

PlayerPrefs.SetInt("HighScore", highScore);
PlayerPrefs.Save();

_newScoreText.text = "NEW HIGH SCORE! " + highScore;
_newScoreText.gameObject.SetActive(true);
}
}

public void CollectBrain()
{
if (isGameOver)
{
return;
}

// Existing: Current run brain count
brainCount++;

// NEW: Increase total brain
totalBrain++;

// NEW: Save total brain
PlayerPrefs.SetInt("TotalBrain", totalBrain);
PlayerPrefs.Save();

UpdateBrainText();
}

private void UpdateBrainText()
{
_brainText.text = "Brain: " + brainCount;
}

public void GameOver()
{
if (isGameOver)
{
return;
}

isGameOver = true;

CheckNewHighScore();
updateScoreText();

_gameOverPanel.SetActive(true);

Time.timeScale = 0.0f;
}

public void LoadMainMenu()
{
Time.timeScale = 1.0f;
SceneManager.LoadScene("MainMenuScene");
}

public void RestartGame()
{
Time.timeScale = 1.0f;
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}