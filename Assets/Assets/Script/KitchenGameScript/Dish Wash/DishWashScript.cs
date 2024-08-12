using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class DishWashScript : MonoBehaviour
{
    [Header("In this game object")]
    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;

    [SerializeField] private Material _material;
    
    private Texture2D _templateDirtMask;
    private float dirtAmountTotal;
    public float dirtAmount;

    [Header("From other gameobject")]
    [SerializeField] SpongeRayCast spongeRayCast;


    void Awake()
    {
        CreateTexture();

        dirtAmountTotal = 0f;
        for (int x = 0; x < _dirtMaskBase.width; x++)
        {
            for (int y = 0; y < _dirtMaskBase.height; y++)
            {
                dirtAmountTotal += _dirtMaskBase.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;

        FunctionPeriodic.Create(() => {
            GetDirtAmount();
        }, .03f);
    }

    void Update()
    {
        if (spongeRayCast.IsHit && spongeRayCast.hitObject == this.gameObject)
        {
            Vector2 textureCoord = spongeRayCast.hitOut.textureCoord;
            Debug.Log(textureCoord);
            int pixelX = (int)(textureCoord.x * _templateDirtMask.width);
            int pixelY = (int)(textureCoord.y * _templateDirtMask.height);

            int pixelXOffset = pixelX - (_brush.width / 2);
            int pixelYOffset = pixelY - (_brush.height / 2);

            for (int x = 0; x < _brush.width; x++)
            {
                for (int y = 0; y < _brush.height; y++)
                {
                    Color pixelDirt = _brush.GetPixel(x, y);
                    Color pixelDirtMask = _templateDirtMask.GetPixel(pixelXOffset + x, pixelYOffset + y);

                    /*float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                    dirtAmount -= removedAmount;*/

                    _templateDirtMask.SetPixel(pixelXOffset + x,
                        pixelYOffset + y,
                        new Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                }
            }
                
            _templateDirtMask.Apply();
        }
    }

    void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        _material.SetTexture("_DirtMask", _templateDirtMask);
    }

    private float GetDirtAmount()
    {
        return this.dirtAmount / dirtAmountTotal;
    }

}

/*
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

                int pixelXOffset = pixelX - (_brush.width / 2);
                int pixelYOffset = pixelY - (_brush.height / 2);

                for (int x = 0; x < _brush.width; x++)
                {
                    for (int y = 0; y < _brush.height; y++)
                    {
                        Color pixelDirt = _brush.GetPixel(x, y);
                        Color pixelDirtMask = _templateDirtMask.GetPixel(pixelXOffset + x, pixelYOffset + y);

                        _templateDirtMask.SetPixel(pixelXOffset + x,
                            pixelYOffset + y,
                            new Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                    }
                }
                
                _templateDirtMask.Apply();
                
                dirtAmountTotal = 0;
                for (int x = 0; x < _dirtMaskBase.width; x++)
                {
                    for (int y = 0; y < _dirtMaskBase.height; y++)
                    {
                        dirtAmountTotal += (int)_dirtMaskBase.GetPixel(x, y).g;
                    }
                }
                
            }
        }

    }

    private void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        _material.SetTexture("_DirtMask", _templateDirtMask);
    }
}
*/