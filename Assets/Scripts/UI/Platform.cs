using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 22.08.07 Mang
/// 
/// 플랫폼에 관련된 모든 것을 담을 스크립트
/// 1. 우선은 맵을 다 만들고 그냥 이동시키도록 한다
/// 2. 문제없이 플레이가 된다면 데이터 관리를 해보도록 하자 ( 맵이 엄청 길다면? 데이터 관리를 해줘야 최적화가 되기 때문에 ? )
/// </summary>
public class Platform : MonoBehaviour
{
    public float speed;         // 플랫폼을 이동시키기 위해 설정할 스피드값
    private float offset;       // 스피드 * 델타타임
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    // 플랫폼 해야 할 것 : 카메라 안에 들어오면 랜더, 아닐 땐 그리지 않기
    
    /// <summary>
    /// 플랫폼을 이동시켜 줄 함수
    /// 
    /// </summary>
    public void MovePlatform()
    {
        offset = Time.deltaTime * speed;       // deltaTime * speed 를 해서 offset 값을 설정한다
        transform.Translate(-offset, 0, 0);     // offset 앞에 - 를 붙여준 이유는? 플랫폼이 오른쪽에서 왼쪽으로 이동하게 할 것이기 때문에 - 를 붙여줌
    }

}
