using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YHBGAME.YHB_Singleton;

/// <summary>
/// 玩家管理器
/// </summary>
public class PlayerManager : SingletonBase<PlayerManager>
{
    #region -
    private int lifeValue = 6;//生命值
    private Text playerScoreText = null;//玩家分数Text
    private Text PlayerLifeValueText = null;//玩家生命的Text
    private GameObject isDefeatUI = null;//失败界面的UI物体
    #endregion

    #region +
    public bool isDead = false;//是否死亡
    public bool isDefeat;//游戏是否失败
    public int playerScore = 0;//分数
    #endregion

    #region -Start 缓存
    private void Start()
    {
        playerScoreText = this.transform.Find("Img_PlayerScore/Tex_PlayerScore").GetComponent<Text>();
        PlayerLifeValueText = this.transform.Find("Img_PlayerLifeValue/Tex_PlayerLifeValue").GetComponent<Text>();
        isDefeatUI = this.transform.Find("Img_Defeat").gameObject;

        isDefeatUI.SetActive(false);//默认不显示
    }
    #endregion

    #region -Update 玩家生命值和游戏失败的逻辑处理
    void Update()
    {
        //如果游戏失败了的话
        if (isDefeat)
        {
            //显示失败UI物体
            isDefeatUI.SetActive(true);
            //延迟3秒后执行ReturnToTheMainMenu方法
            Invoke("ReturnToTheMainMenu", 3);
            //跳出
            return;
        }

        //如果玩家死亡了的话
        if (isDead)
        {
            //执行玩家死亡操作
            Recover();
        }

        //设置UI的显示
        playerScoreText.text = playerScore.ToString();//分数
        PlayerLifeValueText.text = lifeValue.ToString();//生命值
    }
    #endregion

    #region -Recover 玩家死亡处理
    private void Recover()
    {
        //如果生命值小于0的话
        if (lifeValue <= 0)
        {
            //游戏失败，返回主界面
            isDefeat = true;
            Invoke("ReturnToTheMainMenu", 3);
        }
        else//生命值没有小于0的话
        {
            //先减少生命值
            lifeValue--;
            //然后实例化道具
            GameObject go = Instantiate(GameManager.Instance.ItemGO[3], new Vector3(-2, -8, 0), Quaternion.identity);
            //获取道具身上的Born并设置为创建玩家的标志位
            go.GetComponent<Born>().createPlayer = true;
            //重新设置死亡状态
            isDead = false;
        }
    }
    #endregion

    #region -ReturnToTheMainMenu 切换到开始场景
    private void ReturnToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}