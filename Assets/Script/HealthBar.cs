using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform Container1;
    public RectTransform Container2;
    public RectTransform Container3;
    public int health = 3;

    void Update()
    {
        Container1.GetComponent<Animator>().SetBool("Empty", health < 1);
        Container2.GetComponent<Animator>().SetBool("Empty", health < 2);
        Container3.GetComponent<Animator>().SetBool("Empty", health < 3);
    }
}
