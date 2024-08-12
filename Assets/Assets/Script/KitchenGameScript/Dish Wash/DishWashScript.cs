/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishWashScript : MonoBehaviour
{
    [Header("In this game object")]
    [SerializeField] Texture2D dirtMaskBase;
    [SerializeField] Texture2D brush;

    [SerializeField] Material material;

    [Header("From other gameobject")]
    [SerializeField] SpongeRayCast spongeRayCast;

    Texture2D templateDirtMask;

    void Start()
    {
        CreateTexture();
    }

    void Update()
    {
        if (spongeRayCast.IsHit && spongeRayCast.hitObject == this.gameObject)
        {
            Vector2 textureCoord = spongeRayCast.hitOut.textureCoord;

            int pixelX = (int)(textureCoord.x * templateDirtMask.width);
            int pixelY = (int)(textureCoord.y * templateDirtMask.height);

            Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);

            Debug.Log("UV: " + textureCoord + "; Pixels: " + paintPixelPosition);

            for (int x = 0; x < brush.width; x++)
            {
                for (int y = 0; y < brush.height; y++)
                {
                    Color pixelDirt = brush.GetPixel(x, y);
                    Color pixelDirtMask = templateDirtMask.GetPixel(pixelX + x, pixelY + y);

                    templateDirtMask.SetPixel(pixelX + x, pixelY + y, new Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                }
            }

            templateDirtMask.Apply();
        }
    }

    void CreateTexture()
    {
        templateDirtMask = new Texture2D(dirtMaskBase.width, dirtMaskBase.height);
        templateDirtMask.SetPixels(dirtMaskBase.GetPixels());
        templateDirtMask.Apply();

        material.SetTexture("DirtTexture", templateDirtMask);
    }
}*/
using System;
using UnityEngine;

public class DishWashScript : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;

    [SerializeField] private Material _material;

    private Texture2D _templateDirtMask;
    public int dirtAmountTotal = 0;
    private void Start()
    {
        CreateTexture();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Vector2 textureCoord = hit.textureCoord;
                Debug.Log(textureCoord);
                int pixelX = (int)(textureCoord.x * _templateDirtMask.width);
                int pixelY = (int)(textureCoord.y * _templateDirtMask.height);

                for (int x = 0; x < _brush.width; x++)
                {
                    for (int y = 0; y < _brush.height; y++)
                    {
                        Color pixelDirt = _brush.GetPixel(x, y);
                        Color pixelDirtMask = _templateDirtMask.GetPixel(pixelX + x, pixelY + y);

                        _templateDirtMask.SetPixel(pixelX + x,
                            pixelY + y,
                            new Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                    }
                }

                _templateDirtMask.Apply();

            }
        }
        dirtAmountTotal = 0;
        for (int x = 0;x < _dirtMaskBase.width; x++)
        {
            for(int y= 0; y< _dirtMaskBase.height; y++)
            {
                dirtAmountTotal += (int)_dirtMaskBase.GetPixel(x,y).g;
            }
        }

    }

    private void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        _material.SetTexture("DirtTexture", _templateDirtMask);
    }
}
