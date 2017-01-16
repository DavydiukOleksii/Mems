using UnityEngine;
using UnityEngine.UI;

public class OneMemScr : MonoBehaviour {

    public int id;
    public string memName;
    public int armor;
    public int health;
    public int attack;
    public int missChance;

    public static int chouseID = -1;
    public int chouseSkill = -1;

    public bool isEnemy = false;

    public Image memImage;

    void Start() {
        //transform.Find("OneMemPref").gameObject.GetComponent<Image>().sprite = memImage.sprite;
        transform.Find("StatsTable").gameObject.transform.Find("HealthText").gameObject.GetComponent<Text>().text = health.ToString();
        transform.Find("StatsTable").gameObject.transform.Find("AttackText").gameObject.GetComponent<Text>().text = attack.ToString();
        transform.Find("StatsTable").gameObject.transform.Find("ArmorText").gameObject.GetComponent<Text>().text = armor.ToString();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseEnter()
    {
        //when you chouse frends hero
        if (!isEnemy && chouseID < 0) { 
            transform.Find("OneMemPref").gameObject.GetComponent<Outline>().effectColor = new Color(0, 0, 255);
        }

        //if you have active frends hero and you want to chouse enemy hero
        if(isEnemy && chouseID > -1)
        {
            transform.Find("OneMemPref").gameObject.GetComponent<Outline>().effectColor = new Color(255, 0, 0);
        }
    }

    private void OnMouseExit()
    {
        //leave hero field
        if (chouseID < 0 || isEnemy)
        {
            transform.Find("OneMemPref").gameObject.GetComponent<Outline>().effectColor = new Color(0, 0, 0);
        }
    }

    private void OnMouseDown()
    {
        if (!isEnemy)
        {
            //chouse frendly hero
            if (chouseID < 0)
            {
                transform.Find("OneMemPref").gameObject.GetComponent<Outline>().effectColor = new Color(0, 255, 0);
                //transform.Find("SkillsTable").gameObject.
                transform.Find("SkillsField").gameObject.SetActive(!transform.Find("SkillsField").gameObject.activeSelf);
                chouseID = id;
            }
            else
            {
                //unactive hero
                if (chouseID == this.id)
                {
                    transform.Find("OneMemPref").gameObject.GetComponent<Outline>().effectColor = new Color(0, 0, 255);
                    chouseID = -1;
                    transform.Find("SkillsField").gameObject.SetActive(!transform.Find("SkillsField").gameObject.activeSelf);
                }
            }
        }
        else
        {
            if (isEnemy)
            {
                if (SkillsScr.saveDamage != 0 && SkillsScr.chouseSkill != -1)
                {

                    health -= SkillsScr.saveDamage;
                    transform.Find("StatsTable").gameObject.transform.Find("HealthText").gameObject.GetComponent<Text>().text = health.ToString();
                    SkillsScr.saveDamage = 0;
                    if (health <= 0)
                        Destroy(gameObject);
                }
            }
        }

    }
}
