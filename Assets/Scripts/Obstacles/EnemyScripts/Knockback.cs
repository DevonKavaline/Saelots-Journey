using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockBackForce = 111300f;
    float knockBackResist = 0f;
    public void CharacterKnockBack(Vector3 attackerdirection)
    {
        Vector3 direction = (gameObject.transform.position - attackerdirection).normalized;

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(direction * Mathf.Max((attacker.GetComponent<Attack>().knockBackForce - gameObject.GetComponent<Defend>().knockBackResist), 0));
        rb.AddForce(direction * Mathf.Max((knockBackForce - knockBackResist), 0));
        Debug.Log(direction);

    }
}
