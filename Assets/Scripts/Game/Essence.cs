using UnityEngine;

public abstract class Essence : MonoBehaviour
{
    private int _health = 1;
    private int _minHealth = 0;

    public void Update()
    {
        FellAbyss();
    }

    protected abstract void Walk();

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= _minHealth)
        {
            EntityDeath();
        }
    }

    protected void FellAbyss()
    {
        if (this.gameObject.transform.position.y <= -6)
        {
            EntityDeath();
        }
    }

    protected virtual void EntityDeath()
    {
        Destroy(this.gameObject);
    }
}
