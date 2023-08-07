using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Action<float> ValueChanged;

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI min;
    [SerializeField] TextMeshProUGUI max;
    [SerializeField] TextMeshProUGUI now;
    void Awake()
    {
        min.text = slider.minValue.ToString();
        max.text = slider.maxValue.ToString();
        now.text = slider.minValue.ToString();
        slider.value = 1;

        slider.onValueChanged.AddListener( HandleOnValueChange);
    }

    private void HandleOnValueChange(float value)
    {
        now.text = slider.value.ToString();
        ValueChanged?.Invoke(value);
    }
    
    public float GetValue()
    {
        return slider.value;
    }

    public float GetRandomValue()
    {
        return UnityEngine.Random.Range(slider.minValue, slider.maxValue);
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }
}
