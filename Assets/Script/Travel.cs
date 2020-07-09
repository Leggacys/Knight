using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TravelMenu;
    
    public int SceneTransfer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       TravelMenu.GetComponent<TransferPanel>().LoadScene(SceneTransfer);
    }
}
