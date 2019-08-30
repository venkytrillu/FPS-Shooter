using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponData : MonoBehaviour
{
    public static WeaponData instance;
    public Text WeaponName;
    public Text WeaponRange;
    public Text BulletCycle;
    public Text WeaponDecription;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        SetWeaponData(WeaponManager.instance.current_weaponIndex);
    }

    public void GetWeaponData(WeaponHandler weaponHandler)
    {
        print(weaponHandler.name);
        WeaponName.text= weaponHandler.weaponName;
        WeaponRange.text = weaponHandler.weaponRange.ToString();
        BulletCycle.text = weaponHandler.bulletCycle;
        WeaponDecription.text = weaponHandler.description;
    }

    public void SetWeaponData(int weaponIndex)
    {
        print(weaponIndex);
        WeaponManager.instance.TurnOnSelectedWeapon(weaponIndex);
        GetWeaponData(WeaponManager.instance.GetCurrentSelectedWeapon());
    }

} // class
