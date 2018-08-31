using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ColoringAnimalController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image outlineImage;
    public Image coloredImage;
    private bool coloring;
    private Color[] outlineImagePixels;
    public int radius;
    private Vector2 touchPos;
    public GraphicRaycaster ray;

    private void Awake()
    {
        coloring = false;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (coloring)
        {
            UpdateTexture();
        }
    }

    public void AssignSprites(Sprite outlineSprite, Sprite coloredSprite)
    {
        if (coloredImage == null) coloredImage = GetComponent<Image>();
        outlineImage.sprite = outlineSprite;
        coloredImage.sprite = coloredSprite;
        outlineImagePixels = outlineImage.sprite.texture.GetPixels();
    }

    public Texture2D CopyTexture2D(Texture2D copiedTexture2D)
    {
        float differenceX;
        float differenceY;

        //Create a new Texture2D, which will be the copy
        Texture2D texture = new Texture2D(copiedTexture2D.width, copiedTexture2D.height);

        //Choose your filtermode and wrapmode
        texture.filterMode = FilterMode.Trilinear;
        texture.wrapMode = TextureWrapMode.Clamp;
        Vector3 viewportMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Center of hit point circle 
        int m1 = (int)((viewportMousePos.x + 2.5f) / 5 * copiedTexture2D.width);
        int m2 = (int)((viewportMousePos.y + 2.5f) / 5 * copiedTexture2D.height);

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                differenceX = x - m1;
                differenceY = y - m2;

                if (differenceX * differenceX + differenceY * differenceY <= radius * radius)
                {
                    //This line of code and if statement, turn all texture pixels within radius to zero alpha
                    texture.SetPixel(x, y, new Color(0, 0, 0, 0));
                }
                else
                {
                    //This line of code is REQUIRED. Do NOT delete it. This is what copies the image as it was, without any change
                    texture.SetPixel(x, y, copiedTexture2D.GetPixel(x, y));
                }
            }
        }
        
        //This finalizes it. If you want to edit it still, do it before you finish with Apply(). Do NOT expect to edit the image after you have applied.
        texture.Apply();
        return texture;
    }

    public void UpdateTexture()
    {
        Texture2D newTexture2D = CopyTexture2D(outlineImage.sprite.texture);
        string tempName = outlineImage.sprite.name;
        outlineImage.sprite = Sprite.Create(newTexture2D, outlineImage.sprite.rect, new Vector2(0.5f, 0.5f));
        outlineImage.sprite.name = tempName;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        coloring = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        coloring = false;
        DispatchColoringFinishedEvent();
        DispatchMainViewRequestEvent();
    }

    private void DispatchMainViewRequestEvent()
    {
        CodeControl.Message.Send(new MainViewRequestEvent());
    }

    private void DispatchColoringFinishedEvent()
    {
        CodeControl.Message.Send(new ColoringFinishedEvent());
    }
}
