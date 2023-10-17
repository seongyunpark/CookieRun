using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    Jelly _jelly;
    void Start()
    {
        _jelly = GetComponent<Jelly>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        _jelly.enabled = true;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
