using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WeaponRaycast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 70f;
    public GameObject player;

    //---------------------------------------------
    public int reflections;
    public float maxLength;
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        // Debug.DrawLine(player.transform.position, - player.transform.right * range , Color.red); 
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     Shoot();
        // }
        ShootLazer();
    }
    public void Shoot()
    {
        RaycastHit hit;
        Debug.DrawLine(player.transform.position, -player.transform.right * range, Color.red);
        if (Physics.Raycast(player.transform.position, -player.transform.right, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }

    }
    public void ShootLazer()
    {
        ray = new Ray(transform.position, -transform.right);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;
        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "obstacles")
                    break;
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }
    }
}
