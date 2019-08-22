using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gives the player the ability to do a basic attack (makes an "attack collider" appear) 
/// </summary>

public class Stab : MonoBehaviour
{
    public GameObject assaultWeapon;
    public string stabButton;
    public float stabCoolDownTimer;
    public float stabCoolDownTimerMax = 1.0f;
    public float stabCost = 0.3f;

    public Image stabCoolDownUI;

    // Start is called before the first frame update
    void Start()
    {
        stabCoolDownTimer = stabCoolDownTimerMax;
        stabCoolDownUI.fillAmount = stabCoolDownTimer;
        assaultWeapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(stabButton) && stabCoolDownTimer >= stabCost)
        {
            StartCoroutine(Attack());
        }
        CheckCoolDown();
    }
    void CheckCoolDown()
    {
        if (stabCoolDownTimer <= stabCoolDownTimerMax)
        {
            stabCoolDownTimer += Time.deltaTime/2;
        }
        else
        {
            stabCoolDownTimer = stabCoolDownTimerMax;
        }
        stabCoolDownUI.fillAmount = stabCoolDownTimer;
    }
    IEnumerator Attack()
    {
        assaultWeapon.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        stabCoolDownTimer -= stabCost;
        assaultWeapon.SetActive(false);
    }
}
