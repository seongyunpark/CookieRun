using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
    public float ScreenWidth;

    [SerializeField] [Range(1f, 20f)] float speed = 1.0f;          // 
    // [SerializeField] float posValue;                            // 스크롤 할 오브젝트의 최대길이 ( 이 값을 지나면 오브젝트의 위치 이동, 반복되도록 )

    // Vector2 StartPos;
    // float NewPos;

    // public GameObject BGImage;


    // Start is called before the first frame update
    void Start()
    {
        // 시작위치는 현재 오브젝트의 위치
        // StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 일정 범위 내에서 값을 반복시키고 싶을 때 사용
        // NewPos = Mathf.Repeat(Time.time * speed, posValue);     // ( 반복시킬 시간, 오브젝트의 최대길이)
        // transform.position = StartPos + Vector2.left * NewPos;  // 
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(this.transform.position.x <= -ScreenWidth)
        {
            this.Reposition();
        }
    }  

    private void Reposition()
    {
        Vector2 offset = new Vector2(this.ScreenWidth * 2, 0);
        this.transform.position = (Vector2)this.transform.position + offset;
    }
}
