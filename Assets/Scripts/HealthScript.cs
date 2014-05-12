using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    // Total hitpoints
    public int hp = 1;

    // Friendly or not?
    public bool isEnemy = true;

    public void Damage(int damageAmount)
    {
        hp -= damageAmount;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Did we get shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
            // Friendly fire isn't!
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Always target gameObject, otherwise you'll remove the script
            }
        }
    }
}
