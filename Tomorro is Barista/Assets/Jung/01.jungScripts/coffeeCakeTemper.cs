using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeeCakeTemper : MonoBehaviour
{
    float dt;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) 
    {
        dt += Time.deltaTime;
        if(other.gameObject.name == "CoffeeCake" && dt>=3f)
        {
         go = other.gameObject;
         go.transform.localScale = new Vector3 (0.07338704f,0.0025f,0.07338703f);

         dt = 0;

        }

    }
}
