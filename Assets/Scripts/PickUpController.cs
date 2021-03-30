using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float blinkingTime;
    [SerializeField] string pickUpType;
    [SerializeField] int ammoAmount;

    bool isBlinking;
    float killTime;
    SpriteRenderer pickUpSprite;
    AmmoController ammoController;

    // Start is called before the first frame update
    void Start()
    {
        killTime = Time.time + duration;
        pickUpSprite = GetComponent<SpriteRenderer>();
        ammoController = FindObjectOfType<AmmoController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > killTime - blinkingTime && !isBlinking)
        {
            StartCoroutine(Blinker());
        }
    }

    IEnumerator Blinker()
    {
        for (int i = 0; i < 4; i++)
        {
            pickUpSprite.enabled = false;
            yield return new WaitForSeconds(.25f);
            pickUpSprite.enabled = true;
            yield return new WaitForSeconds(.25f);
        }
        DestroyPickUp();
    }

    void DestroyPickUp()
    {
        gameObject.SetActive(false);
    }

    public static PickUpController SpawnRandomPickUp()
    {
        GameObject randomPickUp = ObjectPool.SharedInstance.GetPooledPickUp();
        return randomPickUp.GetComponent<PickUpController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (pickUpType == "bullets" || pickUpType == "nuke")
            {
                if (ammoController.pickedUp) // Hides a PickUp object if it's pickedUp
                {
                    collision.GetComponent<AmmoController>().PickUpAmmo(pickUpType, ammoAmount);
                    gameObject.SetActive(false);
                }
            }
            else
                collision.GetComponent<PowerUpController>().ActivatePowerUp(pickUpType);
        }
    }
}
