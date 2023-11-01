using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;
using System.Data;

public class HPTimeBar : MonoBehaviour
{
    public gamemannager Game;
    [SerializeField] private float HP;
    [SerializeField] private int MaxHP;
    [SerializeField] private int HPchange;
    [SerializeField] private float time;
    [SerializeField] private bool timerActive = false;
    [SerializeField] private bool isCountingDown = false;
    [SerializeField] RectTransform _hp;
   // [SerializeField] Text _timeText;
    [SerializeField] private int HPArg;
    [SerializeField] private int timeArg;
    [SerializeField] private int HPminusArg;
    private bool endgame = false;

    public Text timeText;
    public float currentTime = 180f;
    private bool isCounting = true;

    void Start()
    {
        InvokeRepeating("CountDown", 1f, 1f);
    }
    void CountDown()
    {
        if (isCounting)
        {
            currentTime--;
            UpdateTimeText();

            if (currentTime <= 0)
            {
                // 時間到，執行遊戲結束或其他相關操作
                isCountingDown = false;
            }
        }
    }

    void UpdateTimeText()
    {
        timeText.text =  currentTime.ToString("F0"); // "F0" 將浮點數顯示為整數
    }
    public void AddHP() { 
        if (isCountingDown) 
            HP = (HP + HPArg > MaxHP) ? MaxHP : (HP + HPArg);
    }
    public void minusHP()
    {
        if (isCountingDown)
        {
                if( HP - HPminusArg > 0)
                {
                HP = HP- HPminusArg;
                }
            else
            {
                HP = 0;
            }
           
        }
           
    }

    public void StartTimer() {
        if (!timerActive){
            HP = MaxHP;
            time = timeArg;
            timerActive = true;
            isCountingDown = true;
           // _timeText.text = time < HPminusArg ? ("0" + Mathf.CeilToInt(time).ToString()) : time.ToString();
        }
    }

    public void ToggleTimer() {
        if (isCountingDown) PauseTimer(); else ResumeTimer();
    }

    public void PauseTimer() {
        isCountingDown = false;
    }

    public void ResumeTimer(){
        isCountingDown = timerActive ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown && HP > 0 && time > 0)
        {
            HP -= HPchange * Time.deltaTime;
            //time -= Time.deltaTime;
            //int IntTime = Mathf.CeilToInt(time);
            //_timeText.text = IntTime < HPminusArg ? ("0" + IntTime.ToString()) : IntTime.ToString();
        }
        else if (!isCountingDown) {
        
        }
        else{
            isCountingDown = false;
            timerActive = false;
            if (endgame == false)
            {
                Game.lose_level();
                //Debug.Log("Already lose");
            }
            endgame = true;
            if (HP > 0) {
                Debug.Log("Time's up");
            }
            else {
                Debug.Log("Lose");
            }
        }
        _hp.GetComponent<RectTransform>().localScale = new Vector3(HP / MaxHP,1,1);
    }
}
