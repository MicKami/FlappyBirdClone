using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScrolling : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Material mat;

    [SerializeField]
    private float scrollSpeed;
    private float uvOffset;
    private int scroll = 1;


    private void Awake()
    {
        mat = spriteRenderer.sharedMaterial;
    }

    private void LateUpdate()
    {
        uvOffset += Time.deltaTime * scrollSpeed * scroll;
        mat.SetFloat("_UV_Offset", uvOffset);
    }

    public void StopScrolling()
    {
        scroll = 0;
    }
}
