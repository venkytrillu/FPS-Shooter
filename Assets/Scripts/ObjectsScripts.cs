using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectsScripts : MonoBehaviour
{
    public Slider slider;
    public GameObject dieEffect;
    public float destorytime;
    private Rigidbody rb;
    bool isHit;
    float waitTodestory;
    private void Start()
    {
        waitTodestory = 2;
        rb = GetComponent<Rigidbody>();
        
    }

    private void LateUpdate()
    {
        waitTodestory -= Time.deltaTime;
        if (!isHit && waitTodestory<=0)
        {
            SpawnObjects.instance.currentObjects--;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag==Tags.Ground)
        {
            Destroy(rb);
            isHit = true;
        }
    }

    public void SetHealthBarValue(float health)
    {
        slider.value = health;
    }

   public void DieEffect()
    {
        GameObject effect=  Instantiate(dieEffect, transform.position, Quaternion.identity);
        effect.transform.position = transform.localPosition;
        effect.transform.rotation = transform.localRotation;
        effect.GetComponent<ParticleSystem>().startColor = transform.GetComponent<MeshRenderer>().sharedMaterial.color;
        Destroy(effect, destorytime);
        Destroy(gameObject, destorytime);
    }

} // class




























































