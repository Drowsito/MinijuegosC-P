using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplicador : MonoBehaviour
{
    public string multiplicador;
    void Update()
    {
        GetComponent<Text>().text ="x " + PlayerPrefs.GetFloat(multiplicador) + "";
    }
}
