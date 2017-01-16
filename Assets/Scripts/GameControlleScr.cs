using UnityEngine;
using UnityEngine.UI;

public class GameControlleScr : MonoBehaviour {

    public GameObject memFriendPref;
    public GameObject memEnemyPref;

    public GameObject winField;

    public Transform friendGroup;
    public Transform enemyGroup;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            CreateNichosi(i);
            CreateEnemyNichosi(i);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(enemyGroup.childCount == 0)
        {
            //you win
            winField.transform.position = new Vector3(0f, 0f,0f); 
        }
	}

    void CreateNichosi(int id)
    {
        //add first mem
        GameObject tmpMem = Instantiate(memFriendPref);

        tmpMem.transform.SetParent(friendGroup);

        tmpMem.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        tmpMem.transform.localScale = new Vector3(1, 1, 1);

        tmpMem.GetComponent<OneMemScr>().armor = 2;
        tmpMem.GetComponent<OneMemScr>().attack = 5;
        tmpMem.GetComponent<OneMemScr>().health = 50;
        tmpMem.GetComponent<OneMemScr>().id = id;
        //tmpMem.GetComponent<OneMemScr>().memImage = 

        tmpMem.transform.Find("OneMemPref").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Nichosi") as Sprite;
    }

    void CreateEnemyNichosi(int id)
    {
        //add first mem
        GameObject tmpMem = Instantiate(memEnemyPref);

        tmpMem.transform.SetParent(enemyGroup);

        tmpMem.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        tmpMem.transform.localScale = new Vector3(1, 1, 1);

        tmpMem.GetComponent<OneMemScr>().armor = 2;
        tmpMem.GetComponent<OneMemScr>().attack = 1;
        tmpMem.GetComponent<OneMemScr>().health = 20;
        tmpMem.GetComponent<OneMemScr>().id = id;
        //tmpMem.GetComponent<OneMemScr>().memImage = 

        tmpMem.transform.Find("OneMemPref").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Nichosi") as Sprite;
    }
}
