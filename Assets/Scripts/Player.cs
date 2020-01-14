using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;

    public int Stones { get; set; }
    public int Woods { get; set; }

    public Text stoneText;
    public Text woodText;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        Stones = 0;
        Woods = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        healthText.text = "Health : " + health.ToString();
        stoneText.text = "Stone : " + Stones.ToString();
        woodText.text = "Wood : " + Woods.ToString();
    }
}
