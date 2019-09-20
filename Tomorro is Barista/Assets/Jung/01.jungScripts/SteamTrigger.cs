using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTrigger : MonoBehaviour
{
    public ParticleSystem pt;
    public Animator anim;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(other.gameObject.name == "Controller (right)")
        {
            pt.Stop();
            pt.Play();

            anim.SetBool("isSteamBtn",true);

        }

    }

     private void OnTriggerExit(Collider other) {
        Debug.Log(other.name);
        if(other.gameObject.name == "Controller (right)")
        {
            pt.Stop();
            
            anim.SetBool("isSteamBtn",false);

        }

    }



}
