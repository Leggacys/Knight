using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript: MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject YesMenu;

   public void Yes()
    {
        ExecutionsSystem.instance.Restart();
    }

    public void No()
    {
        MainMenu.SetActive(true);
        YesMenu.SetActive(false);
    }
}
