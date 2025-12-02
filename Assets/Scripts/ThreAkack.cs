using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreAkack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

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
    public GameObject objectToDelete;
    float time = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 10 * Time.deltaTime;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(objectToDelete);
        }
    }
}
