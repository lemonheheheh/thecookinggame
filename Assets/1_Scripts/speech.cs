using System;
using UnityEngine;
using TMPro;
using System.Collections;


public class Speech : MonoBehaviour
{
    private IEnumerator coroutine;
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

    void Start(){
        Setup("meow");
        coroutine = WaitAndPrint(3.0f);
        StartCoroutine(coroutine);


    }
    
    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Setup("");
    }

    void Setup(string text)
    {
        if (!textMeshPro) return;

        textMeshPro.SetText(text);
    }
}