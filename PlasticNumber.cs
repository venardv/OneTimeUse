using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlasticNumber : MonoBehaviour
{
    public int number;
    public Text numberUI;
    public GameManager gameManager;
    public AudioSource playerAudio;
    public AudioClip add;
    public AudioClip subtract;

    void Update()
    {
        numberUI.text = number.ToString();
    }

    //Add or subtract number from Form
    public void Add()
    {
        if (!playerAudio.isPlaying)
        {
            playerAudio.PlayOneShot(add);
        }
        number += 1;
    }

    public void Subtract()
    {
        if (!playerAudio.isPlaying)
        {
            playerAudio.PlayOneShot(subtract);
        }
        if (number > 0)
        {
            number -= 1;
        }
    }

    //Submit | end game | calculate score
    public void Submit()
    {
        if (number < gameManager.inStorePlastic)
        {
            gameManager.earthHealth = number - gameManager.inStorePlastic;
        }
        if (number > gameManager.inStorePlastic)
        {
            gameManager.fired = true;
        }
        if (number == gameManager.inStorePlastic) {
            gameManager.earthHealth = 1;
        }
        gameManager.gameOver = true;
    }
}
