using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateRunWithSphereCast : MonoBehaviour
{
    public float sphereRadius = 40f;
    public float maxDistance = 50f;
    public GameObject enemyGun;
    private Vector3 origin;
    private Vector3 direction;
    private float curretnHitDistance;

    // test 

    public float rotationSpeed = 100f;
    public bool hitBool = false;


    void FixedUpdate()
    {
        RotationProcess();
    }
    void RotationProcess()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        hitBool = Physics.SphereCast(origin, sphereRadius , direction, out hit);
        if (hitBool)
        {
            if (hit.transform.gameObject.tag == "Tank")
            {
                curretnHitDistance = hit.distance;
                Vector3 hitPosition = hit.transform.position;
                GunRotation(hitPosition);
            }
        }
        else
        {
            hitBool = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (hitBool)
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(origin, origin + direction * curretnHitDistance);
            Gizmos.DrawWireSphere(transform.position + direction * curretnHitDistance, sphereRadius );
        }

    }
    private void GunRotation(Vector3 targetPosition)
    {
        Vector3 directionPlayer = targetPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(directionPlayer);
        enemyGun.transform.rotation = Quaternion.Lerp(enemyGun.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

}
