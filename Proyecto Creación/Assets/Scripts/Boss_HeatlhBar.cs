using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HeatlhBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

  

    void Start()
    {
        
    }

    // Update is called once per frame
    
    
    
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }


    public void SetHealth(float heatlh, float maxHealth)
    {
        Slider.gameObject.SetActive(heatlh < maxHealth);
        Slider.value = heatlh;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponent<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue); 
    }
}
