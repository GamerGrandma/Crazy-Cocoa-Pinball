using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public TextMeshProUGUI youWinText;
    public Button playAgainButton;
    public Button quitButton;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("you win");
            //activate you win text
            //activate play again button
            //activate quit button
            youWinText.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }
}
