using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitit 
{
   void TakeDamage(int damage);
    void Touched();
    IEnumerator Dead();
    void DropCoin();
}
