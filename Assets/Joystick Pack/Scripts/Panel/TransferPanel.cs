using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferPanel : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }


    public void LoadScene(int index)
    {
        StartCoroutine(Transition(index));
    }

    IEnumerator Transition(int index)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
