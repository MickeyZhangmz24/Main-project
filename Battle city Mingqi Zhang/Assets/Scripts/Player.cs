using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    private Vector3 bullectEulerAngles;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//up right down left
    public GameObject BullectPrefab;
    private float timeVal;
    private float defendTimeVal=3;
    private bool isDefended = true;
    public GameObject explosionPerfab;
    public GameObject defendEffectPerfab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefended)
        {
            defendEffectPerfab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (isDefended)
            {
                isDefended = false;
                defendEffectPerfab.SetActive(false);
            }
        }
        if (timeVal>=0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;

        }

    }
    private void FixedUpdate()
    {
        Move();
    }



    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles+bullectEulerAngles));
            timeVal = 0;
        }
    }
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);

        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);

        }

        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

    }
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
    }
}
