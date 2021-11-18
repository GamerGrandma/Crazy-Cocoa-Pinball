using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    private Button button;
    public SpawnManager spawnManager;
    public int difficulty;

    void Start()
    {
        spawnManager = GameObject.Find("Spawner").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was clicked");
        spawnManager.StartGame(difficulty);
    }
}
