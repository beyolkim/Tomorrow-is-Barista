using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine : MonoBehaviour
{
    float totalTime; // 총 시간 재기
    public Slider timeSlider;

    public Text stateText;

    public float expressionTime;
    public float espressoTime;
    public float capuccinoTime;
    public float cleaningTime;
    public float oneMinuteWarningTime;
    public float timeOverTime;


    // Start is called before the first frame update
    void Start()
    {
        totalTime = 0;

        expressionTime = 0;
        espressoTime = 40;
        capuccinoTime = 180;
        cleaningTime = 510;
        oneMinuteWarningTime = 600;
        timeOverTime = 660;

        timeChangeState = TimeChange.EXPRESSION;

    }

    public enum TimeChange // 상태 변화
    {
        EXPRESSION,
        ESPRESSO,
        CAPUCCINO,
        CLEANING,
        ONEMINUTEWARNING,
        TIMEOVER
    }

    TimeChange timeChangeState;

    // Update is called once per frame
    void Update()
    {
        switch (timeChangeState) // 상태 변환
        {
            case TimeChange.EXPRESSION:
                startExpression();
                break;

            case TimeChange.ESPRESSO:
                startEspresso();
                break;

            case TimeChange.CAPUCCINO:
                startCapuccino();
                break;

            case TimeChange.CLEANING:
                startCleaning();
                break;

            case TimeChange.ONEMINUTEWARNING:
                startWarning();
                break;

            case TimeChange.TIMEOVER:
                startTimeOver();
                break;

        }

        totalTime += Time.deltaTime; // 시간이 지남에 따라 증가 
        timeSlider.value = totalTime; // 슬라이더 증가

        if (totalTime >= espressoTime) // 40초 후 에스프레소로 상태 변환
        {
            timeChangeState = TimeChange.ESPRESSO;
        }

        if (totalTime >= capuccinoTime) // 180초 후 카푸치노로 상태 변환
        {
            timeChangeState = TimeChange.CAPUCCINO;
        }
        if (totalTime >= cleaningTime) // 510초 후 정리로 상태 변환
        {
            timeChangeState = TimeChange.CLEANING;
        }
        if (totalTime >= oneMinuteWarningTime) // 600초 후 경고로 상태 변환
        {
            timeChangeState = TimeChange.ONEMINUTEWARNING;
        }
        if (totalTime >= timeOverTime) // 총 시간이 660초를 넘는다면
        {
            totalTime = 660f; // 660으로 고정
            timeChangeState = TimeChange.TIMEOVER;
        }

    }


    public void startExpression()
    {
        stateText.text = ("시작 멘트 시간입니다.");
    }
    public void startEspresso()
    {
        stateText.text = ("에스프레소 4잔을 만들어 주세요.");
    }
    private void startCapuccino()
    {
        stateText.text = ("카푸치노 4잔을 만들어 주세요.");
    }
    private void startCleaning()
    {
        stateText.text = ("뒷정리를 해주세요.");
    }
    public void startWarning()
    {
        stateText.text = ("1분 남았습니다.");
    }
    private void startTimeOver()
    {
        stateText.text = ("끝났습니다.");
    }




}
