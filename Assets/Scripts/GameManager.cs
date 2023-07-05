using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameObject gameOverText;
	public TMP_Text scoreText;
	public TMP_Text highScoreText;
	public bool gameOver = false;
	private float score = 0f;
	private float highScore;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		// Set the initial value of highScore to the value stored in PlayerPrefs
		highScore = PlayerPrefs.GetFloat("HighScore", 0f);
	}

	void Update()
	{
		if (!gameOver)
		{
			score += Time.deltaTime;
			scoreText.text = "Score: " + Mathf.Round(score).ToString();
		}

		if (gameOver && Input.GetMouseButtonDown(0))
		{
			Invoke("RestartGame", 1f);
		}
	}

	public void GameOver()
	{
		gameOver = true;
		gameOverText.SetActive(true);

		if (score > highScore)
		{
			PlayerPrefs.SetFloat("HighScore", score);

			// Check if it's a new high score
			if (score > highScore)
			{
				highScore = score;
				highScoreText.text = "New High Score! " + Mathf.Round(highScore).ToString();
				highScoreText.color = Color.red;
			}
			else
			{
				highScoreText.text = "High Score: " + Mathf.Round(highScore).ToString();
				highScoreText.color = Color.white;
			}
		}
		else
		{
			highScoreText.text = "High Score: " + Mathf.Round(highScore).ToString();
			highScoreText.color = Color.white;
		}
	}

	void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
