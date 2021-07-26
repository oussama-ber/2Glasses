using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public Transform firePoint; 
   public GameObject bulletPrefab;
   public string fireButton; 
    void Update()
    {
        if(Input.GetButtonDown(fireButton))
        { 
            Shoot();
        }
    }


    void Shoot ()
    {
       Debug.Log("shoot");
       Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
