using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour, IPointerDownHandler
{
    Image OriginalImage;         // ������ �����ϴ� �̹���
    Sprite ChangedSprite;     // �ٲ���� �̹���

    // Start is called before the first frame update
    void Start()
    {
        OriginalImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage(Sprite image)
    {

        OriginalImage.sprite = image;       // OriginalImage�� �̹����� ChangedSprite �� �̹����� ����
    }

    public void RestoreImage(Sprite image)
    {
        ChangedSprite = OriginalImage.sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {


        // throw new System.NotImplementedException();
    }
}
