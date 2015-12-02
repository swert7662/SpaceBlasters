using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class dropdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public RectTransform container;
    private bool isOpen = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update () {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale; 
	}
}
