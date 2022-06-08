using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamage
{
    void TakeDamage(float damage);
    
}
public interface IHeal
{
    void Heal(float heal);
}
