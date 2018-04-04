using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacePannel : MonoBehaviour {
    public Button Place;
    public Button Cancel;
    public Weapon DefaultWeapon;
    public WeaponSelector Selector;
  
    public void PlaceWeapon()
    {
        if(Selector.SelectedWeapon.gameObject.activeInHierarchy == false)
        {
            Selector.SelectedWeapon.RPM = DefaultWeapon.RPM;
            Selector.SelectedWeapon.explosionCenterDamage = DefaultWeapon.explosionCenterDamage;
            Selector.SelectedWeapon.explosionRadius = DefaultWeapon.explosionRadius;
            Selector.SelectedWeapon.Range = DefaultWeapon.Range;
            Selector.SelectedWeapon.Mode = DefaultWeapon.Mode;
            Selector.SelectedWeapon.gameObject.SetActive(true);
            Selector.ClosePannels();
        }
    }
    //I THINK I USED THIS SOMEWHERE AND AM AFRAID I MAY BREAK SOMETHING IF I REMOVE IT (11:51 am wednesday)
    void CancelPlacement()
    {
        Selector.ClosePannels();
    }

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
