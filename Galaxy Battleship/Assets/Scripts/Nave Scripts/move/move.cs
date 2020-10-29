using System.Collections;
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
    Collider colplayer;
    Animator anim;
    Animator anim2;

    public GameObject[] LifeUI;

    public int life = 3;
    public GameObject[] PropellantActive;

    PowerManager powerScript;
    GameOver GameOverScript;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        powerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PowerManager>();
        GameOverScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameOver>();
        colplayer = gameObject.GetComponent<Collider>();
        anim = GameObject.Find("Cube").GetComponent<Animator>();
        anim2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        LifeManager();
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
                    tempo += Time.deltaTime * 100;
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
                    tempo -= Time.deltaTime * 100;
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
                tempo -= Time.deltaTime * 100;
            if (tempo < 0)
                //aqui verifica se o tempo ta menor que zero para poder voltar a rotação pra zero
                tempo += Time.deltaTime * 100;
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

    //methid of immune 
    public void ActiveImmune()
    {
        transform.gameObject.tag = "Immune"; //set a new tag for player
        colplayer.enabled = false; // disable the collider player
        anim.SetBool("Immune", true); //start animation player immunes
        StartCoroutine(Immune()); //start of time of immune effect
        PropellantActive[0].SetActive(false); //disable a propellant
        PropellantActive[1].SetActive(false); //disable a propellant
    }
    public IEnumerator Immune()
    {
        yield return new WaitForSeconds(5); //time effect of immune
        Debug.Log("TAG PLAYER OKAY");
        transform.gameObject.tag = "Player"; //set a defalt tag of player
        colplayer.enabled = true; //set a collider active of player
        anim.SetBool("Immune", false); //finish a animation immune
        PropellantActive[0].SetActive(true); // active a propellant     
        PropellantActive[1].SetActive(true); // active a propellant  
    }

    
    void LifeManager()
    {/*
        if (life < 3)
        {
            LifeUI[0].SetActive(false);
        }
        if (life < 2)
        {
            LifeUI[1].SetActive(false);
        }
        */
        if (life == 0)
        {
            LifeUI[0].SetActive(false);
            Destroy(gameObject); //destroy player
            GameOverScript.GameOverActive(); //call the method game over
        }

   
    } 
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestroyAsteroids")) //check object colliding in tag player
        {
            PlayerDamage();
            Destroy(collision.gameObject);


        }
    }

    public void PlayerDamage()
    {
        life--;
        Debug.Log("life: " + life);
        GameObject explosionprefab = Instantiate(explosion, gameObject.transform.position, transform.rotation); // instantieate a particle system
        Destroy(explosionprefab, 3f); //destroy particle
        
        ActiveImmune(); //call the method immune
    }

}
