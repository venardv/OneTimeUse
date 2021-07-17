using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRay : MonoBehaviour
{
    public LayerMask mask;
    public GameObject obj;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {
            obj = hit.collider.gameObject;

            Debug.Log($"looking at {obj.name}", this);
        }
    }
}
