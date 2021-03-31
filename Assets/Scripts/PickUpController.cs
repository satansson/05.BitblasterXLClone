using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    
    [SerializeField] float blinkingTime;
    [SerializeField] float duration = 7.5f;

    public int ammoAmount;
    public string pickUpType;

    bool isBlinking;
    float hideTime;
    SpriteRenderer pickUpSprite;

    // Start is called before the first frame update
    void OnEnable()
    {
        hideTime = Time.time + duration;
        pickUpSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isBlinking && Time.time > hideTime - blinkingTime)
        {
            StartCoroutine(Blinker());
        }
    }

    IEnumerator Blinker()
    {
        isBlinking = true;

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
