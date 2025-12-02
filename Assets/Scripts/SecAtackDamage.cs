using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecAtackDamage : MonoBehaviour
{

    public int damage = 10; // урон снаряда

    private void OnTriggerEnter(Collider other)
    {

        // Проверяем, есть ли на объекте скрипт Enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // вызываем функцию получения урона
        }
    }

}
