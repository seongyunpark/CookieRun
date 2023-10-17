using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public float speed;         // 함정을 이동시키기 위해 설정할 스피드값
    private float offset;       // 스피드 * 델타타임

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
        MoveJelly();
    }

    /// <summary>
    /// 젤리를 이동시켜 줄 함수
    /// </summary>
    public void MoveJelly()
    {
        offset = Time.deltaTime * speed;       // deltaTime * speed 를 해서 offset 값을 설정한다
        transform.Translate(-offset, 0, 0);
    }

    /// <summary>
    /// 플레이어가 젤리를 만났을 때 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Audio.PlayOneShot(audioClip);                       // 
            Audio.Play();                       // 

            // this.gameObject.SetActive(false);                // 
            SpriteRender.enabled = false;
            CircleCol.enabled = false;

        }
    }
}
