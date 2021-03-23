using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    Transform player;

    Vector3 movementDirection;

    [SerializeField] float movementSpeed;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        movementDirection = player.position - transform.position;
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }
}
