using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject Base;
    public GameObject Gun;
    public GameObject LookingAt;
    public GameObject explosion;
    public float explosionRadius;
    public float Range = 20;
    public float RPM = 30;
    private float RPMTimer = 0;
    public TargetingMode Mode = TargetingMode.ClosestToWeapon;
    public enum TargetingMode
    {
        ClosestToWeapon,
        FurthestToWeapon,
        LeastHP,
        MostHP
    }
    void FixedUpdate()
    {
        RPMTimer -= Time.deltaTime;
        if (RPMTimer <= 0)
        {
            RPMTimer = 1 / (RPM / 60);
            GameObject target = Target();
            if (target != null)
            {
                Fire(target);
            }
        }
    }
    // Update is called once per frame
    void Update () {
        LookAt(Target());
	}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    GameObject Target()
    {
        List<GameObject> targets = new List<GameObject>();
        foreach (Collider col in Physics.OverlapSphere(Gun.transform.position, Range))
        {
            if (col.tag == "Enemy")
            {
                targets.Add(col.gameObject);
            }
        }
        return TargetingLogic(targets);
    }
    public GameObject TargetingLogic(List<GameObject> targets)
    {
        if (targets.Count == 1)
        {
            return targets[0];
        }
        else if (targets.Count > 1)
        {
            if (Mode == TargetingMode.ClosestToWeapon || Mode == TargetingMode.FurthestToWeapon)
            {
                float minDist = Vector3.Distance(transform.position, targets[0].transform.position);
                int minIdx = 0;
                float maxDist = minDist;
                int maxIdx = 0;
                for (int i = 1; i < targets.Count; i++)
                {
                    float distance = Vector3.Distance(transform.position, targets[0].transform.position);
                    if (distance <= minDist)
                    {
                        minDist = distance;
                        minIdx = i;
                    }
                    if (distance >= maxDist)
                    {
                        maxDist = distance;
                        maxIdx = i;
                    }
                }
                if (Mode == TargetingMode.ClosestToWeapon)
                {
                    return targets[minIdx];
                }
                else
                {
                    return targets[maxIdx];
                }
            }
            else
            {
                int minIdx = 0;
                float minHP = targets[0].GetComponent<Enemy>().health;
                int maxIdx = 0;
                float maxHP = minHP;
                for (int i = 1; i < targets.Count; i++)
                {
                    float hp = targets[i].GetComponent<Enemy>().health;
                    if (hp <= minHP)
                    {
                        minIdx = i;
                        minHP = hp;
                    }
                    if (hp >= maxHP)
                    {
                        maxIdx = i;
                        minHP = hp;
                    }
                    if (Mode == TargetingMode.LeastHP)
                    {
                        return targets[minIdx];
                    }
                    else
                    {
                        return targets[maxIdx];
                    }
                }
            }
        }
        return null;
    }
    void LookAt(GameObject target = null)
    {
        if (target != null)
        {
            Gun.transform.LookAt(target.transform.position);
            Vector3 Angles = Gun.transform.eulerAngles;
            Base.transform.SetPositionAndRotation(Base.transform.position, Quaternion.Euler(new Vector3(0, Angles.y, 0)));
            Gun.transform.SetPositionAndRotation(Base.transform.position, Quaternion.Euler(new Vector3(Angles.x, Angles.y, 0)));
        }
    }
    void Fire(GameObject target)
    {
        LookAt(target);
        Instantiate(explosion, target.transform.position, transform.rotation);
        foreach (Collider col in Physics.OverlapSphere(target.transform.position, explosionRadius))
        {
            if (col.tag == "Enemy")
            {
                //damage
            }
        }
        //spawn explosion at enemy and do a kill / maime within a radius
    }
}
