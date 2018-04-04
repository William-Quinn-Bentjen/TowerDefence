using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject Gun;
    public float Range = 20;
    public float RPM = 30;
    public TargetingMode Mode = TargetingMode.ClosestToWeapon;
    public enum TargetingMode
    {
        ClosestToWeapon,
        FurthestToWeapon,
        LeastHP,
        MostHP
    }
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    void Fire(GameObject target)
    {
        //spawn explosion at enemy and do a kill / maime within a radius
    }
}
