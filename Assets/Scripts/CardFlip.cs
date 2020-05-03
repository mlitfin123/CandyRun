using System.Collections;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private Sprite[] cards;
    private SpriteRenderer rend;
    private AudioSource cardFlipper;
    void Awake()
    {
        cardFlipper = GetComponent<AudioSource>();
    }

    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cards = Resources.LoadAll<Sprite>("Cards/");
        rend.sprite = cards[16];
    }

    public void Function()
    {
        if (!GameControl.gameOver)
            StartCoroutine("FlipTheCard");
    }

    private IEnumerator FlipTheCard()
    {
        int randomCard = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomCard = Random.Range(0, 16);
            rend.sprite = cards[randomCard];
            yield return new WaitForSeconds(0.05f);
            cardFlipper.Play();
        }
        Debug.Log(randomCard);
    }
}
