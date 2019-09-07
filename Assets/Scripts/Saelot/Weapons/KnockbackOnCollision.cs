using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Knocksback enemies that the sword come into contact with.
/// </summary>
public class KnockbackOnCollision : MonoBehaviour
{
    public float knockBackStrength = 100.0f;
    private int dmg;

    private void Start()
    {
        dmg = GetComponent<WeaponDamage>().weaponDamage;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<LostChild>().Damage(transform.position, dmg, knockBackStrength);
        }
    }
}
