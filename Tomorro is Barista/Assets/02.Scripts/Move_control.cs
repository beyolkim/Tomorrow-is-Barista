using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_control : MonoBehaviour

{

    public GameObject obj1;
    public GameObject ghost_Port_R;
    public GameObject ghost_Port_L;
    public GameObject ghost_Grinder;
    void OnTriggerEnter(Collider other)

    {
        Vector3 pos_Grinder = new Vector3(118.29f, 10.209f, -11.125f);
        Vector3 pos_Port_R = new Vector3(123.465f, 12.063f, -10.961f);
        Vector3 angle_Port = new Vector3(-180f, 210f, -180f);
        Vector3 pos_Port_L = new Vector3(125.541f, 12.195f, -11.514f);

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
            iTween.MoveTo(obj1, iTween.Hash("position", pos_Port_R
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 5.0f
                                       ));

            obj1.transform.rotation = Quaternion.Euler(angle_Port);

            iTween.RotateTo(obj1, iTween.Hash("y", 0
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 10.0f
                                       ));
            ghost_Port_R.SetActive(false);

        }

        if (other.gameObject.CompareTag("Coffee_Port_Left"))
        {
            iTween.MoveTo(obj1, iTween.Hash("position", pos_Port_L
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 5.0f
                                       ));

            obj1.transform.rotation = Quaternion.Euler(angle_Port);

            iTween.RotateTo(obj1, iTween.Hash("y", 0
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 10.0f
                                       ));
            ghost_Port_L.SetActive(false);

        }

    }

}

