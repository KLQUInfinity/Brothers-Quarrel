using System.Collections;
using UnityEngine;

public class ItemPickUpBase : MonoBehaviour
{
    [SerializeField] private Transform itemPos;
    [SerializeField] private GameObject itemSprite;
    [SerializeField] private float generateWaitTime;
    [SerializeField] private GameObject[] items;
    [SerializeField] private Sprite[] itemsSprite;

    private GameObject availableItem;
    private bool isAvailable;

    private void Start()
    {
        StartCoroutine(GenerateRandomItem(3f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && isAvailable)
        {
            // Stop other player while item base has now weapon
            isAvailable = false;
            itemSprite.SetActive(false);

            // Add the new item to player
            other.gameObject.GetComponent<CharacterManager>().TakeNewItem(availableItem);

            // Start Timer for Generate a new item
            StartCoroutine(GenerateRandomItem(generateWaitTime));
        }
    }

    IEnumerator GenerateRandomItem(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        int index = Random.Range(0, items.Length);

        availableItem = items[index];

        itemSprite.SetActive(true);
        itemSprite.GetComponent<SpriteRenderer>().sprite = itemsSprite[index];

        isAvailable = true;
    }
}
