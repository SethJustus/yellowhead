using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller_NonPlayer : MonoBehaviour
{
    public Dialogue dialogue;
    public bool talking = false;
    public float DistanceToReact;
    private Text dialogueText;
    private Queue<string> sentences;
    private GameObject playerObj;
    private Controller_Player player;
    float playerDistance;

    
    #region Dialogue Methods Here
    
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Dialogue!");
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            this.sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();       
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
    }
    public void EndDialogue()
    {
        talking = false;
    }
    public void Respond()
    {
        
        
        if(playerDistance<DistanceToReact)
        {
            if(player.Listening == true)
            {
                
                if(talking == false)
                {
                    talking = true;
                    StartDialogue(this.dialogue);
                }
            }
        }else
        {
            talking = false;
        }

    }
    # endregion
    void Start()
    {
        dialogueText = GetComponentInChildren<Text>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Controller_Player>();
        sentences = new Queue<string>();
        
    }

    void Update()
    {
       playerDistance = Vector2.Distance(playerObj.transform.position, transform.position);
        this.Respond();
        if(talking == true)
        {
            if(Input.GetKeyUp(KeyCode.X)||Input.GetKeyUp(KeyCode.Return))
            {
                DisplayNextSentence();
            }
        }else
        {
            if(playerDistance<DistanceToReact)
            {
                dialogueText.text = "Listen to "+ dialogue.name;
            }else
            {
                dialogueText.text = "";
            }
        }
    }
}

