using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExecutionsSystem : MonoBehaviour
{
    public static  ExecutionsSystem instance;

    private void Awake()
    {
      LoadHouses();
        
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void SaveHouses()
    {
        SaveSystem.SaveHouses();
    }

    public void LoadHouses()
    {
        DataSaved data = SaveSystem.Load();
        HousesManager.instance.LoadData(data._houses);
        CazarmManager.instance.LoadData(data._soldierHouses);
        StatusManager.instance.LoadData(data._status);
        if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().ReturnValue() < data.money)
            GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().LoadData(data.money);
    } 

    public void Restart()
    {
        SaveSystem.Restart();
        SceneManager.LoadScene(0);
    }

}
