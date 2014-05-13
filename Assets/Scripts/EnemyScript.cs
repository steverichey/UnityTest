using UnityEngine;
using System.Collections;

// Enemy behavior
public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapons;

	void Awake()
    {
	    // Retrieve the weapon once
        weapons = GetComponentsInChildren<WeaponScript>();
	}
	
	void Update ()
    {
        foreach (WeaponScript weapon in weapons)
        {
            // Auto fire
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
	}
}