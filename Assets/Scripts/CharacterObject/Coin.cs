using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;         // ������ �̵���Ű�� ���� ������ ���ǵ尪
    private float offset;       // ���ǵ� * ��ŸŸ��

    AudioSource Audio;
    // public AudioClip audioClip;

    SpriteRenderer SpriteRender;
    CircleCollider2D CircleCol;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();

        SpriteRender = GetComponent<SpriteRenderer>();
        CircleCol = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCoin();
    }

    /// <summary>
    /// ������ �������� �Լ�
    /// </summary>
    public void MoveCoin()
    {
        offset = Time.deltaTime * speed;       // deltaTime * speed �� �ؼ� offset ���� �����Ѵ�
        transform.Translate(-offset, 0, 0);
    }

    /// <summary>
    /// �÷��̾ ���������� ������ �� 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Audio.PlayOneShot(audioClip);                       // 
            Audio.Play();                       // 

            // this.gameObject.SetActive(false);                // 
            SpriteRender.enabled = false;
            CircleCol.enabled = false;

        }
    }
}
