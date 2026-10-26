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
    private GameObject _gameOverPanel;
    private int playerScore = 0;
    private float scoreTimer = 0f;
    private bool isGameOver = false;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        updateScoreText();

    }


    private void Update()
    {
        if(isGameOver)
        {
            return;
        }

        scoreTimer += Time.deltaTime;

        if(scoreTimer >= 1f)
        {
            playerScore++;
            scoreTimer = 0f;
            updateScoreText();
        }
    }
    private void updateScoreText()
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void GameOver()
    {
        if(isGameOver)
        {
            return;
        }

        isGameOver = true;
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
