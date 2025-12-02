using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log("Игрок получил урон! HP = " + hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

