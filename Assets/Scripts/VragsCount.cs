using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VragsCount : MonoBehaviour
{
    Text text;
    public static int vrags;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = vrags.ToString();
    }
}
