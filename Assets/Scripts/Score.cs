using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public GameManager gManager;
    public Text scoreValue;

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = gManager.score.ToString("0");
    }
}
