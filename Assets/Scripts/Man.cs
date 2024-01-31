using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public bool canAttack;
    [SerializeField] public float damage;
    [SerializeField] float coolDownAttack;

    [SerializeField] float attackTimer;

    Rigidbody2D rigidbody2D;
    Transform lion;
    Opponent opponent;
    Transform tg;
    Animator animator;


    Vector2 target;

    private void Start()
    {
        attackTimer = 0;
        target.x = 1000000;
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<ManTrigger>().man = this;
        transform.GetChild(1).GetComponent<Trigger>().man = this;
        if (canAttack)
        {
            opponent = GetComponent<Opponent>();
            animator = GetComponent<Animator>();         
        }
    }

    bool ran;

    float timer = 0;
    private void FixedUpdate()
    {
        if (ran && timer <= 0)
        {
            Vector2 vector2 = transform.position - lion.transform.position;
            vector2 = vector2.normalized;
            rigidbody2D.GetComponent<Rigidbody2D>().velocity = vector2 * speed * Time.fixedDeltaTime;

            float katObrotu = Mathf.Atan2(-vector2.y, -vector2.x) * Mathf.Rad2Deg;
            Quaternion rotacja = Quaternion.Euler(0f, 0f, katObrotu);
            transform.rotation = rotacja;
            //  rigidbody2D.GetComponent<Rigidbody2D>().velocity = rigidbody2D.transform.right * -speed * 10f * Time.deltaTime;
        }
        else if (timer > 0)
        {
            timer = timer - Time.fixedDeltaTime;
            rigidbody2D.GetComponent<Rigidbody2D>().velocity = rigidbody2D.transform.right * -speed * Time.fixedDeltaTime;
        }
        else if (opponent != null && opponent.target != null)
        {
            rigidbody2D.GetComponent<Rigidbody2D>().velocity = rigidbody2D.transform.right * -speed * Time.fixedDeltaTime;
        }
        else
        {
            rigidbody2D.GetComponent<Rigidbody2D>().velocity = rigidbody2D.transform.right * -speed * 0.25f * Time.fixedDeltaTime;
            if (target.x > 1000)
            {
                target = RandomVector(3, (Vector2)transform.position);

                Vector2 vector2 = (Vector2)transform.position - target;
                vector2 = vector2.normalized;

                float katObrotu = Mathf.Atan2(-vector2.y, -vector2.x) * Mathf.Rad2Deg;
                Quaternion rotacja = Quaternion.Euler(0f, 0f, katObrotu);
                transform.rotation = rotacja;
            }
        }
    }

    private void Update()
    {
        if(attackTimer > 0)
        {
            attackTimer = attackTimer - Time.deltaTime;
        }
    }
    public void Hiting()
    {
        if (attackTimer <= 0)
        {
            Debug.Log("attack");
            animator.SetTrigger("Attack");
            Player.instance.Damage(damage);
            attackTimer = coolDownAttack;
        }
    }
    public void Ran(Transform lion)
    {
      //  Debug.Log("simw");
        if(opponent != null) opponent.target = null;
        this.lion = lion;
        ran = true;
        target.x = 100000;
    }

    public void Attack(Transform tra)
    {
        if (tra != null)
        {
            opponent.target = tra;
            Vector2 vector2 = (Vector2)transform.position - (Vector2)tra.position;
            vector2 = vector2.normalized;

            float katObrotu = Mathf.Atan2(vector2.y, vector2.x) * Mathf.Rad2Deg;
            Quaternion rotacja = Quaternion.Euler(0f, 0f, katObrotu);
            transform.rotation = rotacja;
        }
           
    }

    public void Safe()
    {
        ran = false;
        rigidbody2D.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if(target.x > 1000)
        {
            target = RandomVector(2,(Vector2)transform.position);

            Vector2 vector2 = (Vector2)transform.position - target;
            vector2 = vector2.normalized;

            float katObrotu = Mathf.Atan2(-vector2.y, -vector2.x) * Mathf.Rad2Deg;
            Quaternion rotacja = Quaternion.Euler(0f, 0f, katObrotu);
            transform.rotation = rotacja;
        }
    }

    public void Wall()
    {
        timer = 0.7f;
        float z = transform.rotation.z;
        transform.Rotate(new Vector3(0, 0,Random.Range(80f,260f)));
        target.x = 100000;
    }


    Vector2 RandomVector(float f, Vector2 c)
    {
        Vector2 losowyWektorJednostkowy = Random.insideUnitSphere;
        Vector2 losowaPozycja = c + losowyWektorJednostkowy * (f / 2f);
        return losowaPozycja;
    }


}
