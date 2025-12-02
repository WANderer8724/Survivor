using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float rotateSpeed = 5f;

    void Update()
    {
        // Если игрок не найден — пытаемся снова каждый кадр
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;

            return; // ждём следующий кадр
        }

        // Направление
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        // Поворот
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // Движение
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}