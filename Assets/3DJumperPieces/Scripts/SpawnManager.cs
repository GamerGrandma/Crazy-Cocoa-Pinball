using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject[] floatingObstaclesA;
    public GameObject[] floatingObstaclesB;
    public GameObject[] bonusObject;
    public GameObject[] bonusObjectB;
    public GameObject titleScreen;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI points;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private float startDelay = 2;
    private float spawnInterval = 2.5f;
    public int numOfLives = 3;
    public bool lifeLost = false;
    public int totalPoints = 0;
    public float minSpeed = 4f;
    public float maxSpeed = 4f;
    public float speed = 1f;
    private float leftBound = 22f;
    private float rightBound = -22f;
    public ObjectPool floaterPool;
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        //floater = ObjectPool.SharedInstance.GetPooledObject();
    }

    void Update()
    {
        AddPlayer();
        //SetToInactiveState();
    }
    //each spawn row moves opposite direction
    //also each spawn row sometimes has point or life that spawns with object
    void SpawnRowOne()
    {
        int canAddBonus = Random.Range(0, 2);
        Vector3 spawnPos1 = new Vector3(20, 0, 4);
        Vector3 spawnBonus1 = new Vector3(20, 1, 4);
        int floaterIndex = Random.Range(0, floatingObstaclesA.Length);
        //Instantiate(floatingObstaclesA[floaterIndex], spawnPos1, floatingObstaclesA[floaterIndex].transform.rotation);
        floaterPool.SpawnObject(spawnPos1);
        /*if (floater != null)
        {
            floater.SetActive(true);
            floater.transform.position = spawnPos1;
            floater.transform.rotation = floater.transform.rotation;
            floater.SetActive(true);
            
        }*/
        if (canAddBonus == 1)
        {
            ChooseRandomBonus(spawnBonus1);
        }
    }
    void SpawnRowTwo()
    {
        Vector3 spawnPos2 = new Vector3(-20, 0, 2);
        Vector3 spawnBonus2 = new Vector3(-20, 1, 2);
        int floaterIndex = Random.Range(0, floatingObstaclesB.Length);
        Instantiate(floatingObstaclesB[floaterIndex], spawnPos2, floatingObstaclesB[floaterIndex].transform.rotation);
        int canAddBonus = Random.Range(0, 2);
        if (canAddBonus == 1)
        {
            ChooseRandomBonusRight(spawnBonus2);
        }
    }
    void SpawnRowThree()
    {
        Vector3 spawnPos3 = new Vector3(20, 0, 0);
        Vector3 spawnBonus3 = new Vector3(20, 1, 0);
        int floaterIndex = Random.Range(0, floatingObstaclesA.Length);
        Instantiate(floatingObstaclesA[floaterIndex], spawnPos3, floatingObstaclesA[floaterIndex].transform.rotation);
        int canAddBonus = Random.Range(0, 2);
        if (canAddBonus == 1)
        {
            ChooseRandomBonus(spawnBonus3);
        }
    }
    void SpawnRowFour()
    {
        Vector3 spawnPos4 = new Vector3(-20, 0, -2);
        Vector3 spawnBonus4 = new Vector3(-20, 1, -2);
        int floaterIndex = Random.Range(0, floatingObstaclesB.Length);
        Instantiate(floatingObstaclesB[floaterIndex], spawnPos4, floatingObstaclesB[floaterIndex].transform.rotation);
        int canAddBonus = Random.Range(0, 2);
        if (canAddBonus == 1)
        {
            ChooseRandomBonusRight(spawnBonus4);
        }
    }
    void SpawnRowFive()
    {
        Vector3 spawnPos5 = new Vector3(20, 0,-4);
        Vector3 spawnBonus5 = new Vector3(20, 1,-4);
        int floaterIndex = Random.Range(0, floatingObstaclesA.Length);
        Instantiate(floatingObstaclesA[floaterIndex], spawnPos5, floatingObstaclesA[floaterIndex].transform.rotation);
        int canAddBonus = Random.Range(0, 2);
        if (canAddBonus == 1)
        {
            ChooseRandomBonus(spawnBonus5);
        }
    }
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
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Bumper"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("you win");
            }
        }
    }
    public void LosePlayerLife(int livesToChange)
    {
        numOfLives -= livesToChange;
        lives.text = "Lives: " + numOfLives;
        lifeLost = true;
    }
    public void AddSomePoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        points.text = "Points: " + totalPoints;
    }
    public void StartGame(int difficulty)
    {
        speed *= difficulty;
        lifeLost = true;
        InvokeRepeating("SpawnRowOne", startDelay, spawnInterval);
        InvokeRepeating("SpawnRowTwo", startDelay, spawnInterval);
        InvokeRepeating("SpawnRowThree", startDelay, spawnInterval);
        InvokeRepeating("SpawnRowFour", startDelay, spawnInterval);
        InvokeRepeating("SpawnRowFive", startDelay, spawnInterval);
        LosePlayerLife(0);
        AddSomePoints(totalPoints);
        titleScreen.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChooseRandomBonus(Vector3 spawnHere)
    {
        int bonusIndex = Random.Range(0, bonusObject.Length);
        Instantiate(bonusObject[bonusIndex], spawnHere, bonusObject[bonusIndex].transform.rotation);
    }
    public void ChooseRandomBonusRight(Vector3 spawnHere)
    {
        int bonusIndex = Random.Range(0, bonusObject.Length);
        Instantiate(bonusObjectB[bonusIndex], spawnHere, bonusObjectB[bonusIndex].transform.rotation);
    }
    /*public void SetToInactiveState()
    {
        if (transform.position.x > 22f)
        {
            floater.SetActive(false);
        }
        else if (transform.position.x < -22f)
        {
            floater.SetActive(false);
        }
    }*/
}
