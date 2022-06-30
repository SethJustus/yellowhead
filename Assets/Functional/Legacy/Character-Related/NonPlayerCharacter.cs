using UnityEngine;
using UnityEngine.UI;
public class NonPlayerCharacter : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue_Manager manager;
    public float distTalk = 2;
    public bool talking;
    public bool near;
    private GameObject playerGO;
    private Player player;
    
    void Start()
    {
        playerGO = GameObject.Find("Player");
        player = playerGO.GetComponent<Player>();
        manager = FindObjectOfType<Dialogue_Manager>();
    }
    void Update()
    {
        float playerDistance = Vector2.Distance(player.transform.position, transform.position);
        if(playerDistance<distTalk)
        {
            near = true;
            manager.NPC = this;
            if(talking == false)
            {
                
                if(player.tryingToTalk == true)
                {
                        TriggerDialogue();
                        
                }
            }
        } else
        {
            near = false;
            this.talking = false;
            
        }
    }
    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue);
    }
}
