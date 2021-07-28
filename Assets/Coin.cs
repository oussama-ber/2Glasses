using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float xValue = 0f;
    [SerializeField] float yValue = 0.1f;
    [SerializeField] float zValue = 0f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xValue, zValue, yValue);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Tank")
        {
            GameObject tankObject = other.gameObject; 
            float tankSpeed = tankObject.GetComponent<TankController>().movementSpeed;
            Debug.Log("the tank speed is : " + tankSpeed); 
            Destroy(gameObject);
        }
    }
}
