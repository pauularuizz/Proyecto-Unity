/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public LayerMask WhatIsShootable;
    public float Range = 10;

    private LineRenderer _lineRenderer;


    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Select();
        if (isPLayerNear)
        {
            
        }
    }

    public void Fire()
    {
        if (_selectedObject != null)
        {
            _selectedObject.TakeDamage(Damage);
        }
    }

    private void Select()
    {
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, FirePoint.right, Range, WhatIsShootable);
        if (hit)
        {
            _selectedObject = hit.collider.GetComponent<IShootable>();
            if (_selectedObject == null)
                Debug.LogError("Non Shootable Enemy");

            Debug.Log("Hit: " + hit.collider.name);
            SetLineRenderer(FirePoint.position, hit.point, Color.red);
        }
        else
        {
            SetLineRenderer(FirePoint.position, FirePoint.position + FirePoint.right * Range, Color.yellow);
            _selectedObject = null;
        }
    }

    private void SetLineRenderer(Vector3 start, Vector3 end, Color col)
    {
        _lineRenderer.SetPosition(0, start);
        _lineRenderer.SetPosition(1, end);
        _lineRenderer.startColor = col;
    }
}
*/