using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText = null;


    // Update is called once per frame
    void Update()
    {
        timerText.text = GameController.GetInstance().GetScore().ToString();
    }
}
