using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimJam_UIFitter : MonoBehaviour
{
    private enum FitterSettings
    {
        Vertical,
        Horizontal,
        Both
    }

    [SerializeField] private FitterSettings fittingOption;
    [SerializeField] private float horizontalPadding;
    [SerializeField] private float verticalPadding;

    public JimJam_UIFitListener lastUsedListener;

    public void ResizeObject(RectTransform t)
    {
        RectTransform rect = GetComponent<RectTransform>();
        var incSize = t.sizeDelta;
        Vector2 newSize = rect.sizeDelta;
        switch (fittingOption)
        {
            case FitterSettings.Vertical:
                newSize.y = incSize.y + verticalPadding;
                break;
            case FitterSettings.Horizontal:
                newSize.x = incSize.x + horizontalPadding;
                break;
            case FitterSettings.Both:
                newSize.y = incSize.y + verticalPadding;
                newSize.x = incSize.x + horizontalPadding;
                break;
        }

        rect.sizeDelta = new Vector2(newSize.x, newSize.y);
    }

    void ResizeObject(JimJam_UIFitListener l)
    {
        ResizeObject(l.gameObject.GetComponent<RectTransform>());
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if(lastUsedListener != null)
            ResizeObject(lastUsedListener);
    }
#endif
    
}
