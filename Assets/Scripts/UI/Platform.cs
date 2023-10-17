using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 22.08.07 Mang
/// 
/// �÷����� ���õ� ��� ���� ���� ��ũ��Ʈ
/// 1. �켱�� ���� �� ����� �׳� �̵���Ű���� �Ѵ�
/// 2. �������� �÷��̰� �ȴٸ� ������ ������ �غ����� ���� ( ���� ��û ��ٸ�? ������ ������ ����� ����ȭ�� �Ǳ� ������ ? )
/// </summary>
public class Platform : MonoBehaviour
{
    public float speed;         // �÷����� �̵���Ű�� ���� ������ ���ǵ尪
    private float offset;       // ���ǵ� * ��ŸŸ��
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    // �÷��� �ؾ� �� �� : ī�޶� �ȿ� ������ ����, �ƴ� �� �׸��� �ʱ�
    
    /// <summary>
    /// �÷����� �̵����� �� �Լ�
    /// 
    /// </summary>
    public void MovePlatform()
    {
        offset = Time.deltaTime * speed;       // deltaTime * speed �� �ؼ� offset ���� �����Ѵ�
        transform.Translate(-offset, 0, 0);     // offset �տ� - �� �ٿ��� ������? �÷����� �����ʿ��� �������� �̵��ϰ� �� ���̱� ������ - �� �ٿ���
    }

}
