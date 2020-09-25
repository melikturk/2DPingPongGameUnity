using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRacket : racket
{
    public string AxisName;
    protected override void Move()
    {
        // Input.GetAxisRaw ; yumuşatmadan daha fevri hareket ettirir.
        //float moveAxis = Input.GetAxis("Vertical"); //dikeyde hareketi sağlar
        float moveAxis = Input.GetAxis(AxisName); //Üsttekinden farklı olarak kolların bilgisini programdan isteyip gönderdik.
        rbb2.velocity = new Vector2(0, moveAxis) * moveSpeed; //racketlerimi y yönünde hareket ataması yaptım.
    }

 
}
