using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBase : MonoBehaviour, IHitit
{
    private GameObject _transferPanel;
    public float HP;
    public int coinDrop;
    private GameObject _moneyTable;
    public  void Start()
    {
        _moneyTable = GameObject.FindGameObjectWithTag("Coin");
        _transferPanel = GameObject.FindGameObjectWithTag("TransferPanel");
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Transport();
            DropCoin();
            Destroy(gameObject);
        }
    }

    public void Transport()
    {
        _transferPanel.GetComponent<TransferPanel>().LoadScene(0);
    }

    public void Touched()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Dead()
    {
        throw new System.NotImplementedException();
    }

    public void DropCoin()
    {
        _moneyTable.GetComponent<CoinScript>().AddCoin(coinDrop);
    }
}
