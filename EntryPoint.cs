using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    public GameObject textUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TextActivation());
        }
    }

    IEnumerator TextActivation()
    {
        textUI.SetActive(true);
        yield return new WaitForSeconds(2);
        textUI.SetActive(false);
    }
}
