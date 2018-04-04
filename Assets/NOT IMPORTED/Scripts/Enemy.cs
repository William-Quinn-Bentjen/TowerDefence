using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {
    public float health = 100;
    [Range(0, 1)]
    public float DamageMitigation;
    public float ApplyDamage(float amount)
    {
        amount *= (1 - DamageMitigation);
        health = health - amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        return amount;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
