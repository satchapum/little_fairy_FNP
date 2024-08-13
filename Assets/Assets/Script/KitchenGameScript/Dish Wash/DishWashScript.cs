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
    private float dirtAmount;
    public float dirtAmountPercentage;

    [Header("From other gameobject")]
    [SerializeField] private SpongeRayCast spongeRayCast;

    private void Awake()
    {
        CreateTexture();

        dirtAmountTotal = CalculateDirtAmount(_dirtMaskBase);
        dirtAmount = dirtAmountTotal;

        // Update dirtAmountPercentage periodically
        FunctionPeriodic.Create(() => {
            dirtAmountPercentage = GetDirtAmount() * 100f;
        }, .03f);
    }

    private void Update()
    {
        if (spongeRayCast.IsHit && spongeRayCast.hitObject == this.gameObject)
        {
            Vector2 textureCoord = spongeRayCast.hitOut.textureCoord;

            int pixelX = Mathf.FloorToInt(textureCoord.x * _templateDirtMask.width);
            int pixelY = Mathf.FloorToInt(textureCoord.y * _templateDirtMask.height);

            ApplyBrush(pixelX, pixelY);
        }
    }

    private void ApplyBrush(int pixelX, int pixelY)
    {
        int brushHalfWidth = _brush.width / 2;
        int brushHalfHeight = _brush.height / 2;

        // Calculate the area of the brush on the texture
        int startX = Mathf.Clamp(pixelX - brushHalfWidth, 0, _templateDirtMask.width);
        int startY = Mathf.Clamp(pixelY - brushHalfHeight, 0, _templateDirtMask.height);
        int endX = Mathf.Clamp(pixelX + brushHalfWidth, 0, _templateDirtMask.width);
        int endY = Mathf.Clamp(pixelY + brushHalfHeight, 0, _templateDirtMask.height);

        int brushStartX = startX - (pixelX - brushHalfWidth);
        int brushStartY = startY - (pixelY - brushHalfHeight);

        int width = endX - startX;
        int height = endY - startY;

        Color[] dirtMaskPixels = _templateDirtMask.GetPixels(startX, startY, width, height);
        Color[] brushPixels = _brush.GetPixels(brushStartX, brushStartY, width, height);

        for (int i = 0; i < brushPixels.Length; i++)
        {
            float removedAmount = dirtMaskPixels[i].g * (1 - brushPixels[i].g);
            dirtAmount -= removedAmount;
            dirtMaskPixels[i].g *= brushPixels[i].g;  // Update green channel to represent dirt amount
        }

        _templateDirtMask.SetPixels(startX, startY, width, height, dirtMaskPixels);
        _templateDirtMask.Apply();
    }


    private void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        _material.SetTexture("_DirtMask", _templateDirtMask);
    }

    private float GetDirtAmount()
    {
        return dirtAmount / (dirtAmountTotal);
    }

    private float CalculateDirtAmount(Texture2D texture)
    {
        float total = 0f;
        Color[] pixels = texture.GetPixels();

        foreach (var pixel in pixels)
        {
            total += pixel.g;
        }

        return total;
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