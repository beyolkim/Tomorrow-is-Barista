using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    //클릭 이벤트에 반응할 액션
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    
    //라인의 최대 유효 거리
    public float maxDistance = 30.0f;

    //라인의 색상
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        //컨트롤러의 정보를 검출하기 위한 SteamVR_Behaviour_Pose 컴포넌트 추출
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        //입력 소스 추출
        hand = pose.inputSource;

        //LineRenderer 생성
        CreateLineRenderer();
    }

    void CreateLineRenderer()
    {
        //LineRenderer 생성
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        //시작점과 끝점의 위치 설정
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        //라인의 너비 설정
        line.startWidth = 0.03f;
        line.endWidth = 0.005f;

        //라인의 머티리얼 및 색상 설정
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
