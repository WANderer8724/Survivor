using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float atackColdown;
    float atackColdown2;
    float atackColdown3;

    public float ReloadColdown;
    public float ReloadColdown2;
    public float ReloadColdown3;

    public GameObject LED;
    public GameObject LED2;
    public float rotateSpeed = 5;
    public Transform player; // сам игрок


    public GameObject attackPrefab;   // префаб удара
    public GameObject attackPrefab2;   // префаб удара
    public GameObject attackPrefab3;   // префаб удара
    public float attackDistance = 2f; // расстояние перед игроком

    void Update()
    {

        if (Input.GetButtonDown("Atack1") && atackColdown <= 0)//атака 1
        {

            FirstAtack();
            atackColdown = ReloadColdown;
        }
        if (Input.GetButtonDown("Atack2") && atackColdown2 <= 0)//атака 2
        {

            SecondAtack();
            atackColdown2 = ReloadColdown2;
        }
        if (Input.GetButtonDown("Jump") && atackColdown3 <= 0)//атака 3
        {

            ThirdAtack();
            atackColdown3 = ReloadColdown3;
        }

        if (atackColdown > 0)//таймер
        {
            atackColdown -= Time.deltaTime;
        }
        if (atackColdown2 > 0)//таймер
        {
            atackColdown2 -= Time.deltaTime;
            LED.transform.Rotate(0, transform.position.y + Time.deltaTime, 0);
        }
        if (atackColdown3 > 0)//таймер
        {
            atackColdown3 -= Time.deltaTime;
            LED2.transform.Rotate(0, (transform.position.y + Time.deltaTime) / 2, 0);
        }


    }
    public void FirstAtack()
    {
        // Луч из камеры в мир
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); // плоскость XZ на высоте игрока

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // Направление от игрока к точке на плоскости
            Vector3 direction = (hitPoint - transform.position).normalized;

            // Позиция появления атаки перед игроком
            Vector3 spawnPos = transform.position + direction * attackDistance;

            // Поворот объекта атаки
            Quaternion rot = Quaternion.LookRotation(direction);

            // Создаём удар
            GameObject attack = Instantiate(attackPrefab, spawnPos, rot);

            attack.transform.parent = player;
        }
    }
    public void ThirdAtack()
    {
        // Позиция появления атаки перед игроком
        Vector3 spawnPos = transform.position;
        // Создаём удар
        GameObject attack2 = Instantiate(attackPrefab2, player.position, Quaternion.identity, player.transform);
        attack2.transform.parent = player;
    }
    public void SecondAtack()
    {
        // Луч из камеры в мир
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); // плоскость XZ на высоте игрока

        if (plane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);

            // Направление от игрока к точке на плоскости
            Vector3 direction = (hitPoint - transform.position).normalized;

            // Позиция появления атаки перед игроком
            Vector3 spawnPos = transform.position;

            // Поворот объекта атаки
            Quaternion rot = Quaternion.LookRotation(direction);

            // Создаём удар
            GameObject attack3 = Instantiate(attackPrefab3, spawnPos, rot);
            attack3.transform.parent = player;

        }
    }
}
