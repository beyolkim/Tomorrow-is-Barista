using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedAns : MonoBehaviour
{
    public string selectedAns;
    public GameObject timeBar;
    public GameObject testBtn;
    public GameObject stopBtn;
    public GameObject shelfUI;

    private void Start()
    {
        selectedAns = "none";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BeanPlate0")
        {
            selectedAns = "Dolce";
        }
        if (other.gameObject.name == "BeanPlate1")
        {
            selectedAns = "Largo";
        }
        if (other.gameObject.name == "BeanPlate2")
        {
            selectedAns = "Lusso";
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Test") // 테스트 버튼을 건드리면
        {
            timeBar.SetActive(true); // 테스트 시작
            testBtn.SetActive(false);
            stopBtn.SetActive(true);
            shelfUI.SetActive(true);
        }
        if (other.gameObject.name == "Stop") // 스탑 버튼을 건드리면
        {
            timeBar.SetActive(false); // 테스트 끄기
            testBtn.SetActive(true);
            stopBtn.SetActive(false);
            shelfUI.SetActive(false);
        }
        if (other.gameObject.name == "Tutorial") // 튜토 버튼을 건드리면
        {
            timeBar.SetActive(true); // 테스트 끄기
            testBtn.SetActive(true);
            stopBtn.SetActive(false);
            shelfUI.SetActive(true);
        }



    }

}
