using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedAns : MonoBehaviour
{
    public int selectedAns;

private void OnCollisionEnter(Collision other) 
{
    if(other.gameObject.name == "BeanPlate0")
    {
        selectedAns = 0;
    }   
        if(other.gameObject.name == "BeanPlate1")
    {
        selectedAns = 1;
    }
        if(other.gameObject.name == "BeanPlate2")
    {
        selectedAns = 2;
    }



}

}
