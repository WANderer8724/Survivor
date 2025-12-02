using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public int damage = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemy took damage: " + amount);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // убиваем врага
    }
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли на объекте скрипт Enemy
        PlayerHealth Player = other.GetComponent<PlayerHealth>();
        if (Player != null)
        {
            Player.TakeDamage(damage); // вызываем функцию получения урона
            print("sdkfhglksdfhgkjlhdfkjg");
            Destroy(gameObject);
        }
    }
}
