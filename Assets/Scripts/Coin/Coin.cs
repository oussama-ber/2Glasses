using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float xValue = 0f;
    [SerializeField] float yValue = 0.1f;
    [SerializeField] float zValue = 0f;
    public GameObject staminaBar;
    public StaminaBar staminaTest;
    public GameObject CoinSpawer;
    public Transform pointToSpawn;

    void Start()
    {
        // staminaTest = GetComponent<StaminaBar>();
        // staminaBar.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xValue, zValue, yValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            GameObject tankObject = other.gameObject;
            float tankSpeed = tankObject.GetComponent<TankController>().movementSpeed;
            //testing: 
            // if (staminaTest.GetComponent<StaminaBar>().currentStamina <= 1f)
            // {
            // }
                Debug.Log("the currentStaminaBar " + staminaTest.GetComponent<StaminaBar>().currentStamina);
                staminaBar.SetActive(true);
                GetComponent<Spawning>().ChangePosition();
        }
    }
}
