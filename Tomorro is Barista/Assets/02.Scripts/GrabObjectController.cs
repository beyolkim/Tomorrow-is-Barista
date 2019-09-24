using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabObjectController : MonoBehaviour
{

    //입력 소스 정의
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grip;
    public SteamVR_Action_Boolean trigger;
    private SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;

    private Transform tr;      // cameraRig아래에 있는 Controller의 위치   

    //애니메이션
    private Animator anim;
    private int hashIsGrabVer; // 그립 파라미터
    private int hashIsFinger;  // 포인트 손가락 파라미터

    private GameObject collidingObject; //현재 충돌중인 객체
    private GameObject objectInHand;    //플레이어가 잡은 객체
    private FixedJoint fx;

    private void Start()
    {
        fx = gameObject.GetComponent<FixedJoint>();

        //controller의 Transform 추출
        tr = GetComponent<Transform>();

        //애니메이터 컨트롤러 추출
        anim = tr.GetComponentInChildren<Animator>(); //첫번째 자식 오브젝트의 animator 컴포넌트 추출 

        //애니메이터 파라미터의 해시값을 추출해 저장
        hashIsGrabVer = Animator.StringToHash("GrabVer");
        hashIsFinger = Animator.StringToHash("Finger");

    }

    // Update is called once per frame
    void Update()
    {
        //그랩그립을 누를 때
        if (grip.GetStateDown(handType))
        {
            GripAnimOn();
            Debug.Log("난 지금 눌렀어");

            if (collidingObject)
            {
                GrabObject();
            }
        }

        //그랩그립을 뗄 때
        if (grip.GetStateUp(handType))
        {
            GripAnimOff();
            Debug.Log("난 지금 뗐어");
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        //트리거 누를 떄
        if (trigger.GetStateDown(handType))
        {
            FingerAnimOn();
            Debug.Log("손가락이 접혀요");
        }

        //트리거 뗄 때
        if (trigger.GetStateUp(handType))
        {
            FingerAnimOff();
            Debug.Log("손가락이 펴져요");
        }
    }
    public void GripAnimOn()
    {
        Debug.Log("주먹을 쥐세요");
        anim.SetBool(hashIsGrabVer, true); //그립 눌렀을 시 grabver값 true = 잡는 애니메이션 실행해라
    }

    public void GripAnimOff()
    {
        Debug.Log("주먹을 펴세요");
        anim.SetBool(hashIsGrabVer, false); //그립 뗐을 시 grabver값 = false = 잡는 애니메이션 꺼라
    }

    public void FingerAnimOn()
    {
        anim.SetBool(hashIsFinger, true);
    }

    public void FingerAnimOff()
    {
        anim.SetBool(hashIsFinger, false);
    }

    public void HapticOn()
    {
        haptic.Execute(0.2f, 0.2f, 50.0f, 0.5f, (handType));
    }

    //콜라이더 충돌이 시작되는 순간
    public void OnTriggerEnter(Collider other) //충돌감지 콜백함수 
    {
        //collidingObject = other.gameObject; 이게 굳이 필요한가?? 왜 써준거지??
        SetCollidingObject(other);
    }
    //충돌 중
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    //충돌이 끝날 때
    public void OnTriggerExit(Collider other) //충돌 상태에서 빠져 나왔을 때, 1회 자동 호출
    {
        collidingObject = null;
    }

    //충돌중인 객체로 설정
    public void SetCollidingObject(Collider col)
    {
        if (collidingObject != null || !col.GetComponent<Rigidbody>())  //collidingObject를 2개 잡지 않기 위해 || rigidbody가 없는 object는 충돌객체로 인식x
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    //객체 잡기
    public void GrabObject()
    {
        objectInHand = collidingObject; //잡은 객체로 설정
        collidingObject = null; //충돌 객체 해제


        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

    }
    //FixedJoint = 객체들을 하나로 묶어 고정 시킴
    //breakForce = 조인트가 제거되기 위해 필요한 힘의 크기
    //breakTorque = 조인트가 제거되기 위해 필요한 토크

    private FixedJoint AddFixedJoint()
    {
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    //객체를 놓음
    //controllerPose.GetVelocity() = 컨트롤러의 속도
    //controllerPose.GetAngularVelocity() = 컨트롤러의 각속도
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            //Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity =
                controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity =
                controllerPose.GetAngularVelocity();
        }
        objectInHand = null;
    }
}