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
    private int jugador;

    void Start()
    {
        PlayerPrefs.SetInt("Puntos1", 0);
        PlayerPrefs.SetInt("Puntos2", 0);
        PlayerPrefs.SetInt("Puntos3", 0);
        PlayerPrefs.SetInt("Puntos4", 0);
        PlayerPrefs.SetFloat("Multiplicador1", 1);
        PlayerPrefs.SetFloat("Multiplicador2", 1);
        PlayerPrefs.SetFloat("Multiplicador3", 1);
        PlayerPrefs.SetFloat("Multiplicador4", 1);
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
                if (tecla == KeyCode.A || tecla == KeyCode.S || tecla == KeyCode.D || tecla == KeyCode.F)
                {
                    jugador = 1;
                    Destroy(nota);
                    SumarPuntos();
                    activo = false;
                }
                else if (tecla == KeyCode.Z || tecla == KeyCode.X || tecla == KeyCode.C || tecla == KeyCode.V)
                {
                    jugador = 2;
                    Destroy(nota);
                    SumarPuntos();
                    activo = false;
                }
                else if (tecla == KeyCode.U || tecla == KeyCode.I || tecla == KeyCode.O || tecla == KeyCode.P)
                {
                    jugador = 3;
                    Destroy(nota);
                    SumarPuntos();
                    activo = false;
                }
                else if (tecla == KeyCode.LeftArrow || tecla == KeyCode.UpArrow || tecla == KeyCode.DownArrow || tecla == KeyCode.RightArrow)
                {
                    jugador = 4;
                    Destroy(nota);
                    SumarPuntos();
                    activo = false;
                }
            }
            else if (Input.GetKeyDown(tecla))
            {
                if (tecla == KeyCode.A || tecla == KeyCode.S || tecla == KeyCode.D || tecla == KeyCode.F)
                {
                    jugador = 1;
                    RestarPuntos();
                }
                else if (tecla == KeyCode.Z || tecla == KeyCode.X || tecla == KeyCode.C || tecla == KeyCode.V)
                {
                    jugador = 2;
                    RestarPuntos();
                }
                else if (tecla == KeyCode.U || tecla == KeyCode.I || tecla == KeyCode.O || tecla == KeyCode.P)
                {
                    jugador = 3;
                    RestarPuntos();
                }
                else if (tecla == KeyCode.LeftArrow || tecla == KeyCode.UpArrow || tecla == KeyCode.DownArrow || tecla == KeyCode.RightArrow)
                {
                    jugador = 4;
                    RestarPuntos();
                }
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
        if (jugador == 1)
        {
            PlayerPrefs.SetInt("Puntos1", PlayerPrefs.GetInt("Puntos1")+(int)(100*PlayerPrefs.GetFloat("Multiplicador1")));
            PlayerPrefs.SetFloat("Multiplicador1", PlayerPrefs.GetFloat("Multiplicador1")+(float)0.1);
        }
        else if (jugador == 2)
        {
            PlayerPrefs.SetInt("Puntos2", PlayerPrefs.GetInt("Puntos2")+(int)(100*PlayerPrefs.GetFloat("Multiplicador2")));
            PlayerPrefs.SetFloat("Multiplicador2", PlayerPrefs.GetFloat("Multiplicador2")+(float)0.1);
        }
        else if (jugador == 3)
        {
            PlayerPrefs.SetInt("Puntos3", PlayerPrefs.GetInt("Puntos3")+(int)(100*PlayerPrefs.GetFloat("Multiplicador3")));
            PlayerPrefs.SetFloat("Multiplicador3", PlayerPrefs.GetFloat("Multiplicador3")+(float)0.1);
        }
        else if (jugador == 4)
        {
            PlayerPrefs.SetInt("Puntos4", PlayerPrefs.GetInt("Puntos4")+(int)(100*PlayerPrefs.GetFloat("Multiplicador4")));
            PlayerPrefs.SetFloat("Multiplicador4", PlayerPrefs.GetFloat("Multiplicador4")+(float)0.1);
        }
    }
    
    void RestarPuntos()
    {
        if (jugador == 1)
        {
            PlayerPrefs.SetInt("Puntos1", PlayerPrefs.GetInt("Puntos1")-50);
            PlayerPrefs.SetFloat("Multiplicador1", 1);
        }
        else if (jugador == 2)
        {
            PlayerPrefs.SetInt("Puntos2", PlayerPrefs.GetInt("Puntos2")-50);
            PlayerPrefs.SetFloat("Multiplicador2", 1);
        }
        else if (jugador == 3)
        {
            PlayerPrefs.SetInt("Puntos3", PlayerPrefs.GetInt("Puntos3")-50);
            PlayerPrefs.SetFloat("Multiplicador3", 1);
        }
        else if (jugador == 4)
        {
            PlayerPrefs.SetInt("Puntos4", PlayerPrefs.GetInt("Puntos4")-50);
            PlayerPrefs.SetFloat("Multiplicador4", 1);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        activo  = false;
    }
}
