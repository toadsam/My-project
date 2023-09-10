using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodChickenpool : MonoBehaviour
{
    private Vector3 direction;
    private void OnEnable()
    {
        transform.position = new Vector3(0, 0, 0);
        StartCoroutine("DisableObject");

    }
    void Start()
    {
        direction = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        StartCoroutine("DisableObject");
    }
    private void FixedUpdate()
    {
        transform.position += direction;
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(4.0f);
        gameObject.SetActive(false);
    }
}

