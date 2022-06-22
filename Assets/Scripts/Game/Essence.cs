using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    private int _health = 1;
    private int _minHealth = 0;

    public virtual void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= _minHealth)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void FellAbyss()
    {
        if (this.gameObject.transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
