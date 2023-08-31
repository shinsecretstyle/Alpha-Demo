using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmartNotesMaker : MonoBehaviour
{


    //ノーツ定義
    public GameObject NotesA;//ノーツ ⭕

    public GameObject NotesB;//ノーツ ×

    public GameObject NotesC;//ノーツ △

    public GameObject NotesD;//ノーツ □

    GameObject thisNote;


    public Transform RightspawnPoint;
    //始める位置
    public Transform LeftspawnPoint;
    //始める位置

    public Transform endPoint;
    //判定位置の真中

    public float beatFallSpeed;
    //bpmの設定

    public DateTime StartedTime;
    //始める時間

    //public bool canBePressed;
    //判定位置到着

    private int TotalNotes;
    //曲のノーツの数

    public int NowNotes;
    //ノーツのポインター

    private float PassingTime;

    public float totalTime;
    //時間プラス真中到着するまでの時間

    private float GamingTime = 0.0f;
    public float beginningTime = 0.0f;

    public TextAsset textJSON;

    public String NextScene;

    [System.Serializable]
    public class Notes
    {
        public int id;
        public float times;
        public int type;
        public bool hasSpawned;
        public string NotesPosition;
    }

    [System.Serializable]
    public class NotesList
    {
        public float MusicTotalTime;
        public int totalNotes;
        public float beatFallSpeed;
        public Notes[] notes;
    }

    public NotesList myNotesList = new NotesList();

    private bool gaming;

    public float waitForQuit;
    // Start is called before the first frame update
    void Start()
    {
        myNotesList = JsonUtility.FromJson<NotesList>(textJSON.text);
        //JSONデータローディング

        StartedTime = DateTime.Now;
        //始める時間　（獲得??）
        
        TotalNotes = myNotesList.totalNotes;

        NowNotes = 0;
        
        PassingTime = myNotesList.MusicTotalTime;

        //一番目スライダーで移動時間をプラス
        totalTime = myNotesList.MusicTotalTime + (RightspawnPoint.position.x-0) / (myNotesList.beatFallSpeed/60f);
        
        gaming = true;

        waitForQuit = 7f;
    }
    // Update is called once per frame
    void Update()
    {
        
        PassingTime -= Time.deltaTime;
        GamingTime = totalTime-PassingTime;
        beginningTime += Time.deltaTime;
        if (((totalTime - PassingTime) > myNotesList.notes[NowNotes].times) &&(NowNotes <myNotesList.totalNotes-1))
        {

            //ノーツ様式ローディング
            if (myNotesList.notes[NowNotes].type == 1)
            {
                thisNote = NotesA;
            }
            if (myNotesList.notes[NowNotes].type == 2)
            {
                thisNote = NotesB;
            }
            if (myNotesList.notes[NowNotes].type == 3)
            {
                thisNote = NotesC;
            }
            if (myNotesList.notes[NowNotes].type == 4)
            {
                thisNote = NotesD;
            }

            NowNotes++;
            //ノーツのポインター移動


            if (myNotesList.notes[NowNotes].NotesPosition == "Right")
            {
                beatFallSpeed = Mathf.Abs(myNotesList.beatFallSpeed);
                
                Instantiate(thisNote, RightspawnPoint.position, new Quaternion(0f, 0f, 0f, 0f));
                //ノーツを作る
            }
            if (myNotesList.notes[NowNotes].NotesPosition == "Left")
            {
                beatFallSpeed = -Mathf.Abs(myNotesList.beatFallSpeed);
                
                Instantiate(thisNote, LeftspawnPoint.position, new Quaternion(0f, 0f, 0f, 0f));
                //ノーツを作る
            }
        }

        if((NowNotes == myNotesList.totalNotes - 1)&&(gaming == true))
        {
            GameObject.Find("EnemyMaker").SetActive(false);
            gaming = false;
            
        }
        if(gaming == false)
        {
            waitForQuit -= Time.deltaTime;
            if (waitForQuit < 0)
            {
                if (Gate.HP > 0)
                {
                    GameController.GameClear = 1;
                    //SceneManager.LoadScene("Lovetime");
                }
            }
        }

    }
}