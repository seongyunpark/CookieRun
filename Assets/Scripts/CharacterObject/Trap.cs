using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 22.08.07 Mang
/// 
/// ������ ���õ� ��� ���� ���� ��ũ��Ʈ
/// </summary>
public class Trap : MonoBehaviour
{
    public float speed;         // ������ �̵���Ű�� ���� ������ ���ǵ尪
    private float offset;       // ���ǵ� * ��ŸŸ��

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
    /// ������ �̵����� �� �Լ�
    /// </summary>
    public void MoveTrap()
    {
        offset = Time.deltaTime * speed;       // deltaTime * speed �� �ؼ� offset ���� �����Ѵ�
        transform.Translate(-offset, 0, 0);
    }
}
