using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerBar : MonoBehaviour
{
    public Slider slider;

    // Set Max Value
    public void SetMaxPower(float power)
    {
        slider.maxValue = power;
        slider.value = power;
    }

    // Set Current Value
    public void SetPower(float power)
    {
        slider.value = power;
    }

}
