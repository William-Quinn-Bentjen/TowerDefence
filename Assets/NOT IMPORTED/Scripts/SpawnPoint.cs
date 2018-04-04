using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public Transform SpawnLocation;
    public Transform Destination;
    public float MitigationModifier;
    public GameObject Enemy;
    public void Spawn(GameObject enemy = null)
    {
        if (enemy == null)
        {
            enemy = Enemy;
        }
        if (enemy.tag == "Enemy Squad")
        {
            foreach (Transform child in enemy.transform)
            {
                child.GetComponent<WalkTo>().destination = Destination;
            }
        }
        else
        {
            enemy.GetComponent<WalkTo>().destination = Destination;
        }
        GameObject spawned = Instantiate(enemy, SpawnLocation.position, SpawnLocation.rotation, SpawnLocation);
        if (spawned.tag == "Enemy Squad")
        {
            foreach (Transform child in spawned.transform)
            {
                child.SetParent(SpawnLocation);
                child.GetComponent<Enemy>().DamageMitigation = MitigationModifier;
            }
            Destroy(spawned);
        }
        else
        {
            spawned.GetComponent<Enemy>().DamageMitigation = MitigationModifier;
        }
        //if(spawned.tag == "Enemy Squad")
        //{
        //    foreach (Transform child in spawned.transform)
        //    {
        //        child.GetComponent<WalkTo>().destination = Destination;
        //    }
        //}
        //Instantiate(enemy, SpawnLocation, true).GetComponent<WalkTo>().destination = Destination;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Spawn();
	}
}
