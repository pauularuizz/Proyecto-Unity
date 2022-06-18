using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float Damage;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();

        if (damageTaker != null)
        {
            if (CompareTag("Heal"))
            {
                soundManager.AudioSelector(6, 0.3f);
            }
            
            Destroy(gameObject);
            damageTaker.TakeDamage(Damage);
           

        }
        if(other.isTrigger==false)
             Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    
}
