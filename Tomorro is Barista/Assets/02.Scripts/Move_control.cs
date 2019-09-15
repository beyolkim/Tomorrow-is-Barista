using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_control : MonoBehaviour

{

    public GameObject obj1, obj2, obj3;
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("TEST"))

        {
                         
            iTween.MoveTo(obj1, iTween.Hash("z", 1.0f
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 2.5f
                                       )); // hashtable 이용해서 사용함.(키, 밸류)
            //other.gameObject.SetActive(false);
            Debug.Log("붙었다!");

        }
    }


    // Start is called before the first frame update


}

