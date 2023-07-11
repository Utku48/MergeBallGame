using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ParticuleSystem : MonoBehaviour
{
    public ParticleSystem[] effects = new ParticleSystem[3];
    void Start()
    {

        effects[0] = GameObject.Find("ExplosionGreen").GetComponent<ParticleSystem>();
        effects[1] = GameObject.Find("ExplosionRed").GetComponent<ParticleSystem>();
        effects[2] = GameObject.Find("ExplosionYellow").GetComponent<ParticleSystem>();
    }


    void Update()
    {

    }
}
