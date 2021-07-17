using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    public GameObject player;
    public GameObject objCamera;
    public GameObject[] obj;
    public GameObject activeObject;
    public float rotationSpeed = 500;
    public bool objActive;
    public GameObject controlsUI;
    public Text controlsText;
    public GameObject hoverText;
    public CenterRay rayScript;
    public List<string> hoverObjects;
    public AudioSource playerAudio;
    public AudioClip itemSound;
    public AudioClip plastic;

    private void Start()
    {
        hoverObjects = new List<string>();
        hoverObjects.Add("strawcup");
        hoverObjects.Add("spoonBox");
        hoverObjects.Add("Cups");
        hoverObjects.Add("Tops");
        hoverObjects.Add("clamStack");
        hoverObjects.Add("bag");
    }
    void Update()
    {
        //Activate rotation
        if (objActive)
        {
            activeObject.transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), 0, Space.World);
        }
        //Deactivate
        if (objActive & Input.GetKeyDown(KeyCode.Escape))
        {
            activeObject.SetActive(false);
            objActive = false;
            player.SetActive(true);
            objCamera.SetActive(false);
            controlsText.text = "E - Report";
        }

        //Center raycast for web (look at objects)
        if (hoverObjects.Contains(rayScript.obj.name))
        {
            hoverText.SetActive(true);
        } else
        {
            hoverText.SetActive(false);
        }

        if (hoverObjects.Contains(rayScript.obj.name) & Input.GetMouseButtonDown(0))
        {
            //Play audio
            if (rayScript.obj.name == "bag" & !playerAudio.isPlaying)
            {
                playerAudio.PlayOneShot(plastic);
            } else
            {
                if (!playerAudio.isPlaying)
                {
                    playerAudio.PlayOneShot(itemSound);
                }
            }

            //Specifying objects
            for (int i = 0; i < hoverObjects.Count; i++)
            {
                if (rayScript.obj.name == hoverObjects[i])
                {
                    activeObject = obj[i];
                }
            }

            activeObject.SetActive(true);
            objActive = true;
            player.SetActive(false);
            objCamera.SetActive(true);
            controlsText.text = "Esc - Exit\nMouse - Rotate";
        }
    }

    /* Desktop Compatible Only
    private void OnMouseDown()
    {
        objActive = true;
        player.SetActive(false);
        objCamera.SetActive(true);
    }

    private void OnMouseEnter()
    {
        hoverText.SetActive(true);
    }
    private void OnMouseExit()
    {
        hoverText.SetActive(false);
    } */
}
