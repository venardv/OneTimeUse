using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite winImg;
    public Sprite loseImg;
    public Sprite firedImg;
    public Image endScreen;
    public GameObject paper;
    public GameObject restartScene;
    public FirstPersonLook lookScript;
    public FirstPersonMovement moveScript;
    public AudioSource playerAudio;
    public AudioClip paperSound;
    public int inStorePlastic;
    public int earthHealth = 0;
    public bool gameOver;
    public bool fired;

    private void Start()
    {
        inStorePlastic = 3;
    }
    void Update()
    {
        //Toggle report
        if (Input.GetKeyDown(KeyCode.E) & !gameOver)
        {
            if (!playerAudio.isPlaying)
            {
                playerAudio.PlayOneShot(paperSound);
            }
            StartCoroutine(SwitchModeTimer());
        }

        //Overlay image accordingly on game finish
        if (gameOver)
        {
            lookScript.enabled = false;
            moveScript.enabled = false;
            paper.SetActive(false);

            if (earthHealth > 0)
            {
                endScreen.sprite = winImg;
            }
            if (earthHealth < 0)
            {
                endScreen.sprite = loseImg;
                restartScene.SetActive(true);
            }
            if (fired)
            {
                endScreen.sprite = firedImg;
                restartScene.SetActive(true);
            }
            endScreen.enabled = true;
        }
    }

    IEnumerator SwitchModeTimer()
    {
        if (lookScript.enabled)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            paper.SetActive(true);
            lookScript.enabled = false;
            moveScript.enabled = false;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            paper.SetActive(false);
            lookScript.enabled = true;
            moveScript.enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
