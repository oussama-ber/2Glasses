using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
  [SerializeField]  float xValue = 0f;
  [SerializeField]  float yValue = 1f;
  [SerializeField]  float zValue = 0f;
  public float speedRotatoion = 3f ; 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xValue, yValue , zValue) ;
    }
}
