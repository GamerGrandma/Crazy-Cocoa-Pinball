using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void Awake()
    {

    }
    
    public void StartButton()
    {
       SceneManager.LoadScene(1);
    }
}
