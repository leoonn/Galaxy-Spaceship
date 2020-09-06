﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rb;
    private float x;
    private float y;
    private float z;
    public float minX;
    public float minY;
    public float minZ;
    public float maxX;
    public float maxY;
    public float maxZ;
    private float tempo = 0.0f;

    PowerManager powerScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        powerScript = GameObject.Find("GameManager").GetComponent<PowerManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        limitMovement();
        spaceshipRotation();

    }
    public void limitMovement()
    {
        // ja que alguem teve a bilhantente ideia de colocar o Z como x e ainda colocar como negativo pra ajuda ainda
        // ta aqui nesse if ele verifica se a posicao da nave e maior que o Min e o botao que ta sendo apertado e positivo
        // ou se a posicao e menor que a o Max
        if (transform.position.x > minX
            && Input.GetAxisRaw("Horizontal") > 0
            || transform.position.x < maxX
            && Input.GetAxisRaw("Horizontal") < 0)
        {
            //nesse segundo if ele verifica se é  -1
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //se o tempo for menor que 30 segundo ele vai aumentar o tempo
                if (tempo < 30)
                    tempo += Time.deltaTime * 70;
                else
                    // aqui ele vai diminuir o tempo
                    tempo = 30;
            }
            else
            //nesse segundo if ele verifica se é  1
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //se o tempo for menor que 30 segundo ele vai aumentar o tempo
                if (tempo > -30)
                    tempo -= Time.deltaTime * 70;
                else
                    // aqui ele vai diminuir o tempo
                    tempo = -30;
            }
            //aqui ele declara a velocida da movimentação  com o botao apertado 1 ou -1
            x = Input.GetAxisRaw("Horizontal") * -10;
        }
        else
        {
            // aqui  ele ta maior que o maxZ ou menor que minZ

            //aqui verifica se o tempo ta maior que zero para poder voltar a rotação pra zero;
            if (tempo > 0)
                tempo -= Time.deltaTime * 70;
            if (tempo < 0)
                //aqui verifica se o tempo ta menor que zero para poder voltar a rotação pra zero
                tempo += Time.deltaTime * 70;
            if (tempo > 1
                && tempo < -1
                )
                tempo = 0;
            //aqui ele setar zero no Z
            x = 0;
        }
        if (transform.position.y > minY
            && Input.GetAxisRaw("Vertical") < 0
            || transform.position.y < maxY
            && Input.GetAxisRaw("Vertical") > 0
            )
        {
            y = Input.GetAxisRaw("Vertical") * 10;
        }
        else
        {
            y = 0;
        }
    }

    public void spaceshipRotation()
    {
        //aqui ele faz a rotaão da nave
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, tempo);
        //aqui faz a movimentação  do x, y e X
        rb.velocity = new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DoubleShoot")) //check object colliding in tag player
        {
            powerScript.typePower = powerUp.doubleShoot;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("TripleShoot")) //check object colliding in tag player
        {
            powerScript.typePower = powerUp.tripleShoot;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("FastShoot")) //check object colliding in tag player
        {
            powerScript.typePower = powerUp.shootFast;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Shield")) //check object colliding in tag player
        {
            powerScript.typePower = powerUp.shield;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("DoubleScore")) //check object colliding in tag player
        {
            powerScript.typePower = powerUp.doubleScore;
            Destroy(col.gameObject);
        }
    }
}