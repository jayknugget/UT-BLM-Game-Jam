using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimScreen : MonoBehaviour
{
    public static float lerpT = 0.05f;

    public int dimStart;
    public int dimEnd;
    public bool isDimming;

    private Image dimScreen;
    private bool oldDim;

    void Awake()
    {
        dimScreen = GetComponent<Image>();
    }

    public void DimIn()
    {
        Dim(dimEnd);
    }

    public void DimOut()
    {
        Dim(dimStart);
    }

    private void Dim(int iTarget)
    {
        if (!isDimming)
        {
            isDimming = true;
            StartCoroutine(DimChangeCoroutine(iTarget));
        }
    }

    IEnumerator DimChangeCoroutine(int iTarget)
    {
        Color dimColor = dimScreen.color;
        float lerpAlpha = dimScreen.color.a;
        float fTarget = (float)iTarget / 255;

        while (Mathf.Abs(lerpAlpha - fTarget) > 0.001)
        {
            lerpAlpha = Mathf.Lerp(lerpAlpha, fTarget, lerpT);
            Color newColor = new Color(dimColor.r, dimColor.g, dimColor.b, lerpAlpha);
            dimScreen.color = newColor;

            yield return new WaitForFixedUpdate();
        }

        isDimming = false;
    }
}
