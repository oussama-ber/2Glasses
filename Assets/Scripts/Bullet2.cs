using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
   public float bulletSpeed = 20f;
   public Rigidbody rb;
   public int damage = 10;

    void Start()
    {
      
        rb.velocity = - transform.right * bulletSpeed ;
    }

    void OnTriggerEnter(Collider other) {
        Health2 enemy = other.GetComponent<Health2>();
        if(enemy != null)
        {
            
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        
    }
  

    
}
