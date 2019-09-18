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
    public Text frontText;

    public float expressionTime = 40; //40.0f;
    public float espressoTime = 180; //140.0f;
    public float capuccinoTime = 510; //330.0f;
    public float cleaningTime = 600; //90.0f;
    //public float oneMinuteWarningTime = 60.0f;

    public TimeChange timeChangeState;

    public enum TimeChange // 상태 변화
    {
        EXPRESSION,
        ESPRESSO,
        CAPUCCINO,
        CLEANING,
        ONEMINUTEWARNING,
        TIMEOVER
    }

    // Start is called before the first frame update
    void Start()
    {
        timeChangeState = TimeChange.EXPRESSION;
        StartCoroutine(CheckTimeChange());
    }

    IEnumerator CheckTimeChange()
    {
        yield return StartCoroutine(startExpression());

        yield return StartCoroutine(startEspresso());

        yield return StartCoroutine(startCapuccino());

        yield return StartCoroutine(startCleaning());

        startTimeOver();

    }


    IEnumerator startExpression()
    {
        timeChangeState = TimeChange.EXPRESSION;
        stateText.text = ("시작 멘트 시간입니다.");
        frontText.text = ("시작을 선언해 주세요.");
        yield return new WaitForSeconds(3);
        frontText.text = ("문제를 풀어주세요.");
        yield return new WaitForSeconds(30);
        frontText.text = ("선택한 원두를 심사위원 테이블에 전달하세요.");
        yield return new WaitForSeconds(7);


    }
    IEnumerator startEspresso()
    {   
        timeSlider.value = expressionTime;

        timeChangeState = TimeChange.ESPRESSO;
        stateText.text = ("에스프레소 4잔을 만들어 주세요.");
   
        frontText.text = ("트레이에 4개의 컵받침과 스푼을 준비해 주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("그라인더를 사용해 포터필터에 분쇄원두를 담아주세요.");
        yield return new WaitForSeconds(19);
        frontText.text = ("검지를 이용해 원두를 레벨링해주세요.");
        yield return new WaitForSeconds(9);
        frontText.text = ("템퍼로 원두를 눌러주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("한번 더 그라인더를 사용해 포터필터에 분쇄원두를 담아주세요.");
        yield return new WaitForSeconds(19);
        frontText.text = ("검지를 이용해 원두를 레벨링해주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("템퍼로 원두를 눌러주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("버튼을 차례로 눌러 양 노즐의 물을 빼주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("버튼을 눌러 꺼주세요");
        yield return new WaitForSeconds(1);
        frontText.text = ("두 포터필터를 차례로 교합해 주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("4개의 에스프레소 잔을 놓아주세요");
        yield return new WaitForSeconds(7);
        frontText.text = ("추출 버튼을 차례로 눌러주세요."); // 이후 26초 후 추출 끄기
        yield return new WaitForSeconds(3);
        frontText.text = ("잠시 주변을 청소해 주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("추출이 끝나길 기다립니다.");
        yield return new WaitForSeconds(13);
        frontText.text = ("버튼을 눌러 추출을 꺼주세요.");
        yield return new WaitForSeconds(1);
        frontText.text = ("컵받침 위에 잔을 놓아주세요.");
        yield return new WaitForSeconds(11);
        frontText.text = ("쟁반을 들고 심사위원에게 서빙하세요.");
        yield return new WaitForSeconds(12);


    }

    IEnumerator startCapuccino()
    {
        timeSlider.value = espressoTime;

        timeChangeState = TimeChange.CAPUCCINO;
        stateText.text = ("카푸치노 4잔을 만들어 주세요.");

        frontText.text = ("트레이에 4개의 컵받침과 스푼을 준비해 주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("커피포터를 분리해 찌꺼기를 버려주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("커피포터를 린넨천으로 닦아주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("그라인더를 사용해 포터필터에 분쇄원두를 담아주세요.");
        yield return new WaitForSeconds(19);
        frontText.text = ("검지를 이용해 원두를 레벨링해주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("템퍼로 원두를 눌러주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("다른쪽 커피포터를 분리해 찌꺼기를 버려주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("커피포터를 린넨천으로 닦아주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("그라인더를 사용해 포터필터에 분쇄원두를 담아주세요.");
        yield return new WaitForSeconds(19);
        frontText.text = ("검지를 이용해 원두를 레벨링해주세요.");
        yield return new WaitForSeconds(9);
        frontText.text = ("템퍼로 원두를 눌러주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("버튼을 차례로 눌러 양 노즐의 물을 빼주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("버튼을 눌러 꺼주세요");
        yield return new WaitForSeconds(1);
        frontText.text = ("두 포터필터를 차례로 교합해 주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("4개의 카푸치노 잔을 놓아주세요"); 
        yield return new WaitForSeconds(7);
        frontText.text = ("추출 버튼을 차례로 눌러주세요."); // 이후 26초 추출 끄기
        yield return new WaitForSeconds(2);
        frontText.text = ("우유를 피처에 따라놓으세요.");
        yield return new WaitForSeconds(24);
        frontText.text = ("버튼을 눌러 추출을 멈추세요.");
        yield return new WaitForSeconds(1);
        frontText.text = ("스팀 천으로 감싼 후 버튼을 눌러 스팀을 빼주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("스팀으로 우유를 데워주세요.");
        yield return new WaitForSeconds(25);
        frontText.text = ("스팀 천으로 감싼 후 버튼을 눌러 스팀을 빼주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("우유를 카푸치노 잔에 부어주세요");
        yield return new WaitForSeconds(19);
        frontText.text = ("컵받침 위에 잔을 놓아주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("우유를 다른 카푸치노 잔에 부어주세요");
        yield return new WaitForSeconds(19);
        frontText.text = ("컵받침 위에 잔을 놓아주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("스팀 천으로 감싼 후 버튼을 눌러 스팀을 빼주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("스팀으로 우유를 데워주세요.");
        yield return new WaitForSeconds(25);
        frontText.text = ("스팀 천으로 감싼 후 버튼을 눌러 스팀을 빼주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("우유를 카푸치노 잔에 부어주세요");
        yield return new WaitForSeconds(20);
        frontText.text = ("컵받침 위에 잔을 놓아주세요.");
        yield return new WaitForSeconds(5);
        frontText.text = ("우유를 마지막 카푸치노 잔에 부어주세요");
        yield return new WaitForSeconds(20);
        frontText.text = ("컵받침 위에 잔을 놓아주세요.");
        yield return new WaitForSeconds(13);
        frontText.text = ("쟁반을 들고 심사위원에게 서빙하세요.");
        yield return new WaitForSeconds(12);

    }

    IEnumerator startCleaning()
    {
        timeSlider.value = capuccinoTime;

        timeChangeState = TimeChange.CLEANING;
        stateText.text = ("뒷정리를 해주세요.");

        frontText.text = ("커피포터를 빼내 찌꺼기를 버려주세요.");
        yield return new WaitForSeconds(6);
        frontText.text = ("버튼을 눌러 커피포터를 흐르는 물에 씻어주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("커피포터를 교합 상태로 두세요.");
        yield return new WaitForSeconds(1);
        frontText.text = ("다른 커피포터를 빼내 찌꺼기를 버려주세요.");
        yield return new WaitForSeconds(6);
        frontText.text = ("버튼을 눌러 커피포터를 흐르는 물에 씻어주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("커피포터를 교합 상태로 두세요.");
        yield return new WaitForSeconds(1);
        frontText.text = ("그라인더 가루를 빼내 주세요.");
        yield return new WaitForSeconds(8);
        frontText.text = ("붓으로 주변을 쓸어 가루를 통에 버려주세요.");
        yield return new WaitForSeconds(15);
        frontText.text = ("청소 수건으로 주변을 닦아주세요.");
        yield return new WaitForSeconds(20);
        frontText.text = ("수건을 제 위치에 놓아주세요.");
        yield return new WaitForSeconds(10);
        frontText.text = ("끝을 선언해 주세요.");
        yield return new WaitForSeconds(3);


    }
    private void startTimeOver()
    {   
        timeSlider.value = cleaningTime;

        timeChangeState = TimeChange.TIMEOVER;
        stateText.text = ("끝났습니다.");
        
    }


}
