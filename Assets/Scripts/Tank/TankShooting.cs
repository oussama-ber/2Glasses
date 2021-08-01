using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public ParticleSystem shootEffect;
    public ParticleSystem targetEffect;
    public GameObject tankGun;
    public int damage = 10;

    [SerializeField] public float range = 200f;

    private void Start()
    {
        Vector3 origin = tankGun.transform.position;
        Vector3 directionForward = tankGun.transform.forward;
    }
    void Update()
    {
        Vector3 origin = tankGun.transform.position;
        Vector3 directionForward = tankGun.transform.forward;
        Debug.DrawRay(origin, directionForward * 200f, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootEffect.Play();
            Shoot();
        }
    }
    void Shoot()
    {
        //get position and direction of the gun.
        Vector3 origin = tankGun.transform.position;
        Vector3 directionForward = tankGun.transform.forward;

        Ray rayForward = new Ray(origin, directionForward);
        RaycastHit hit;
        if (Physics.Raycast(rayForward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Vector3 heelo = hit.point;
            targetEffect.transform.position = heelo;
            targetEffect.Play();
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.gameObject.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("the enemy health is " + enemy.currentHealth);

                }
            }

        }
    }

}
