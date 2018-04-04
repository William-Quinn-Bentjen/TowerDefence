using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour, IDamageable {
    private float _HP = 100;
    public float HP
    {
        get
        {
            return _HP;
        }
        set
        {
            _HP = value;
            if (value <= 0)
            {
                GameManager.PlayerDied();
            }
        }
    }
    public float ApplyDamage(float amount)
    {
        HP -= amount;
        return amount;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //hurt player
        }
    }
}
