using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(9.2f * 10f, 9.8f * 10f));  //rb.AddForce()=> Rigidbody bileşenine kuvvet uygulamak için kullanılır.
    }


    void Update()
    {

    }
}
