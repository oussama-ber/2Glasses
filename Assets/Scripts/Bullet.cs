using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float bulletSpeed = 20f;
   public Rigidbody rb;
   public int damage = 10;

    void Start()
    {
      
        rb.velocity = - transform.right * bulletSpeed ;
    }

    void OnTriggerEnter(Collider other) {
        Health enemy = other.GetComponent<Health>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        
    }
  

    
}
