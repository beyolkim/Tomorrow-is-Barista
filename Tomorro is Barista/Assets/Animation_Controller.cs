using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    private Animator anim;
    private int aniIsCheck; // 애니메이터 파라미터의 해쉬값을 저장할 변수
    private int hashIsFinger;


    void Start()
    {
        anim = GetComponent<Animator>(); 
  
        aniIsCheck = Animator.StringToHash("IsBool");
        Cor_Coffee_Flow();

    }

    public void Cor_Coffee_Flow()
    {
        StartCoroutine(Coffee_Flow());
    }

    IEnumerator Coffee_Flow()
    {
        yield return new WaitForSeconds(2);

        anim.SetBool(aniIsCheck, true);
        yield return new WaitForSeconds(20);
        anim.SetBool(aniIsCheck, false);
    }

    public void OnTriggerEnter(Collider other) //충돌감지 콜백함수 
    {
        Debug.Log("커피가차오른다");
        FillCoffee(other);
    }

    private void FillCoffee(Collider col)
    {

        col.GetComponent<Wobble>().Espresso_Fill();
        Debug.Log("채워질까?");

    }
}
