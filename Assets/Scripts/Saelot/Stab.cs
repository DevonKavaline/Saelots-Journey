using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gives the player the ability to do a basic attack (makes an "attack collider" appear) 
/// </summary>

public class Stab : MonoBehaviour
{
    public GameObject assaultWeapon;
    public string stabButton;

    // Start is called before the first frame update
    void Start()
    {
        assaultWeapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(stabButton))
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        assaultWeapon.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        assaultWeapon.SetActive(false);
    }
}
