using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rd2;
    public float moveSpeed = 5;
    public racket leftRacket, rightRacket;
    AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    void Start()
    {
        //İşlemlerimizi 2d rigidbody üzeri yaptığımızdan onu eklemeliyiz ya elle ekleyecez yada kodla aşşağıdaki kod onu sağlıyor.
        rd2 = GetComponent<Rigidbody2D>();//Kod diyor ki; RigidBody2D componentini al rd2ye ekle.
        rd2.velocity = new Vector2(1, 0)*moveSpeed; //velocity bize hız verir. Kod bize x yönünde başlangıç hızı veriyor. moveSpeed ile 5 birimlik bir hız sağladım.
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagManager tm = collision.gameObject.GetComponent<TagManager>();
        audioSource.PlayOneShot(audioSource.clip);
        if (tm!=null)
        {
            if (tm.tagger.Equals(Tager.LEFT_WALL))
            {
                //rightracket makescore
                rightRacket.MakeScore();
            }
            else if (tm.tagger.Equals(Tager.RIGHT_WALL))
            {
                leftRacket.MakeScore();
            }
            else if (tm.tagger.Equals(Tager.LEFT_RACKET))
                NewMethod(1,collision);
            else if (tm.tagger.Equals(Tager.RIGHT_RACKET))
            {
                NewMethod(-1,collision);

            }
        }
    }

    private void NewMethod(float x,Collision2D collision)
    {
        Vector2 contact = collision.GetContact(0).point;
        var a = (contact.y - collision.transform.position.y);
        //height of racket b=y/a , a=contactpoint.y -racketcenter.y
        var b = collision.collider.bounds.size.y;
        var y = a / b;
        rd2.velocity = new Vector2(x, y) * moveSpeed;
    }
}
