using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float bulletSpeed = 20f;
   public Rigidbody rb;
   public int damage = 10;
   public int factorSign; 

    void Start()
    {
      
        rb.velocity =  transform.right * factorSign * bulletSpeed ;
    }

    void OnTriggerEnter(Collider other) {
        ZombieHealth enemy = other.GetComponent<ZombieHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        
    }
  

    
}
