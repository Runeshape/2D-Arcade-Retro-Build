using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsCon : MonoBehaviour
{
    [SerializeField]
    private float _fadespeed;
    [SerializeField]
    private Color Fadeable = new Color(0, 0, 0, 0);
    [SerializeField]
    private Color fadeColor;
    [SerializeField]
    private Material fadeMaterial;
    public float inter;

    // Start is called before the first frame update
    void Start()
    {
        fadeMaterial = GetComponent<Renderer>().material;
        fadeColor = fadeMaterial.color;
        
    }

    IEnumerator smeg()
    {
        {

            while (inter < 1.0f)
            {
                inter += _fadespeed * Time.deltaTime;
                fadeMaterial.color = Color.Lerp(fadeColor, Fadeable, inter);
                yield return null;
            }
        }

    }
}