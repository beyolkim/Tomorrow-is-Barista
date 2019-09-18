using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandController : MonoBehaviour
{

    //입력 소스 정의
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grip; //= SteamVR_Input.GetBooleanAction("GrabGrip");
    public SteamVR_Action_Boolean trigger; //= SteamVR_Actions.default_InteractUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetGrab())
        {
            Debug.Log("Grab" + handType);
        }
    }

    //잡기 액션이 활성화되어 있으면 true 반환
    public bool GetGrab()
    {
        return grip.GetState(handType);
    }
}
    
   