using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;
    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == keyTemplate) continue;

            Destroy(child.gameObject);
            keyTemplate.gameObject.SetActive(false);

        }
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();

            switch (keyType)
            {   default:
                case Key.KeyType.Blue:
                    keyImage.color = Color.blue;
                    break;
                case Key.KeyType.Red:  
                    keyImage.color = Color.red;  
                    break;
                   
                case Key.KeyType.Green: keyImage.color = Color.red;
                    keyImage.color = Color.green;
                    break;
                case Key.KeyType.Yellow:
                    keyImage.color = Color.yellow;
                    break;
                
                  
            }

        }
    }

}
