using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodChicken : MonoBehaviour
{
    public GameObject goodchicken;
    public GameObject[] goodchickens;
    private int pivot = 0;
    public void Start()
    {
        goodchickens = new GameObject[500];
        for (int i = 0; i < 500; i++)
        {
            GameObject gameObject = Instantiate(goodchicken);
            goodchickens[i] = gameObject;
            gameObject.SetActive(false);
            Debug.Log(goodchickens[i]);
        }
        StartCoroutine("EnableGoodchicken");
    }
    public IEnumerator EnableGoodchicken()
    {
        yield return new WaitForSeconds(0.01f);
        goodchickens[pivot++].SetActive(true);
        if (pivot == 500) pivot = 0;
        StartCoroutine("EnableGoodchicken");
    }
}
