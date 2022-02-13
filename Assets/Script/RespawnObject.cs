using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public GameObject obj;
    public GameObject objPrefab;
    public float delay;

    public bool generating = false;

    private void Start()
    {
        objPrefab.SetActive(false);
        obj = Instantiate(objPrefab, gameObject.transform);
        obj.SetActive(true);
    }
    void Update()
    {
        if (obj == null && !generating)
        {
            StartCoroutine(generate());
        }
    }

    private IEnumerator generate()
    {
        generating = true;
        yield return new WaitForSeconds(delay);
        obj = Instantiate(objPrefab, gameObject.transform);
        obj.SetActive(true);
        generating = false;
    }
}
