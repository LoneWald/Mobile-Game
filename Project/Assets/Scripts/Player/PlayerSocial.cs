using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSocial : MonoBehaviour
{
    private float distanceToNPCInteract = 0.3f;
    private GameObject[] NPCes;
    private GameObject currentNPC;
    private InputActions input;
    private void Awake()
    {
        input = new InputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Start() {
        NPCes = GameObject.FindGameObjectsWithTag("NPC");
        Debug.Log(NPCes.Length);
    }

    private float FindClosestNPC(){
        float distance = Mathf.Infinity;
        foreach(GameObject npc in NPCes){
            float curDistance = (npc.transform.position - transform.position).sqrMagnitude;
            if(distance > curDistance){
                currentNPC = npc;
                distance = curDistance;
            }
        }
        return distance;
    }
    void Update()
    {
        if(input.PlayerActions.TalkNPC.triggered){
            if(FindClosestNPC() < distanceToNPCInteract){
                NPC npc = currentNPC.GetComponent<NPC>();
                npc.OpenDialogWindow();
                npc.SetDialog();
            }
        }
    }
}
