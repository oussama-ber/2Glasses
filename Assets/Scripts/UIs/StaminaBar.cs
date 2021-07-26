using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public int maxStamina = 100;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;
    public GameObject player;
    public Player1Movement playerMovement ;
   

    private void Awake()
    {
        instance = this;
         playerMovement = player.GetComponent<Player1Movement>();
    }
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        
    }

    void Update()
    {
        if(currentStamina > 20 )
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                UseStamina(0.020f);
                
            }
            if(playerMovement != null)
            {
            playerMovement.sprintSpeed = 20f;
            playerMovement.walkSpeed = 15f;
            }
        }else if (currentStamina <= 20)
        {
            if(playerMovement != null)
            {
            playerMovement.sprintSpeed = 15f;
            playerMovement.walkSpeed= 15f; 
            }
        }
    }
    public void UseStamina(float amout)
    {
        if (currentStamina - amout >= 0)
        {
            currentStamina -= amout;
            staminaBar.value = currentStamina;
            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += (maxStamina / 100) *3;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
    void Invisible()
    {
        gameObject.SetActive(false) ;
    }
}
