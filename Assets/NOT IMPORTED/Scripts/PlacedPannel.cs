using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacedPannel : MonoBehaviour {
    public Weapon Selected;
    public Text Stats;
    public Dropdown TargetingMode;
    public void UpdatePlacedPannel(Weapon selected = null)
    {
        if (selected == null)
        {
            selected = Selected;
            Stats.text = "Stats\n\nDamage: " + selected.explosionCenterDamage + "\nRange: " + selected.Range + "\nExplosion Radius: " + selected.explosionRadius + "\nRPM: " + selected.RPM;
        }
        else
        {
            Selected = selected;
            Stats.text = "Stats\n\nDamage: " + selected.explosionCenterDamage.ToString("n2") + "\nRange: " + selected.Range.ToString("n2") + "\nExplosion Radius: " + selected.explosionRadius.ToString("n2") + "\nRPM: " + selected.RPM.ToString("n2"); 
            gameObject.SetActive(true);
        }
        switch (selected.Mode)
        {
            case Weapon.TargetingMode.ClosestToWeapon:
                TargetingMode.value = 0;
                break;
            case Weapon.TargetingMode.FurthestToWeapon:
                TargetingMode.value = 1;
                break;
            case Weapon.TargetingMode.LeastHP:
                TargetingMode.value = 2;
                break;
            case Weapon.TargetingMode.MostHP:
                TargetingMode.value = 3;
                break;
        }

    }
    public enum UpgradeType
    {
        Damage,
        Range,
        ExplosionRadius,
        RPM
    }
    public void Upgrade(UpgradeType type)
    {
        switch(type)
        {
            case UpgradeType.Damage:
                Selected.explosionCenterDamage *= 1.1f;
                break;
            case UpgradeType.Range:
                Selected.Range *= 1.1f;
                break;
            case UpgradeType.ExplosionRadius:
                Selected.explosionRadius *= 1.1f;
                break;
            case UpgradeType.RPM:
                Selected.RPM *= 1.1f;
                break;
        }
        UpdatePlacedPannel();  
    }
    public void Upgrade(string type)
    {
        switch(type)
        {
            case "Damage":
                Upgrade(UpgradeType.Damage);
                break;
            case "Range":
                Upgrade(UpgradeType.Range);
                break;
            case "Explosion Radius":
                Upgrade(UpgradeType.ExplosionRadius);
                break;
            case "RPM":
                Upgrade(UpgradeType.RPM);
                break;
        }
    }
    public void ChangeTargetingMode()
    {
        switch(TargetingMode.value)
        {
            case 0:
                Selected.Mode = Weapon.TargetingMode.ClosestToWeapon;
                break;
            case 1:
                Selected.Mode = Weapon.TargetingMode.FurthestToWeapon;
                break;
            case 2:
                Selected.Mode = Weapon.TargetingMode.LeastHP;
                break;
            case 3:
                Selected.Mode = Weapon.TargetingMode.MostHP;
                break;
        }
    }
    public void RemoveWeapon()
    {
        Selected.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePlacedPannel();
    }
}
