
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragonGameControls : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject enemy;
    private float spawnX;
    private float spawnY;
    public Transform playerTransform;
    private bool isAttack;
    public Text scoreText;
    public static int score = 0;
    public float timeSpawnEnemy;
    private int scoreToNextLevel = 20;
    public GameObject gameOverPanel;
    public static bool isGameOver;
    public static int health;
    public HealthBar healthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        InvokeRepeating("SpawnEnemy", 1f, timeSpawnEnemy);
        isAttack = false;
        isGameOver = false;
        healthBar.SetMaxHealth(health);
      
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            isGameOver = true;
        }
        scoreText.text = "Score: " + score.ToString();
        if (Input.GetKeyDown(KeyCode.A) || isAttack)
        {
            
            SpawnFireBall();
            isAttack = false;
        }
        if (score >= scoreToNextLevel)
        {
            timeSpawnEnemy -= 0.5f;
            Enemy.speed += 1;
            TreeMove.speed += 1;
            scoreToNextLevel *= 2;
            if (timeSpawnEnemy <= 1)
            {
                timeSpawnEnemy = 1;
            }
            if (Enemy.speed >= 6)
            {
                return;
            }
            
        }
        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
           
        }
    }
    void SpawnFireBall()
    {
        Instantiate(fireBall, playerTransform.position, Quaternion.identity);
    }
    void SpawnEnemy()
    {
        spawnX = Random.Range(10, 15);
        spawnY = Random.Range(-2, 4);
        Vector3 spawnEnemy = new Vector3(spawnX, spawnY, 0);
        Instantiate(enemy, spawnEnemy, Quaternion.identity);
    }
    public void JumpUp()
    {
        PlayerDragon.isJump = true;
    }
    public void Attacked()
    {
        isAttack = true;
    }
    public void Replay()
    {
        SceneManager.LoadScene("DragonFly");
        
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonSound");
    }
}
