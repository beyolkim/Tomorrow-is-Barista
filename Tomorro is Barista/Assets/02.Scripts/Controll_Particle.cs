using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll_Particle : MonoBehaviour
{
    ParticleSystem coffeepouder;

    void Start()
    {
        coffeepouder = gameObject.GetComponent<ParticleSystem>();
    
    }
    public void ParticleStop()
    {
        coffeepouder.Pause();
    }

    public void ParticleStart()
    {
        coffeepouder.Play();
    }

}
