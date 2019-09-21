using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    Renderer rend;
    Vector3 lastPos;
    Vector3 velocity;
    Vector3 lastRot;
    Vector3 angularVelocity;


    public float fillpersent; // 채워지는 값 쉐이더에서 가져왔음

    float parent_RotX;
    float reslut_RotX;

    public float MaxWobble = 0.03f;
    public float WobbleSpeed = 1f;
    public float Recovery = 1f;
    float wobbleAmountX;
    float wobbleAmountZ;
    float wobbleAmountToAddX;
    float wobbleAmountToAddZ;
    float pulse;
    float time = 0.5f;

    // Use this for initialization
    void Start()
    {
        
        rend = GetComponent<Renderer>();
    }
    private void Update()
    {
        //MaxWobble = Mathf.PingPong(time*2, 6f);
        //MaxWobble = Mathf.Lerp(-3, 3, Mathf.PingPong(Time.time, 3f));

        //fillpersent = Mathf.Lerp(-0.8f, -0.1f, Time.time*0.1f); // 채워지는 함수

        reslut_RotX =Mathf.Lerp(gameObject.transform.parent.transform.eulerAngles.x, 150, 0.1f);
        //Debug.Log(reslut_RotX);
        time += Time.deltaTime;

        // decrease wobble over time
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * (Recovery));
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * (Recovery));

        // make a sine wave of the decreasing wobble
        pulse = 2 * Mathf.PI * WobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        // send it to the shader
        rend.material.SetFloat("_WobbleX", wobbleAmountX);
        rend.material.SetFloat("_WobbleZ", wobbleAmountZ);

        //fillpersent 추가
        rend.material.SetFloat("_FillAmount", fillpersent);

        // velocity
        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;


        // add clamped velocity to wobble
        wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);
        wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);

        // keep last position
        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;



    }

    public void Espresso_Fill()
    {
        fillpersent = Mathf.Lerp(1f, -0.12f, Time.time*0.05f); // 채워지는 함수

    }

}