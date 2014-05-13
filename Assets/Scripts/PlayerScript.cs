using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    // The speed of the ship
    public Vector2 speed = new Vector2(50, 50);

    // Store the movement
    private Vector2 movement;

	void Update ()
    {
	    // Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Movement per direction
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        // Shootin' time
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();

            if (weapon != null)
            {
                // False, we're not an enemy, yo
                weapon.Attack(false);
            }
        }
	}

    // Physics updates should be done here
    void FixedUpdate()
    {
        // Move the game object
        rigidbody2D.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

        if (enemy != null)
        {
            // Kill the enemy!
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();

            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hp);
            }

            damagePlayer = true;
        }

        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();

            if (playerHealth != null)
            {
                playerHealth.Damage(1);
            }
        }
    }
}