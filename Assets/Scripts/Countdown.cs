using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{
    public GameManager gManager;
    public Text timeValue;

    // Update is called once per frame
    void Update()
    {
       timeValue.text = gManager.timeRemaining.ToString("0");
    }
}