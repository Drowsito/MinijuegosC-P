using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode tecla;
    private bool activo = false;
    GameObject nota;
    public bool createMode;
    public GameObject note;

    void Start()
    {
        PlayerPrefs.SetInt("Puntos", 0);
        PlayerPrefs.SetFloat("Multiplicador", 1);
    }
    
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(tecla))
            {
                Instantiate(note, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(tecla) && activo)
            {
                Destroy(nota);
                SumarPuntos();
                activo = false;
            }
            else if (Input.GetKeyDown(tecla))
            {
                RestarPuntos();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        activo = true;
        if (col.gameObject.tag == "Nota")
        {
            nota = col.gameObject;
        }
    }

    void SumarPuntos()
    {
        PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos")+(int)(100*PlayerPrefs.GetFloat("Multiplicador")));
        PlayerPrefs.SetFloat("Multiplicador", PlayerPrefs.GetFloat("Multiplicador")+(float)0.1);
    }
    
    void RestarPuntos()
    {
        PlayerPrefs.SetInt("Puntos", PlayerPrefs.GetInt("Puntos")-50);
        PlayerPrefs.SetFloat("Multiplicador", 1);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        activo  = false;
    }
}
