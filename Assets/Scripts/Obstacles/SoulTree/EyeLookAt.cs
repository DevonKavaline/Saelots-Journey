using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the eyeballs of the Soul Trees to look at a specified target.
/// </summary>

public class EyeLookAt : MonoBehaviour
{
    private GameObject target;
    private Transform lookTarget;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialReferences();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookTarget);
    }

    void SetInitialReferences()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        lookTarget = target.GetComponent<Transform>();
    }
}
