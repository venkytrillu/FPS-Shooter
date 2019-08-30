using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    [SerializeField]
    private WeaponHandler[] weapons;
    public int current_weaponIndex = 0;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        weapons[current_weaponIndex].gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);

        }

    }//update

  public void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (weaponIndex == current_weaponIndex)
            return;
           
            weapons[current_weaponIndex].gameObject.SetActive(false);
            weapons[weaponIndex].gameObject.SetActive(true);
            current_weaponIndex = weaponIndex;
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return weapons[current_weaponIndex];
    }


}//class







































































































