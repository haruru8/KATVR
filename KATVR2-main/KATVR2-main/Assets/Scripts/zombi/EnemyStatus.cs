
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{

    //　敵のMaxHP
    [SerializeField]
    private int maxHp = 100;
    //　敵のHP
    [SerializeField]
    private int hp;
    //　敵の攻撃力
    [SerializeField]
    private int attackPower = 20;
    private Zombie zombie;
    //　HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    //　HP表示用スライダー
    private Slider hpSlider;


    void Start()
    {
        Debug.Log("enemystatus呼び出す");
        zombie = GetComponent<Zombie>();
        hp = maxHp;
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;

        //　HP表示用UIのアップデート
        UpdateHPValue();

        if (hp <= 0)
        {
            //　HP表示用UIを非表示にする
            HideStatusUI();
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    //　死んだらHPUIを非表示にする
    public void HideStatusUI()
    {
        HPUI.SetActive(false);
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }

}
