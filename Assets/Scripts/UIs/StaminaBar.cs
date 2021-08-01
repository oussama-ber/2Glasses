using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public int maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;
    public GameObject player;
    public TankController playerMovement ;


    private void Awake()
    {
        instance = this;
        playerMovement = player.GetComponent<TankController>();
    }
    void Start()
    {
        Debug.Log("shieeeeeeeeet");
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;

    }

    void Update()
    {
        // Debug.Log("the currentStamina "+currentStamina);
        if (currentStamina > 1)
        {

            if (Input.GetKey(KeyCode.W))
            {
                // Debug.Log("sprintinn");
                UseStamina(0.050f);

            }
            if (playerMovement != null)
            {
                playerMovement.sprintMovement = 30f;
                playerMovement.movementSpeed = 17f;
            }
        }
        else if (currentStamina <= 1)
        {
            if (playerMovement != null)
            {
                // Debug.Log("reset everything");
                playerMovement.sprintMovement = 17f;
                playerMovement.movementSpeed = 17f;
                currentStamina = 100f;
                Debug.Log("you can go for anotherone");
                gameObject.SetActive(false);
                // Destroy(gameObject);
            }
        }
    }
    public void UseStamina(float amout)
    {
        if (currentStamina - amout >= 0)
        {
            currentStamina -= amout;
            staminaBar.value = currentStamina;
            // if (regen != null)
            // {
            //     StopCoroutine(regen);
            // }
            // regen = StartCoroutine(RegenStamina());
        }
    }
    public IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += (maxStamina / 100) * 3;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
   public void Invisible()
    {
        gameObject.SetActive(false);
    }
}
