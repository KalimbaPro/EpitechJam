using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genApple : MonoBehaviour
{
    public GameObject apple;
    public GameObject applePrefab;

    public bool generating = false;
    void Update()
    {
        if (apple == null && !generating)
        {
            StartCoroutine(generate());
        }
    }

    private IEnumerator generate()
    {
        generating = true;
        yield return new WaitForSeconds(10);
        apple = Instantiate(applePrefab, gameObject.transform);
        generating = false;
    }
}
