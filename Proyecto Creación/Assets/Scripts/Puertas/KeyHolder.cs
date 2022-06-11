using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public event EventHandler OnKeysChanged;
    private List<Key.KeyType> keyList;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        keyList = new List<Key.KeyType>();
    }
    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }
    public void  AddKey(Key.KeyType keyType)
    {
        Debug.Log("llave a;adida:" + keyType);
        keyList.Add(keyType);
        
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }
    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key!=null)
        {
            
            AddKey(key.GetKeyType());
            
            Destroy(key.gameObject);
            soundManager.AudioSelector(2, 0.8f);
        }

        Door door = collider.GetComponent<Door>();
        if (door!=null)
        {
            if (ContainsKey(door.GetKeyType()))
            {
                RemoveKey(door.GetKeyType());Debug.Log("llave borrada:");
                door.OpenDoor();
            }
        }
    }
}
