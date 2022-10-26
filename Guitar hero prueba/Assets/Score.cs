using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public string puntos;
    void Update()
    {
        GetComponent<Text>().text = "Score " + PlayerPrefs.GetInt(puntos) + "";
    }
}
