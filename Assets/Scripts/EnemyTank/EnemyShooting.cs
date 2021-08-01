using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public EnemyTankEasy enemyLevel;

    public GameObject tankGun;
    public int damage ;
    [SerializeField] public float range = 100f;

    public float fireRate ;
    public float fireCountdown = 0f;
    //effects:
    public ParticleSystem shootEffect;
    public ParticleSystem targetEffect;
    public int ammo;

    public GameObject reloadStation;
    public bool enemyTankIsLoaded;
    //initialise: ammo ,FireRate,damage

    void Start()
    {
        Vector3 origin = tankGun.transform.position;
        Vector3 directionForward = tankGun.transform.forward;
        enemyTankIsLoaded = true;
        ammo = enemyLevel.ammo;
        damage = enemyLevel.damage;
        fireRate = enemyLevel.fireRate;
    }
    
    void Update()
    {
        Vector3 origin = tankGun.transform.position;
        Vector3 directionForward = tankGun.transform.forward;
        Debug.DrawRay(origin, directionForward * 50f, Color.red);
        Search();
    }

    public bool Search()
    {
        //get position and direction of the gun.
        Vector3 origin = tankGun.transform.position;
        Vector3 directionForward = tankGun.transform.forward;
        Ray rayForward = new Ray(origin, directionForward);
        RaycastHit hit;
        if (Physics.Raycast(rayForward, out hit, range))
        {
            // Debug.Log(hit.transform.name);
            Vector3 effectPosition = hit.point;
            if (hit.transform.tag == "Tank")
            {
                TankHealth player = hit.transform.gameObject.GetComponent<TankHealth>();
                if (player != null)
                {
                    if (fireCountdown <= 0f)
                    {
                        Shoot(player, effectPosition);
                        fireCountdown = 1f / fireRate;
                    }
                    fireCountdown -= Time.deltaTime;

                }
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    void Shoot(TankHealth player, Vector3 effectPosition)
    {
        if (ammo > 0)
        {
            shootEffect.Play();
            targetEffect.transform.position = effectPosition;
            player.TakeDamage(damage);
            targetEffect.Play();
            // Debug.Log("the enemy health is " + player.currentHealth);
            ammo -= 1;
        }
        else
        {
            enemyTankIsLoaded = false;
            GetComponent<ManualReloading>().enabled = true;
            GetComponent<EnemyShooting>().enabled = false;
            GetComponent<ManualMoveAlong>().enabled = false;
            GetComponent<EnemyMovement>().enabled = false;
        }

    }
    void Test()
    {

        GetComponent<ManualReloading>().enabled = true;

    }
    // void GoReload()
    // {
    //     //make the movealong false
    //     transform.position = Vector3.MoveTowards(transform.position, reloadStation.transform.position, speed * Time.deltaTime);
    // }


}
