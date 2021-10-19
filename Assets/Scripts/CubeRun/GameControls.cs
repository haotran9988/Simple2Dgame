using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    public GameObject obstac;
    public static bool isGameOver;
    float m_TimeSpawn;
    public float timeSpawn;
    public static int score;
    public Text scoreText;
    public Text bestScoreText;
    public GameObject gameOverPanel;
    int scoreToNextLevels = 20;
   
    // Start is called before the first frame update
    void Start()
    {
        m_TimeSpawn = 0;
        score = 0;
        isGameOver = false;
        FindObjectOfType<AudioManager>().PlaySound("MainTheme2");
    }

    // Update is called once per frame
    void Update()
    {
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestScore").ToString();
        scoreText.text = "Score: " + score.ToString();
        m_TimeSpawn -= Time.deltaTime;
        if (m_TimeSpawn < 0)
        {
            SpawnObstacles();
            m_TimeSpawn = timeSpawn;
        }
        if (PlayerPrefs.GetInt("bestScore") <= score)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
            return;
        }
        if (score >= scoreToNextLevels)
        {
            Obstacles.moveSpeed += 1;
            scoreToNextLevels *= 2;
        }
    }
    void SpawnObstacles()
    {
        if (isGameOver)
        {
            return;
        }
        float randomY = Random.Range((float)-3.5, (float)-1.7);
        Vector3 newPos = new Vector3(12, randomY, 0);
        Instantiate(obstac, newPos, Quaternion.identity);
    }
    public void Replay()
    {
        SceneManager.LoadScene("CubeRun");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Jump()
    {
        PlayerMotor.isJump = true;
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
    }
}
