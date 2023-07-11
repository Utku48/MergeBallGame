using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource Soundefect;
    void Start()
    {

    }


    void Update()
    {
        if (BallController.click == true)
        {
            Soundefect.Play();
        }
    }




}
