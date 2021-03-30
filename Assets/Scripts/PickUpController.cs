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

    // Start is called before the first frame update
    void Start()
    {
        killTime = Time.time + duration;
        pickUpSprite = GetComponent<SpriteRenderer>();
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
}
