using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue_Manager : MonoBehaviour
{
    public NonPlayerCharacter NPC;

    public GameObject display;

    public Text dialogueText;
    private Queue<string> sentences;
    private GameObject Player;
    private Character_State playerState;
    
    private GameObject talkCueTextObj;

    private Text talkCueText;
    public bool displaying;
    void Start()
    {
        sentences = new Queue<string>();
        Player = GameObject.Find("Player");
        playerState = Player.GetComponent<Character_State>();
        talkCueTextObj = GameObject.FindGameObjectWithTag("Talk_Cue");
        talkCueText = talkCueTextObj.GetComponent<Text>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        
        NPC.talking = true;
        playerState.talking = true;
        display.SetActive(true);
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();   
        displaying = true;     
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }
    public void EndDialogue()
    {
        playerState.talking = false;
        NPC.talking = false;
        display.SetActive(false);
        displaying = false;
    }
    void Update()
    {
        if(this.NPC.talking == false)
        {
            EndDialogue();
        }
        if(this.NPC.near == true)
        {
            talkCueText.enabled  = true;

            if(this.NPC.talking == false)
            {
                talkCueText.text = "Talk? [Enter]";
            }else
            {
                talkCueText.text = "Next? [Space]";
            }

        }else
        {
            talkCueText.enabled =false;
        }
        Debug.Log(NPC.near);
    }
}
