using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager instance=null;
    private Dictionary<string, float> _statusAtribute = new Dictionary<string, float>();
    private GameObject _player;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if(instance!=this)
                Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(_player.transform.position);

    }

    public void Increse(iNCRESE slider)
    {
        slider.Add();
        Modifay(slider);
    }

    public void Modifay(iNCRESE slider)
    {
        _statusAtribute[slider.gameObject.name]++;
    }

    public void Memorize(string key,int value)
    {
        if (!_statusAtribute.ContainsKey(key))
            _statusAtribute.Add(key, value);
    }

    public Dictionary<string,float> ReturnValue()
    {
        return _statusAtribute;
    }

    public void LoadData(Dictionary<string,float> loadStatus)
    {
        _statusAtribute = loadStatus;
    }

    public bool Exist(string key)
    {
        if (_statusAtribute.ContainsKey(key))
            return true;
        return false;
    }

    public  float Return(string key)
    {
        return _statusAtribute[key];
    }

    public void IncreseValue(string name, float value)
    {
       SaveSystem.SaveHouses();
        if (name == "Def")
            _player.GetComponent<Player>().def++;
        if (name == "Attack")
            _player.GetComponent<Player>().damage++;
        if (name == "Speed")
            _player.GetComponent<Player>().speed+=0.1f;
        if (name == "HP")
            _player.GetComponent<Player>().health += 2;
    }

    public Dictionary<string,float> LoadStatusInGame()
    {
        return _statusAtribute;
    }
}
