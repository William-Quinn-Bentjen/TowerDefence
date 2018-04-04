using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Despawner : MonoBehaviour, IDamageable {
    public Text HPText;
    private float _HP = 100;
    void Start()
    {
        HPText.text = HP + @"/100";
    }
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
            HPText.text = value + @"/100";
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
            ApplyDamage(1);
            //hurt player
        }
    }
}
