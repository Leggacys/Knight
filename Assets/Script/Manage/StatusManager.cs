using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public static StatusManager instance = null;
    private Dictionary<string, float> _statusAtribute = new Dictionary<string, float>();
    private GameObject _player;
    //Public Variables
    public List<int> Def = new List<int>();
    public List<int> Attack = new List<int>();
    public List<int> Speed = new List<int>();
    public List<int> HP = new List<int>();


    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Increse(iNCRESE slider)
    {
        slider.Add();
        Modifay(slider);
    }

    public void Modifay(iNCRESE slider)
    {
        _statusAtribute[slider.gameObject.name] += slider.gameObject.GetComponent<iNCRESE>().value;
    }

    public void Memorize(string key, int value)
    {
        if (!_statusAtribute.ContainsKey(key))
            _statusAtribute.Add(key, value);
    }

    public Dictionary<string, float> ReturnValue()
    {
        return _statusAtribute;
    }

    public void LoadData(Dictionary<string, float> loadStatus)
    {
        _statusAtribute = loadStatus;
    }

    public bool Exist(string key)
    {
        if (_statusAtribute.ContainsKey(key))
            return true;
        return false;
    }

    public float Return(string key)
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
            _player.GetComponent<Player>().speed += 0.1f;
        if (name == "HP")
            _player.GetComponent<Player>().health += 2;
    }



    public Dictionary<string, float> LoadStatusInGame()
    {
        return _statusAtribute;
    }

    public bool MoneyForStatus(int value,int number)
    {
          if(number==1)
        {
            if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(Def[value]))
            {
                GameObject.FindGameObjectWithTag("DefCost").GetComponent<Text>().text = Def[value + 1].ToString();
                return true;
            }
                
            return false;
        }
        if (number == 2)
        {
            if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(Attack[value]))
            {
                GameObject.FindGameObjectWithTag("AttackCost").GetComponent<Text>().text = Attack[value + 1].ToString();
                return true;
            }
                
            return false;
        }
        if (number == 3)
        {
            if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(Speed[value]))
            {
                GameObject.FindGameObjectWithTag("SpeedCost").GetComponent<Text>().text = Speed[value + 1].ToString();
                return true;
            }
            return false;
        }
        if (number == 4)
        {
            if (GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().CoinAmount(HP[value]))
            {
                GameObject.FindGameObjectWithTag("HPcost").GetComponent<Text>().text = HP[value + 1].ToString();
                return true;
            }
                
            return false;
        }
        return false;
    }

    public int TextModifai(string name,int value)
    {
        if(name=="Def")
        {
            return Def[value];
        }
        if (name == "Attack")
        {
            return Attack[value];
        }
        if (name == "Speed")
        {
            return Speed[value];
        }
        if (name == "HP")
        {
            return HP[value];
        }
        return 1;
    }
}
