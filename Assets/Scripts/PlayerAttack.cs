using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    public WeaponManager weaponManager;
    public float fireRate = 15;
    public float nextTimeToFire;
    [SerializeField]
    private Animator zoomcameraAnmin;
    public Vector3 mainCameraForwardVector;
    public GameObject crossHair;
    GameObject enemy;
    RaycastHit hit;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    private void Update()
    {
        if( GameManager.instacne.gameState == GameState.play)
        {
            WeaponShoot();
            ZoomInAndZoomOut();
            ShowHealthBar();
            mainCameraForwardVector = Camera.main.transform.forward;
        }
    }

    void WeaponShoot()
    {
        if (weaponManager.GetCurrentSelectedWeapon().weaponFireType== WeaponFireType.Multiple)
        {
            
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                weaponManager.GetCurrentSelectedWeapon().mazzuleFLash.SetActive(true);
                nextTimeToFire = Time.time + 1 / fireRate;
                weaponManager.GetCurrentSelectedWeapon().AsleRifleShoot(true);
                weaponManager.GetCurrentSelectedWeapon().ShootSound();
                if(weaponManager.GetCurrentSelectedWeapon().mazzuleFLash.GetComponent<ParticleSystem>().isStopped)
                weaponManager.GetCurrentSelectedWeapon().mazzuleFLash.SetActive(false);
                BulleSoot();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                weaponManager.GetCurrentSelectedWeapon().AsleRifleShoot(false);
                weaponManager.GetCurrentSelectedWeapon().StopSound();
                weaponManager.GetCurrentSelectedWeapon().mazzuleFLash.SetActive(false);
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                weaponManager.GetCurrentSelectedWeapon().Shoot();
                BulleSoot();

            }
        }
        
    }//weaponshoot

    void ZoomInAndZoomOut()
    {
        if(weaponManager.GetCurrentSelectedWeapon().weaponAim==WeaponAim.Aim)
        {
            if(Input.GetMouseButtonDown(1))
            {
                zoomcameraAnmin.Play(AnimationTags.ZoomIn_Anim);
                crossHair.SetActive(false);
            }
            if(Input.GetMouseButtonUp(1))
            {
                zoomcameraAnmin.Play(AnimationTags.ZoomOut_Anim);
                crossHair.SetActive(true);
            }
        }
    }//zoominOut

    void BulleSoot()
    {

        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, weaponManager.GetCurrentSelectedWeapon().weaponRange))
        {
           
            if(hit.transform.tag==Tags.Enemy_Tag)
            {
                hit.transform.gameObject.GetComponent<HealthScript>().ApplayDamage(weaponManager.GetCurrentSelectedWeapon().damege);
            }      
            //print(hit.transform.gameObject.name);
        }
    }


    public void ShowHealthBar()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponManager.GetCurrentSelectedWeapon().weaponRange))
        {
           // print(hit.transform.gameObject.name);
            if (hit.transform.tag == Tags.Enemy_Tag)
            {
                enemy = hit.transform.gameObject.transform.GetChild(0).gameObject;
                enemy.SetActive(true);
            }
            else
            {
                SetEnemyNull();
            }
        }
        else
        {
            SetEnemyNull();
        }
        
    }

    void SetEnemyNull()
    {
        if (enemy)
        {
            enemy.SetActive(false);
            enemy = null;
        }
    }

}//class















































