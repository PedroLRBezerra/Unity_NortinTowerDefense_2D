using UnityEngine.UI;
using UnityEngine;

public class NodeUI : Singleton<NodeUI>
{
   public GameObject ui;

	public Text sellAmount;

	private Node target;

	public void SetTarget (Node _target)
	{
        Debug.Log("SetTarget");
		target = _target;

		sellAmount.text = "$" + target.Tower().GetComponent<Tower>().Cost;

		ui.SetActive(true);
        Debug.Log(ui.active);

	}

	public void Hide ()
	{
		ui.SetActive(false);
        target=null;
	}

    public Node Target(){
        return this.target;
    }
}
