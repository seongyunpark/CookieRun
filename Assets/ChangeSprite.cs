using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour, IPointerDownHandler
{
    Image OriginalImage;         // 기존에 존재하는 이미지
    Sprite ChangedSprite;     // 바뀌어질 이미지

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

        OriginalImage.sprite = image;       // OriginalImage의 이미지를 ChangedSprite 의 이미지로 변경
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
