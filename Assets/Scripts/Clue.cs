using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{

    public GameObject clue;

    public void OnEnable()
    {
        clue.SetActive(true);
    }

    public void Disable()
    {
        clue.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
