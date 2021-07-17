using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public bool permissionGranted;
    public GameObject textUI;
    public GameObject entryPoint;
    public Text bottomText;
    public CenterRay rayScript;

    private void Update()
    {
        if (rayScript.obj.name == "Person")
        {
            //Write text when looking at store manager
            if (!permissionGranted)
            {
                textUI.GetComponent<Text>().text = "Ask to inspect store.";
                textUI.SetActive(true);
            }

            //Grant permission to inspect objects
            if (Input.GetMouseButtonDown(0))
            {
                entryPoint.SetActive(false);
                permissionGranted = true;
                textUI.GetComponent<Text>().color = Color.white;
                textUI.GetComponent<Text>().text = "Okay? Yes. Why not.";
                StartCoroutine(TextTimer());
            }
        }
        else
        {
            textUI.SetActive(false);
        }
    }
    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(2);
        textUI.SetActive(false);
    }
    
    /* Desktop Compatible Only
    private void OnMouseOver()
    {
        //Write text when looking at manager
        if (!permissionGranted)
        {
            textUI.GetComponent<Text>().text = "Ask to inspect store.";
            textUI.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        //Remove text when not looking at manager
        if (!permissionGranted)
        {
            textUI.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //Grant permission to inspect objects
        entryPoint.SetActive(false);
        permissionGranted = true;
        textUI.GetComponent<Text>().color = Color.white;
        textUI.GetComponent<Text>().text = "Okay? Yes. Why not.";
        StartCoroutine(TextTimer());
    } */
}
