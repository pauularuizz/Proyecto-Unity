using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    Slider _slider;
    public Gradient MyGradient;
    public Image FillImage;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();

    }
    private void OnEnable()
    {
        HealthSystem.PlayerHealthChange += SetValue;
    }
    private void OnDisable()
    {
        HealthSystem.PlayerHealthChange -= SetValue;
    }

    void SetValue(float f)
    {
        _slider.value = f;

        Color color = MyGradient.Evaluate(f);
        FillImage.color = color;
    }
}
