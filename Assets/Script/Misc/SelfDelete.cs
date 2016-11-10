using UnityEngine;
using System.Collections;

public class SelfDelete : MonoBehaviour
{

    public float deleteTime;
    float fadeSpeed;

    void Start()
    {
        fadeSpeed = 1 / deleteTime;
        Destroy(this.gameObject.transform.parent.gameObject, deleteTime + 1);
        Destroy(this.gameObject, deleteTime);
    }

    void Update()
    {
        var material = GetComponent<Renderer>().material;
        var color = material.color;
        
        material.color = new Color(color.r, color.g, color.b, color.a - (fadeSpeed * Time.deltaTime));
    }
}