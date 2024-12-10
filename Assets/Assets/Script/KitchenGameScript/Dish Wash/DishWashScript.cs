using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;

public class DishWashScript : MonoBehaviour
{
    [Header("In this game object")]
    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;

    [SerializeField] private Material _material;
    [SerializeField] public bool isClean;
    [SerializeField] public bool isFinish;
    [SerializeField] public bool isDishOnGrab;
    //[SerializeField] TMP_Text Showpercentage;


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

        FunctionPeriodic.Create(() => {
            dirtAmountPercentage = GetDirtAmount() * 100f;
            if (Mathf.RoundToInt(GetDirtAmount() * 100f) <= 15)
            {
                isClean = true;
                //Showpercentage.text = "Finish";
            }
            else
            {
                //Showpercentage.text = Mathf.RoundToInt(GetDirtAmount() * 100f) + "%";
            }
        }, .03f);
    }

    private void Update()
    {
        if (spongeRayCast.isHit && spongeRayCast.hitObject == this.gameObject)
        {
            Debug.Log("Do delete texture");
            Vector2 textureCoord = spongeRayCast.hitOut.textureCoord;

            int pixelX = Mathf.FloorToInt(textureCoord.x * _templateDirtMask.width);
            int pixelY = Mathf.FloorToInt(textureCoord.y * _templateDirtMask.height);

            ApplyBrush(pixelX, pixelY);
        }
    }

    public void SetStatusToClean()
    {
        isFinish = true;
    }

    public void SetBookOnGrab()
    {
        isDishOnGrab = true;
    }

    public void SetBookIsNotOnGrab()
    {
        isDishOnGrab = false;
    }

    private void ApplyBrush(int pixelX, int pixelY)
    {
        Debug.Log($"Applying brush at PixelX: {pixelX}, PixelY: {pixelY}");

        // Half-width and height of the brush
        int brushHalfWidth = _brush.width / 2;
        int brushHalfHeight = _brush.height / 2;
        Debug.Log($"Brush Half Width: {brushHalfWidth}, Brush Half Height: {brushHalfHeight}");

        // Calculate start and end positions for the brush application
        int startX = Mathf.Clamp(pixelX - brushHalfWidth, 0, _templateDirtMask.width);
        int startY = Mathf.Clamp(pixelY - brushHalfHeight, 0, _templateDirtMask.height);
        int endX = Mathf.Clamp(pixelX + brushHalfWidth, 0, _templateDirtMask.width);
        int endY = Mathf.Clamp(pixelY + brushHalfHeight, 0, _templateDirtMask.height);

        Debug.Log($"StartX: {startX}, StartY: {startY}, EndX: {endX}, EndY: {endY}");

        // Calculate brush start offsets
        int brushStartX = startX - (pixelX - brushHalfWidth);
        int brushStartY = startY - (pixelY - brushHalfHeight);
        Debug.Log($"Brush StartX: {brushStartX}, Brush StartY: {brushStartY}");

        // Calculate the width and height of the area to modify
        int width = endX - startX;
        int height = endY - startY;
        Debug.Log($"Width: {width}, Height: {height}");

        // Debug texture sizes and ensure they are readable
        if (!_templateDirtMask.isReadable)
        {
            Debug.LogError("_templateDirtMask is not readable. Ensure 'Read/Write Enabled' is checked.");
            return;
        }
        if (!_brush.isReadable)
        {
            Debug.LogError("_brush is not readable. Ensure 'Read/Write Enabled' is checked.");
            return;
        }

        // Get pixels from the mask and brush
        try
        {
            Color[] dirtMaskPixels = _templateDirtMask.GetPixels(startX, startY, width, height);
            Color[] brushPixels = _brush.GetPixels(brushStartX, brushStartY, width, height);

            Debug.Log($"Dirt Mask Pixels: {dirtMaskPixels.Length}, Brush Pixels: {brushPixels.Length}");

            // Modify the pixels based on the brush
            for (int i = 0; i < brushPixels.Length; i++)
            {
                float removedAmount = dirtMaskPixels[i].g * (1 - brushPixels[i].g);
                dirtAmount -= removedAmount;
                dirtMaskPixels[i].g *= brushPixels[i].g;
            }

            // Set the modified pixels back to the texture
            _templateDirtMask.SetPixels(startX, startY, width, height, dirtMaskPixels);
            _templateDirtMask.Apply();
            Debug.Log("Brush applied successfully and texture updated.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error applying brush: {ex.Message}");
        }
    }


    private void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        _material.SetTexture("_DirtMask", _templateDirtMask);
        Debug.Log("Create texture complete");
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