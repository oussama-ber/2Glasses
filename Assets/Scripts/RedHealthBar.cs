using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RedHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
     public Slider slider;
    public void SetMaxHealth()
    {
        slider.maxValue = 100;
        slider.value = 100;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
