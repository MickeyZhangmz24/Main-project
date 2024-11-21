using UnityEngine;

/// <summary>
/// 玩家控制器
/// </summary>
public class Player : MonoBehaviour
{
    #region -
    private Vector3 bullectEulerAngles = Vector3.zero;//子弹旋转值
    private float moveSpeed = 3;//移动速度
    private float timeVal = 0;//攻击计时器
    private float defendTimeVal = 3;//无敌计时器
    private bool isDefended = true;//是否处于无敌状态
    private SpriteRenderer sr = null;//精灵渲染组件  
    private AudioSource moveAudio = null;//音乐组件  
    #endregion

    #region +
    public Sprite[] tankSprite;//上 右 下 左 
    #endregion

    #region -Start 缓存
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        moveAudio = this.GetComponent<AudioSource>();
    }
    #endregion

    #region -Update 玩家出生时的无敌效果
    void Update()
    {
        //是否处于无敌状态
        if (isDefended)
        {
            //显示无敌特效
            GameManager.Instance.EffectGO[1].SetActive(true);
            //无敌计时开始
            defendTimeVal -= Time.deltaTime;

            //无敌时间到了
            if (defendTimeVal <= 0)
            {
                //关闭无敌效果
                isDefended = false;
                //隐藏无敌特效
                GameManager.Instance.EffectGO[1].SetActive(false);
                //重置无敌计时器
                defendTimeVal = 3;
            }
        }
    }
    #endregion

    #region -FixedUpdate 移动和攻击
    private void FixedUpdate()
    {
        //如果玩家已经死亡了的话
        if (PlayerManager.Instance.isDefeat)
        {
            //那就不执行了
            return;
        }

        //移动
        Move();

        //攻击计时器大于0.4秒
        if (timeVal >= 0.4f)
        {
            //那就可以攻击了
            Attack();
        }
        else
        {
            //计时器开始计时
            timeVal += Time.fixedDeltaTime;
        }
    }
    #endregion

    #region -Attack 坦克的攻击方法
    private void Attack()
    {
        //空格键发射子弹
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
            Instantiate(GameManager.Instance.BullectGO[1], this.transform.position, Quaternion.Euler(this.transform.eulerAngles + bullectEulerAngles));
            //子弹发射的计时器重置
            timeVal = 0;
        }
    }
    #endregion

    #region -Move 坦克的移动方法
    private void Move()
    {
        //获取纵轴的数据
        float v = Input.GetAxisRaw("Vertical");
        //移动
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        //根据方向设置图片和子弹角度
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

        //是否是有效的移动
        if (Mathf.Abs(v) > 0.05f)
        {
            //设置音效
            moveAudio.clip = GameManager.Instance.AudioClipArray[3];
            //如果当前没有在播放音效的话
            if (!moveAudio.isPlaying)
            {
                //那就播放移动音效
                moveAudio.Play();
            }
        }

        //当前是在上下移动
        if (v != 0)
        {
            //跳出不执行下面的左右移动
            return;
        }

        //获取横向的移动方向
        float h = Input.GetAxisRaw("Horizontal");
        //移动
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        //根据方向设置图片和子弹角度
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

        //是否是有效的移动
        if (Mathf.Abs(h) > 0.05f)
        {
            //设置音效
            moveAudio.clip = GameManager.Instance.AudioClipArray[3];
            //如果当前没有在播放音效的话
            if (!moveAudio.isPlaying)
            {
                //那就播放移动音效
                moveAudio.Play();
            }
        }
        else//否者就播放静止（没有在移动）的音效
        {
            moveAudio.clip = GameManager.Instance.AudioClipArray[2];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
    }
    #endregion

    #region -Die 坦克的死亡方法
    private void Die()
    {
        //如果当前是无敌状态的话
        if (isDefended)
        {
            //那就跳出不执行
            return;
        }

        //设置自玩家的死亡状态
        PlayerManager.Instance.isDead = true;

        //产生爆炸特效
        Instantiate(GameManager.Instance.EffectGO[0], this.transform.position, this.transform.rotation);
        //死亡
        Destroy(gameObject);
    }
    #endregion
}