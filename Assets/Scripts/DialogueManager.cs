using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager> {

	public Text nameText;
	public Text dialogueText;

    public GameObject DialogueBox;

	public Animator animator;

	private Queue<string> sentences;


	private Queue<Sprite> imagens;

	public Image showImage;

    private GameObject [] towerPanel;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		imagens = new Queue<Sprite>();
	
	}

	public void StartDialogue (Dialogue dialogue)
	{
        GameManager.Instance.DropTower();
        towerPanel = GameObject.FindGameObjectsWithTag("TowerPanel");
         foreach (GameObject  btn in towerPanel)
         {
             btn.SetActive(false);
         }
        LevelManager.Instance.IsGameRunning=false;

		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		if(dialogue.Sprites.Count>0){
			foreach(Sprite imagem in dialogue.Sprites)
			{
				imagens.Enqueue(imagem);
			}
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			this.showImage.enabled = false;
			return;
		}

		string sentence = sentences.Dequeue();
		if(imagens.Count>0){
		Sprite imagem = imagens.Dequeue();
		setImage(imagem);
		}
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
            yield return new WaitForSeconds(0.030f);
			dialogueText.text += letter;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
         foreach (GameObject  btn in towerPanel)
         {
             btn.SetActive(!btn.activeSelf);
         }
         LevelManager.Instance.IsGameRunning=true;
	}

	private void setImage(Sprite imagem){
		if(imagem==null){
			this.showImage.enabled = false;
		}else{
			this.showImage.sprite=imagem;
			this.showImage.enabled = true;
		}
	}

}