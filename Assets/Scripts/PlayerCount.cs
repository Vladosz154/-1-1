using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCount : MonoBehaviour
{
    Text text;
    public static int player;
    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = player.ToString();
    }
}
