using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {
    [ReadOnly]
    public Weapon _SelectedWeapon;
    public PlacedPannel Placed;
    public PlacePannel Place;
    public RawImage Backdrop;
    public Weapon SelectedWeapon
    {
        get
        {
            return _SelectedWeapon;
        }
        set
        {
            if (value.gameObject.activeInHierarchy == false)
            {
                _SelectedWeapon = value;
                //open place pannel
                Backdrop.enabled = true;
                Place.gameObject.SetActive(true);
                Placed.gameObject.SetActive(false);
            }
            else
            {
                _SelectedWeapon = value;
                //open placed pannel
                Backdrop.enabled = true;
                Place.gameObject.SetActive(false);
                Placed.gameObject.SetActive(true);
            }
        }
    }
    public void SelectWeapon(Weapon weapon)
    {
        SelectedWeapon = weapon;
    }
    public void ClosePannels()
    {
        Place.gameObject.SetActive(false);
        Placed.gameObject.SetActive(false);
        Backdrop.enabled = false;
    }
}
