using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_control : MonoBehaviour

{
   
    public GameObject obj1, obj2, obj3;

   
    void OnTriggerEnter(Collider other)

    {
        Vector3 pos = new Vector3(118.29f, 10.349f, -12.837f);
        Debug.Log("붙을 준비");
        if (other.gameObject.CompareTag("Grinder"))

        {
            iTween.MoveTo(obj1, iTween.Hash("position", pos
                                       , "easeType", "Math.easeOutExpo"
                                       , "speed", 5.0f
                                       )); // hashtable 이용해서 사용함.(키, 밸류)
            //other.gameObject.SetActive(false);
            Debug.Log("붙었다!");
            
        }

    }


    // Start is called before the first frame update


}

