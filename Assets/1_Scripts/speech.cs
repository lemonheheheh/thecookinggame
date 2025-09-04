using System;
using UnityEngine;
using TMPro;

public class Speech : MonoBehaviour
{
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();

        if (textMeshPro != null)
        {
            Debug.Log("Found TMP component. Text = " + textMeshPro.text);
        }
        else
        {
            Debug.LogError("❌ TextMeshPro (3D) component NOT found in children!");
        }
    }

    void Start()
    {
        Setup("meow");
    }

    void Setup(string text)
    {
        if (!textMeshPro) return;

        textMeshPro.SetText(text);
    }
}