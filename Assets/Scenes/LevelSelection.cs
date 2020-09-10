using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    int lvlat;
    void Start()
    {
        lvlat = PlayerPrefs.GetInt("levelAT", 0);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i > lvlat)
                lvlButtons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
