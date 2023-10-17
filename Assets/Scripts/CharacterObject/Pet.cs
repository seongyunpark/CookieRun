using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.08.05 Mang
/// 
/// ���� �ൿ�� ��� �Լ��� ���� ��ũ��Ʈ
/// ��Ű ���� �����̱�, �����ð����� ������ ������ �������� �����, 
/// 
/// </summary>
public class Pet : MonoBehaviour
{
    Transform targetCookieTransform;

    private float relativeHeigth = -0.1f;    // ���� y��
    private float zDistance = -1.0f;         // z��
    private float xDistance = -1.0f;         // x��
    public float dampSpeed = 2;              // ���� ��Ű�� ���󰡰� �� �ӵ�. ���ڰ� �������� ��Ű�� ���� �����δ�

    // Start is called before the first frame update
    void Start()
    {
        targetCookieTransform = GameObject.Find("BraveCookie").transform;       // ��Ű�� ��ġ �ޱ�
    }

    // Update is called once per frame
    void Update()
    {
        FollowCookie();
    }

    /// <summary>
    /// ���� ĳ���͸� ����ٴϴ� �Լ�
    /// </summary>
    public void FollowCookie()
    {
        Vector3 newPos = targetCookieTransform.position + new Vector3(xDistance, relativeHeigth, -zDistance);       // Ÿ����Ű �ֺ��� ��ġ�� ��ġ�� ��´�. �����Ÿ� ���ϴ� ���
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);                  // �� �� ������ ���� ���� ����. �־����� ���󰣴�
    }

}
