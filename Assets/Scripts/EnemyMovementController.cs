using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    Transform player;
    [SerializeField] float movementSpeed;

    Vector3 movementDirection;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            movementDirection = player.position - transform.position;
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        }
    }
}
