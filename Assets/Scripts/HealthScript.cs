using UnityEngine;

public class HealthScript : MonoBehaviour
{
   // public EnemyController enemyController;
   // public EnemyScript enemyAnim;
    public bool isDead;
    public float Health = 100f;

    private void Start()
    {
        HealthProgressBar();
    }

    public void ApplayDamage(float damage)
    {
        if (isDead)
            return;

        Health -= damage;

        if (Health <= 0)
        {
            Die();
            isDead = true;
        }

        HealthProgressBar();
    }


    void HealthProgressBar()
    {
        if(Health>=0)
        GetComponent<ObjectsScripts>().SetHealthBarValue(Health);
    }
    void Die()
    {
        GetComponent<ObjectsScripts>().DieEffect();
    }


} // class
