using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostChildAnimation : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialReferences(); 
    }
    void SetInitialReferences()
    {
        anim = gameObject.GetComponent<Animator>();
        if(anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }
    public void LostChildRunAnimation(bool isRunning)
    {
        anim.SetBool("isRunning", isRunning);
    }
    public void LostChildAttackAnimation(bool isAttacking)
    {
        anim.SetBool("isAttacking", isAttacking);
    }
    public void LostChildPlayerLostIdle(bool playerDeath)
    {
        anim.SetBool("playerDeath",playerDeath);
    }
    public void LostChildDamageAnimation(bool isDamaged, int damagePattern)
    {
        anim.SetBool("isDamaged", isDamaged);
        anim.SetInteger("damagePattern", damagePattern);
    }
}