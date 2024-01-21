using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;
    private int score;
    public Text highScoreText;
    public Player player;
    public GameObject playButton;
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        //highScore = 0;

        highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";

        //UpdateHighScoreText();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);

        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        UpdateHighScore();
    }
}
