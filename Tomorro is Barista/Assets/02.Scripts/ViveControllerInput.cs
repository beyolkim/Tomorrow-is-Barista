using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveControllerInput : MonoBehaviour
{
    //입력 소스 정의
    public SteamVR_Input_Sources leftHand   = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand  = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources any        = SteamVR_Input_Sources.Any;

    //액션 트리거 버튼
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SteamVR_Actions.default_InteractUI.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Debug.Log("Left Trigger Clicked");
        }
    }
}
