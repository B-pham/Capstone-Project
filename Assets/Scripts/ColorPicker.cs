using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.EventSystems;

[Serializable]
public class ColorEvent : UnityEvent<Color> { }

public class ColorPicker : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI DebugText;
    public ColorEvent OnColorPreview;
    public ColorEvent OnColorSelect;

    public float max = 10f; //Failsafe value initially. Shouldn't ever change but :person_shrugging:

    RectTransform Rect;
    Texture2D ColorTexture;

    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();

        ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta;

        Vector2 mousePos = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

            
        string debug = "mousePosition=" + Input.mousePosition;
        debug += "<br>delta=" + delta;

        float width = Rect.rect.width;
        float height = Rect.rect.height;
        delta += new Vector2(width * .5f, height * .5f);
        debug += "<br>offset delta=" + delta;

        if (width <= height) { max = width; } //If we don't check the bounds of the color picker, we'll get some errors
        else { max = height; }                //We also can't guarantee they'll stay the same size, so we'll check on Update()


        float x = Mathf.Clamp(delta.x / width, 0f, max);
        float y = Mathf.Clamp(delta.y / height, 0f, max);
        debug += "<br>x=" + x + "y=" + y;

        int texX = Mathf.RoundToInt(x * ColorTexture.width);
        int texY = Mathf.RoundToInt(y * ColorTexture.height);
        debug += "<br>texX=" + texX + " texY=" + texY;

        Color color = ColorTexture.GetPixel(texX, texY);

        DebugText.color = color;

        DebugText.text = debug;
        if(RectTransformUtility.RectangleContainsScreenPoint(Rect, mousePos)){
           OnColorPreview?.Invoke(color); 
        }
            

        if(Input.GetMouseButtonDown(0) && delta.x > 0 && delta.x < width && delta.y > 0 && delta.y < height)
        {
            OnColorSelect?.Invoke(color);
        }              
          


    }

    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("Clicked Location:" + data.position);
        ColorChecker(data.position);
    }

    private void ColorChecker(Vector2 pos)
    {
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, pos, null, out delta);

        string debug = "mousePosition=" + Input.mousePosition;
        debug += "<br>delta=" + delta;

        float width = Rect.rect.width;
        float height = Rect.rect.height;
        delta += new Vector2(width * .5f, height * .5f);
        debug += "<br>offset delta=" + delta;

        if (width <= height) { max = width; } //If we don't check the bounds of the color picker, we'll get some errors
        else { max = height; }                //We also can't guarantee they'll stay the same size, so we'll check on Update()


        float x = Mathf.Clamp(delta.x / width, 0f, max);
        float y = Mathf.Clamp(delta.y / height, 0f, max);
        debug += "<br>x=" + x + "y=" + y;

        int texX = Mathf.RoundToInt(x * ColorTexture.width);
        int texY = Mathf.RoundToInt(y * ColorTexture.height);
        debug += "<br>texX=" + texX + " texY=" + texY;

        Color color = ColorTexture.GetPixel(texX, texY);

        DebugText.color = color;

        DebugText.text = debug;

        Debug.Log("Color: " + color.ToString());
    }
}
