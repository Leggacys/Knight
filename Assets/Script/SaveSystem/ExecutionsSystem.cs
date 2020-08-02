using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExecutionsSystem : MonoBehaviour
{
    public void SaveHouses()
    {
        SaveSystem.SaveHouses();
    }

    public void LoadHouses()
    {
        DataSaved data = SaveSystem.Load();
        HousesManager.instance.LoadData(data._houses);
        CazarmManager.instance.LoadData(data._soldierHouses);
        SceneManager.LoadScene(0);
    }

}
