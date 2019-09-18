using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabObjectController : MonoBehaviour
{

    //입력 소스 정의
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grip; //= SteamVR_Input.GetBooleanAction("GrabGrip");
    public SteamVR_Action_Boolean trigger;

    private GameObject collidingObject; //현재 충돌중인 객체
    private GameObject objectInHand;    //플레이어가 잡은 객체

    private FixedJoint fx;

    private void Start()
    {
       fx =  gameObject.GetComponent<FixedJoint>();
    }
    // Update is called once per frame
    void Update()
    {
        //그랩그립을 누를 때
        if (grip.GetStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        //그랩그립을 뗄 때U
        if (grip.GetStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

    //충돌이 시작되는 순간
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        collidingObject = other.gameObject;
    }
    //충돌 중
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    //충돌이 끝날 때
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        collidingObject = null; //null 설정 안하면 어떻게 되는거지?
    }

    //충돌중인 객체로 설정
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
           // return;
        }

        collidingObject = col.gameObject;
    }

    //객체 잡기
    private void GrabObject()
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
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity =
                controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity =
                controllerPose.GetAngularVelocity();
        }
        objectInHand = null;
    }
}
