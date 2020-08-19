using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript1 : MonoBehaviour
{

    public GameObject Mainmenu;
    public GameObject YesNo;
   public void Activate()
    {
        YesNo.SetActive(true);
        Mainmenu.SetActive(false);

    }
}
