using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualReloading : MonoBehaviour
{
    // just testing.
    public GameObject reloadSpawner;

    public GameObject reloadStation;
    public Vector3 directionPlayer;
    public float rotationSpeed = 2f;
    public float emenyRange = 200f;
    public float movementSpeed = 10f;
    public ParticleSystem reloadingParticules;
    public bool isLoaded = false;
    public EnemyTankEasy enemyTankLevel;
    public int ammoToReload;
    Quaternion rotation;

    void Start()
    {
        isLoaded = GetEnemyTankIsLoaded();
         isLoaded = false;
         ammoToReload= enemyTankLevel.ammo;
    }
    private void FixedUpdate()
    {
        isLoaded = GetEnemyTankIsLoaded();
        // RotateProcess();
        if (!isLoaded)
        {
            // RotateProcess();
            Move();
            FindingPath();
        }
    }
    void RotateProcess()
    {
        directionPlayer = reloadStation.transform.position - transform.position;
        rotation = Quaternion.LookRotation(directionPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    void Move()
    {
        transform.position += movementSpeed * Time.deltaTime * transform.forward;

    }

    void FindingPath()
    {
        Vector3 raycastOffset = Vector3.zero;
        //set direction.
        Vector3 directionForward = transform.forward;
        //set origins.
        Vector3 origin = transform.position;
        Vector3 rightOrigin = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
        Vector3 leftOrigin = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
        //drawRays
        Debug.DrawRay(origin, directionForward * 200f, Color.red);
        Debug.DrawRay(rightOrigin, directionForward * 200f, Color.cyan);
        Debug.DrawRay(leftOrigin, directionForward * 200f, Color.cyan);
        //Rays
        Ray rayForward = new Ray(origin, directionForward);
        Ray rayRightForward = new Ray(rightOrigin, directionForward);
        Ray rayLeftForward = new Ray(leftOrigin, directionForward);
        //hit forwards
        RaycastHit hitForward;
        RaycastHit hitRightForward;
        RaycastHit hitLeftForward;
        // booliens for hitforwards
        bool forwardBool = Physics.Raycast(rayForward, out hitForward, emenyRange);
        bool rightForwardBool = Physics.Raycast(rayRightForward, out hitRightForward, emenyRange);
        bool leftForwardBool = Physics.Raycast(rayLeftForward, out hitLeftForward, emenyRange);

        if (rightForwardBool)
        {
            if (hitRightForward.transform.gameObject.tag == "MiddleObstacles")
            {
                raycastOffset -= Vector3.right;
            }
        }
        else
        if (leftForwardBool)
        {
            if (hitLeftForward.transform.gameObject.tag == "MiddleObstacles")
            {
                raycastOffset += Vector3.right;
            }
        }
        if (raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * Time.deltaTime * 5f);
        else
        {
            if (reloadStation != null)
                RotateProcess();
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "ReloadStation") && !isLoaded)
        {

            // Destroy(reloadStation);
            isLoaded = true;
            GetComponent<EnemyShooting>().ammo = ammoToReload;
            // give permertion to spawner another reloadStation.
            StationSpawning();
            //--------------------end Testing

            transform.Rotate(0, 90f, 0);
            reloadingParticules.Play();
            Debug.Log("reloding seccess !!! we should increase the ammo");
            GetComponent<EnemyMovement>().enabled = true;
            GetComponent<EnemyShooting>().enabled = true;
            GetComponent<EnemyMoveAlong>().enabled = true;
            GetComponent<ManualReloading>().enabled = false;
        }
    }
    public bool GetEnemyTankIsLoaded()
    {
        return GetComponent<EnemyShooting>().enemyTankIsLoaded;
    }
    public void StationSpawning()
    {
        reloadSpawner.GetComponent<ReloadStationSpawner>().StationSpawner();
    }
}
