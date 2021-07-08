using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
  public Transform firePoint; 
   public GameObject bulletPrefab;
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
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
