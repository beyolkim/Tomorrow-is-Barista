using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrayTrigger : MonoBehaviour
{

    GameObject go;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "CoffeeCake")
        {
            Debug.Log("Yes");
            go = other.gameObject;
            rb = go.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }

    }
}
