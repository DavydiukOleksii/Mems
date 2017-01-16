using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsScr : MonoBehaviour {

    public static int chouseSkill = -1;
    public static int saveDamage = 0;
    public int skillId;

	void Start () {
		
	}

	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (chouseSkill == -1 && gameObject.tag == "skill")
        {
            switch (gameObject.name)
            {
                case "Skill1":
                    saveDamage = 10;
                    chouseSkill = 1;
                    break;
                case "Skill2":
                    saveDamage = 20;
                    chouseSkill = 2;
                    break;
                case "Skill3":
                    saveDamage = 30;
                    chouseSkill = 3;
                    break;
                case "Skill4":
                    saveDamage = 40;
                    chouseSkill = 4;
                    break;
            }

            gameObject.GetComponent<Outline>().effectColor = new Color(0, 255, 0);

            
        }
        else
        {
            if (gameObject.tag == "skill" && chouseSkill == skillId)
            {
                gameObject.GetComponent<Outline>().effectColor = new Color(0, 0, 0);
                chouseSkill = -1;
            }
        }
    }
}
