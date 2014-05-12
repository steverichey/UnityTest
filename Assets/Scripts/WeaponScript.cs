using UnityEngine;
using System.Collections;

// Launch projectile. Pew pew!
public class WeaponScript : MonoBehaviour
{
    // Projectile prefab for shooting
    public Transform shotPrefab;

    // Cooldown time
    public float shootingRate = 0.25f;

    // Cooldown storage
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    // Shooting via another script
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // Define isEnemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it (?)
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

            if (move != null)
            {
                move.direction = this.transform.right; // Towards in 2D is to the right
            }
        }
    }

    // Is the weapon ready to create a new projectile?
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}