using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.08.05 Mang
/// 
/// 펫이 행동할 모든 함수를 담을 스크립트
/// 쿠키 따라 움직이기, 일정시간마다 앞으로 나가서 초코젤리 만들기, 
/// 
/// </summary>
public class Pet : MonoBehaviour
{
    Transform targetCookieTransform;

    private float relativeHeigth = -0.1f;    // 높이 y값
    private float zDistance = -1.0f;         // z값
    private float xDistance = -1.0f;         // x값
    public float dampSpeed = 2;              // 펫이 쿠키를 따라가게 할 속도. 숫자가 적을수록 쿠키와 같이 움직인다

    // Start is called before the first frame update
    void Start()
    {
        targetCookieTransform = GameObject.Find("BraveCookie").transform;       // 쿠키의 위치 받기
    }

    // Update is called once per frame
    void Update()
    {
        FollowCookie();
    }

    /// <summary>
    /// 펫이 캐릭터를 따라다니는 함수
    /// </summary>
    public void FollowCookie()
    {
        Vector3 newPos = targetCookieTransform.position + new Vector3(xDistance, relativeHeigth, -zDistance);       // 타겟쿠키 주변에 위치할 위치를 담는다. 일정거리 구하는 방법
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);                  // 그 둘 사이의 값을 더해 보정. 멀어지면 따라간다
    }

}
