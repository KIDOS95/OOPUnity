using UnityEngine;

public class Essence : MonoBehaviour
{
    private int _health = 1;
    private int _minHealth = 0;

    public void Update()
    {
        FellAbyss();
    }

    public virtual void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= _minHealth)
        {
            EntityDeath();
        }
    }

    public virtual void FellAbyss()
    {
        if (this.gameObject.transform.position.y <= -6)
        {
            EntityDeath();
        }
    }

    public virtual void EntityDeath()
    {
        Destroy(this.gameObject);
    }
}
