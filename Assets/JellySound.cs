using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySound : MonoBehaviour
{
    AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// �÷��̾ ������ ������ �� 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Audio.Play();
        }
    }
}
