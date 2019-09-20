using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_control : MonoBehaviour

{
   
    public GameObject obj1;
    public GameObject ghost_Port;
    public GameObject ghost_Grinder;   
    void OnTriggerEnter(Collider other)

    {
        Vector3 pos_Grinder = new Vector3(118.29f, 10.349f, -12.837f);
        Vector3 pos_Port = new Vector3(123.236f, 12.195f, -11.417f);
        Vector3 angle_Port = new Vector3(90f,0f,-30f);

        if (other.gameObject.CompareTag("Grinder"))
        {
            iTween.MoveTo(obj1, iTween.Hash("position", pos_Grinder
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 5.0f
                                       )); // hashtable 이용해서 사용함.(키, 밸류)
            //other.gameObject.SetActive(false);
            ghost_Grinder.SetActive(false);
        }

        if (other.gameObject.CompareTag("Coffee_Port_Right"))
        {
            iTween.MoveTo(obj1, iTween.Hash("position", pos_Port
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 5.0f
                                       ));
            obj1.transform.rotation = Quaternion.Euler(angle_Port);
            ghost_Port.GetComponent<Animator>().SetBool("isRotate", true);
        }

    }

}

