using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject titleScreen;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI points;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button quitButton;
    private float startDelay = 2;
    private float spawnInterval = 2.5f;
    public int numOfLives = 3;
    public bool lifeLost = false;
    public int totalPoints = 0;
    [SerializeField]
    private float speed = 1f;
    //ENCAPSULATION of speed variable
    public float Speed { get; set; }
    public ObjectPool floaterPool;
    public ObjectPool bonusPool;

    private void Awake()
    {
        Speed = speed;
    }
    void Start()
    {
        
    }

    void Update()
    {
        AddPlayer();
    }
    //ABSTRACTION methods to spawn each row of floaters - called by start button.
    //each spawn row has a different spawn point.
    //each spawn row sometimes has point or life that spawns with object
    void SpawnRowOne()
    {
        int canAddBonus = Random.Range(0, 4);
        Vector3 spawnPos1 = new Vector3(24, 0, 4);
        Vector3 spawnBonus1 = new Vector3(24, 1, 4);
        floaterPool.SpawnObject(spawnPos1);
        if (canAddBonus == 1)
        {
            bonusPool.SpawnObject(spawnBonus1);
        }
    }
    void SpawnRowTwo()
    {
        Vector3 spawnPos2 = new Vector3(25, 0, 2);
        Vector3 spawnBonus2 = new Vector3(25, 1, 2);
        floaterPool.SpawnObject(spawnPos2);
        int canAddBonus = Random.Range(0, 4);
        if (canAddBonus == 1)
        {
            bonusPool.SpawnObject(spawnBonus2);
        }
    }
    void SpawnRowThree()
    {
        Vector3 spawnPos3 = new Vector3(23, 0, 0);
        Vector3 spawnBonus3 = new Vector3(23, 1, 0);
        floaterPool.SpawnObject(spawnPos3);
        int canAddBonus = Random.Range(0, 4);
        if (canAddBonus == 1)
        {
            bonusPool.SpawnObject(spawnBonus3);
        }
    }
    void SpawnRowFour()
    {
        Vector3 spawnPos4 = new Vector3(24, 0, -2);
        Vector3 spawnBonus4 = new Vector3(24, 1, -2);
        floaterPool.SpawnObject(spawnPos4);
        int canAddBonus = Random.Range(0, 4);
        if (canAddBonus == 1)
        {
            bonusPool.SpawnObject(spawnBonus4);
        }
    }
    void SpawnRowFive()
    {
        Vector3 spawnPos5 = new Vector3(26, 0,-4);
        Vector3 spawnBonus5 = new Vector3(26, 1,-4);
        floaterPool.SpawnObject(spawnPos5);
        int canAddBonus = Random.Range(0, 4);
        if (canAddBonus == 1)
        {
            bonusPool.SpawnObject(spawnBonus5);
        }
    }
    //ABSTRACTION method starting a player life
    public void AddPlayer()
    {
        if (numOfLives > 0)
        {
            if (lifeLost == true)
            {
                Vector3 playerSpawn = new Vector3(0, 1, -8);
                Instantiate(playerPrefab, playerSpawn, playerPrefab.transform.rotation);
                lifeLost = false;
            }
        }
        else if (numOfLives <= 0)
        {
            Debug.Log("game over");
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }
    //ABSTRACTION method changing number of player lives remaining and text for it.
    public void LosePlayerLife(int livesToChange)
    {
        numOfLives -= livesToChange;
        lives.text = "Lives: " + numOfLives;
        lifeLost = true;
    }
    //ABSTRACTION method for adding points to total and text.
    public void AddSomePoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        points.text = "Points: " + totalPoints;
    }
    //ABSTRACTION method for starting the game - implemented by button click.
    public void StartGame(int difficulty)
    {
        speed *= difficulty;
        lifeLost = true;
        InvokeRepeating("SpawnRowOne", startDelay/difficulty, spawnInterval);
        InvokeRepeating("SpawnRowTwo", startDelay/difficulty, spawnInterval);
        InvokeRepeating("SpawnRowThree", startDelay/difficulty, spawnInterval);
        InvokeRepeating("SpawnRowFour", startDelay/difficulty, spawnInterval);
        InvokeRepeating("SpawnRowFive", startDelay/difficulty, spawnInterval);
        LosePlayerLife(0);
        AddSomePoints(totalPoints);
        titleScreen.gameObject.SetActive(false);
    }
    //ABSTRACTION method for button to reload the game if over.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //ABSTRACTION method for button to quit the game.
    public void QuitGame()
    {
        Debug.Log("you quit");
        Application.Quit();
    }
}
