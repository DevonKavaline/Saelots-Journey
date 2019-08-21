using UnityEngine;

/// <summary>
/// Carries the objects health, and if its health reaches 0, it gets destroyed.
/// 
/// </summary>

public class Health : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("Character's Health")]
    public int health;
    [Tooltip("Characters defensive capabilities")]
    public int armor;
    [Tooltip("Rate that character health regenerates")]
    public float regenerationRate;

    public bool canRegenerate;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            ObjectDeath();
        }
    }
    void ObjectDeath()
    {
        Destroy(gameObject);
    }
    void ObjectDamage(int damage)
    {
        if (gameObject.CompareTag("S_Enemy")) {
            health -= (damage - armor);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            int dmg;
            dmg = other.gameObject.GetComponent<WeaponDamage>().weaponDamage;
            ObjectDamage(dmg);
        }
    }
}
