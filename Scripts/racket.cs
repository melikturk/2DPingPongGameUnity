using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class racket : MonoBehaviour
{
    protected Rigidbody2D rbb2 { get { return GetComponent<Rigidbody2D>(); } } //Bu şekilde ekleme şeklide var. 
    // public Rigidbody2D rb2 { get { return GetObject<Rigidbody2D>(); } } şeklindede kullanılabilir.
    public float moveSpeed = 5;

    float score;

    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void MakeScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
