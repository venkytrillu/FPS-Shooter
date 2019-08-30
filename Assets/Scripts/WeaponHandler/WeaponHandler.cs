using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static WeaponHandler instance;
    private AudioSource audioSource;
    public AudioClip shootSound, reloadSound;
    public WeaponAim weaponAim;
    public WeaponBulletType weaponBulletType;
    public WeaponFireType weaponFireType;
    public Animator anim;
    public GameObject mazzuleFLash;
    public string bulletCycle;
    public string description;
    public string weaponName;
    public float weaponRange;
    public float damege;
    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Shoot()
    {
        anim.SetTrigger(AnimationTags.ShootTrigger);
    }

    public void AsleRifleShoot(bool state)
    {
        anim.SetBool(AnimationTags.ShootTrigger,state);
    }
    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AimTrigger,canAim);
    }

    public void ReloadAnimation()
    {
        anim.SetTrigger(AnimationTags.ReloadTrigger);
    }

    public void MuzzleFlashOn()
    {
        mazzuleFLash.SetActive(true);
    }

    public void MuzzleFlashOff()
    {
        mazzuleFLash.SetActive(false);
    }

    public void ShootSound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = shootSound;
            audioSource.Play();
        }

    }
    public void StopSound()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    public void ReloadSound()
    {
        audioSource.clip = reloadSound;
        audioSource.Play();
    }




}//class











































