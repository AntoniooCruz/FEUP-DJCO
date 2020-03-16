using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Image circleBar;
    public Image extraBar;

    private float maxPower = 7;

    public void Start()
    {
        circleBar.fillAmount = 0f;
        extraBar.fillAmount = 0f;
    }
    public void SetPowerlvl(float power)
    {
        if (power == 0)
        {
            circleBar.fillAmount = 0f;
            extraBar.fillAmount = 0f;
        }
        else
        {
            circleBar.fillAmount = 1f;
            extraBar.fillAmount = power / maxPower;
        }
    }

    public void SetMaxPowerLvl(float maxpower)
    {
        maxPower = maxpower;
    }
}
