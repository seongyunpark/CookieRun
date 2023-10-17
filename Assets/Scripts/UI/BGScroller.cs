using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
    public float ScreenWidth;

    [SerializeField] [Range(1f, 20f)] float speed = 1.0f;          // 
    // [SerializeField] float posValue;                            // ��ũ�� �� ������Ʈ�� �ִ���� ( �� ���� ������ ������Ʈ�� ��ġ �̵�, �ݺ��ǵ��� )

    // Vector2 StartPos;
    // float NewPos;

    // public GameObject BGImage;


    // Start is called before the first frame update
    void Start()
    {
        // ������ġ�� ���� ������Ʈ�� ��ġ
        // StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ������ ���� �ݺ���Ű�� ���� �� ���
        // NewPos = Mathf.Repeat(Time.time * speed, posValue);     // ( �ݺ���ų �ð�, ������Ʈ�� �ִ����)
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
