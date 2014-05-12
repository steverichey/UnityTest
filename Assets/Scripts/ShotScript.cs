using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    // Damage inflicted
    public int damage = 1;

    // Should damage player or enemies
    public bool isEnemyShot = false;

	void Start ()
    {
        // Limit lifespan to prevent memory leaks
        Destroy(gameObject, 20); // 20 sec delay
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}