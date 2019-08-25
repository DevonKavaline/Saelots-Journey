using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lost Child Enemy AI script
/// </summary>
public class LostChild : MonoBehaviour
{
    //Bools related to animation
    private bool isRunning = false; //this should always be true unless the player has lost.
    private bool isAttacking = false; //this is true if the enemy can attack
    private bool playerDeath = false; //this is true if the player loses!
    private bool isDamaged = false; //this is true if the player sucessfully attacks the enemy!
    private int damagePattern; //this needs to either equal 1 or 2!

    private LostChildAnimation animController;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        SetInitialReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning != true && playerDeath == false)
        {
            isRunning = true;
            animController.LostChildRunAnimation(isRunning);
        }
    }

    void Attack()
    {
        /// This should be activated if the player is within range of the enemy
        /// the enemy then activates the attack animation with "isAttacking"
        /// during a certain frame of the attack a trigger will spawn in the attack area and immediately disappear again
        /// if the trigger was tripped then the player will recieve damage that will be calculated on the player's side
        /// once the attack is over the "isAttacking" bool is reset to false and the enemy can try to attack again.
        /// this should be a IEnumerator.
    }

    void Damage()
    {
        ///This should be activated if a trigger with the tag of "Weapon" collides with the enemy weapon
        ///the boolean for "isDamaged" should be tripped
        ///the int "damagePattern" should be a random number between "1" or "2", this determines which damage animation will play
        ///The enemy should have a force set on it that sends it slightly upward and backwards.
        ///after the enemy lands on the ground, the "isDamaged" bool should be reset to false
        ///this should also be an IEnumerator(?)
    }

    void PlayerLostIdle()
    {
        ///This should be activated on player death
        ///this will decrease the speed of the enemy until 0
        ///then the "playerDeath" boolean will be tripped
        ///everything else with the enemy will be disabled until the game is restarted.
    }
    void SetInitialReferences()
    {
        animController = GetComponent<LostChildAnimation>();
    }
}
