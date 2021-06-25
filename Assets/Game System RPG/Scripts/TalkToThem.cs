using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
using Debugging.Player;
using UnityEngine.UI;

public class TalkToThem : MonoBehaviour
{
    public Movement playerMovement;
    public GameObject QuestLocked;
    public GameObject QuestToBeAccepted;
    public GameObject QuestToBeComplete;
    public Text QuestToBeAcceptedText;
    private QuestNPC questNPC;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "NPC")
        {
            Dialogue[] npcDialogue = collision.transform.GetComponents<Dialogue>();
            if (npcDialogue != null)
            {
                foreach (Dialogue dialogue in npcDialogue)
                {
                    if (dialogue.firstDialogue == true)
                    {
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;

                        DialogueManager.instance.LoadDialogue(dialogue);
                    }
                }
            }
        }

        if (collision.transform.tag == "Quest")
        {
            questNPC = collision.transform.GetComponent<QuestNPC>();
            if (questNPC != null)
            {
                if (questNPC.ReleventQuest.stage == QuestStage.Locked)
                {
                    if (!QuestLocked.gameObject.activeSelf)
                        QuestLocked.gameObject.SetActive(true);

                }
                else if (questNPC.ReleventQuest.stage == QuestStage.Unlocked)
                {
                    if (!QuestToBeAccepted.gameObject.activeSelf)
                    {
                        QuestToBeAcceptedText.text = questNPC.ReleventQuest.desciption;
                        QuestToBeAccepted.gameObject.SetActive(true);
                        StartCoroutine(AcceptQuest());
                    }
                }
                else if (questNPC.ReleventQuest.stage == QuestStage.RequirementMet)
                {
                    if (!QuestToBeComplete.gameObject.activeSelf)
                    {
                        QuestToBeComplete.gameObject.SetActive(true);
                        StartCoroutine(FinishQuest());
                    }
                }
            }
        }
        IEnumerator FinishQuest()
        {
            while (true)
            {
                if (Input.GetKeyDown("z"))
                {
                    playerMovement.playerMoney += questNPC.ReleventQuest.reward.gold;
                    playerMovement.playerRocks += (int)questNPC.ReleventQuest.reward.experience;
                    questNPC.ReleventQuest.stage = QuestStage.Complete;
                    QuestToBeComplete.gameObject.SetActive(false);
                }
                yield return new WaitForSeconds(0);
            }
        }
    }
    IEnumerator AcceptQuest()
    {
        while (true)
        {
            if (Input.GetKeyDown("y"))
            {
                questNPC.ReleventQuest.stage = QuestStage.InProgress;
                QuestToBeAccepted.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown("n"))
            {
                QuestToBeAccepted.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0);
        }
    }
}
