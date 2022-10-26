using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour
{
    Rigidbody2D rigy;
    public float vel;
    void Start()
    {
        rigy = GetComponent<Rigidbody2D>();
        rigy.velocity = new Vector2(0, -vel);
    }
    
    void Update()
    {
        
    }
}
