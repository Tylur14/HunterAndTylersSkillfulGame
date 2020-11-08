using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Parallax : MonoBehaviour
{
    public enum TransformType // By default it's used on transform, but GUI affects rectTransform
    {
        WorldSpace,
        GUI
    }
    [SerializeField] private TransformType transformType;
    private float _length, _startPos;
    [SerializeField] GameObject parentLead;
    [SerializeField] private float moveAmount;
    private RectTransform _rt;
    void Start()
    {
        _rt = GetComponent<RectTransform>();
        _startPos = _rt.anchoredPosition.y;
        _length = GetComponent<Image>().sprite.bounds.size.y;
    }
    void Update()
    {
        float dist;
        switch (transformType)
        {
                
            case TransformType.WorldSpace:
                //float temp = (_cam.transform.position.y * (1 - moveAmount));
                
                dist = (parentLead.transform.position.y * moveAmount);
                transform.position = new Vector3(transform.position.x, _startPos+dist, transform.position.z);
                
                // Disabling the looping portion because there appears to be some bugs.
                // if (temp > _startPos + _length) _startPos += _length;
                // else if (temp < _startPos - _length) _startPos -= _length;
                break;
            case TransformType.GUI:
                
                dist = (parentLead.transform.position.y * moveAmount);
                _rt.anchoredPosition = new Vector2(_rt.anchoredPosition.x, _startPos+dist);
                break;
        }
        
    }
}
