using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour
{
    public GameManager gManager;
    public Text currentLevel;

    void Update()
    {
        currentLevel.text = gManager.currentLevel.ToString("0");
    }
}
