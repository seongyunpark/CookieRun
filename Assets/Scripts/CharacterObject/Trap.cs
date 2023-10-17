using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 22.08.07 Mang
/// 
/// 함정에 관련된 모든 것을 담을 스크립트
/// </summary>
public class Trap : MonoBehaviour
{
    public float speed;         // 함정을 이동시키기 위해 설정할 스피드값
    private float offset;       // 스피드 * 델타타임

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTrap();
    }

    /// <summary>
    /// 함정을 이동시켜 줄 함수
    /// </summary>
    public void MoveTrap()
    {
        offset = Time.deltaTime * speed;       // deltaTime * speed 를 해서 offset 값을 설정한다
        transform.Translate(-offset, 0, 0);
    }
}
