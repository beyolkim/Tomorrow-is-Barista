using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedAns : MonoBehaviour
{
    public string selectedAns ;

    private void Start() 
    {
        selectedAns = "none";
    }

private void OnTriggerEnter(Collider other) 
{
    if(other.gameObject.name == "BeanPlate0")
    {
        selectedAns = "Dolce";
    }   
        if(other.gameObject.name == "BeanPlate1")
    {
        selectedAns = "Largo";
    }
        if(other.gameObject.name == "BeanPlate2")
    {
        selectedAns = "Lusso";
    }



}

}
