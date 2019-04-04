using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UpdateStore : MonoBehaviour
{
    public int costPerLevel;

    [Space]
    public int repairKitCost;

    // Start is called before the first frame update
    void Start()
    {
        UpdateStore("sailLevel");
        UpdateStore("cannonLevel");
        UpdateStore("hullLevel");
        UpdateStore("crewLevel");
        UpdateStore("repairKits");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateStore(string row)
    {
        GameObject rowObject = GameObject.Find(row);
        foreach(Text text in rowObject.GetComponentsInChildren<Text>())
        {
            if (text.name == "num")
            {
                if (row == "repairKits") text.text = (PlayerPrefs.GetInt(row)).ToString();
                else text.text = (PlayerPrefs.GetInt(row) + 1).ToString();
                text.color = new Color(0.39f, 0.32f, 0.21f, 1f);
            }
        }
    }
    public void Increment(string row)
    {
        
        int tempNum = PlayerPrefs.GetInt(row) + 1;
        GameObject rowObject = GameObject.Find(row);
        foreach (Text text in rowObject.GetComponentsInChildren<Text>())
        {
            if (text.name == "num")
            {
                if (rowObject.name == "repairKits")
                {
                    int num;
                    int.TryParse(text.text, out num);
                    text.text = (num + 1).ToString();
                    text.color = new Color(0.98f, 0, 0.29f, 1f);
                    UI_Cost.cost += repairKitCost;
                    foreach (Image image in GetComponentsInChildren<Image>())
                    {
                        if (image.gameObject.name == row + "Cancel")
                        {
                            image.enabled = true;
                        }
                    }
                }
                else
                {
                    if (tempNum != 3)
                    {
                        text.text = (tempNum + 1).ToString();
                        text.color = new Color(0.98f, 0, 0.29f, 1f);
                        UI_Cost.cost += tempNum * costPerLevel;
                        foreach (Image image in GetComponentsInChildren<Image>())
                        {
                            if (image.gameObject.name == row + "Cancel")
                            {
                                image.enabled = true;
                            }
                        }
                        foreach (Button button in GetComponentsInChildren<Button>())
                        {
                            if (button.gameObject.name == row + "Increase")
                            {
                                button.interactable = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (Button button in GetComponentsInChildren<Button>())
                        {
                            if (button.gameObject.name == row + "Increase")
                            {
                                button.interactable = false;
                            }
                        }
                    }
                } 
            }
        }
    }
    public void Cancel(string row)
    {
        GameObject rowObject = GameObject.Find(row);
        foreach (Text text in rowObject.GetComponentsInChildren<Text>())
        {
            if (text.name == "num")
            {
                int tempNum;
                int.TryParse(text.text, out tempNum);
                if (row == "repairKits") UI_Cost.cost -= (tempNum - PlayerPrefs.GetInt("repairKits")) * repairKitCost;
                else UI_Cost.cost -= (tempNum - 1) * costPerLevel;

                text.color = new Color(0.39f, 0.32f, 0.21f, 1f);
                if (row == "repairKits" ) text.text = (PlayerPrefs.GetInt(row)).ToString();
                else text.text = (PlayerPrefs.GetInt(row) + 1).ToString();
            }
            foreach (Image image in GetComponentsInChildren<Image>())
            {
                if (image.gameObject.name == row + "Cancel")
                {
                    image.enabled = false;
                }
            }
            foreach (Button button in GetComponentsInChildren<Button>())
            {
                if (button.gameObject.name == row + "Increase")
                {
                    button.interactable = true;
                }
            }
        }
    }
    public void Purchase()
    {
        if (UI_Cost.cost > PlayerPrefs.GetInt("treasure"))
        {
            SpawnCostError();
        }
        else
        {
            PlayerPrefs.SetInt("treasure", PlayerPrefs.GetInt("treasure") - UI_Cost.cost);
            UI_Cost.cost = 0;
            List<string> Categories = new List<string>();

            Categories.Add("sailLevel");
            Categories.Add("cannonLevel");
            Categories.Add("hullLevel");
            Categories.Add("crewLevel");
            Categories.Add("repairKits");

            foreach (string category in Categories)
            {
                

                GameObject rowParent = GameObject.Find(category);
                foreach (Image image in rowParent.GetComponentsInChildren<Image>())
                {
                    if (image.gameObject.name == category + "Cancel")
                    {
                        image.enabled = false;
                    }
                }
                foreach (Button button in rowParent.GetComponentsInChildren<Button>())
                {
                    if (button.gameObject.name == category + "Increase")
                    {
                        button.interactable = true;
                    }
                }
                foreach (Text num in rowParent.GetComponentsInChildren<Text>())
                {
                    if (num.gameObject.name == "num")
                    {
                        int number;
                        int.TryParse(num.text, out number);

                        if (category == "repairKits") PlayerPrefs.SetInt(category, number);
                        else PlayerPrefs.SetInt(category, number - 1);

                        UpdateStore(category);
                    }
                }
            }
        }
    }

    public void SpawnCostError()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "costError")
            {
                child.gameObject.GetComponent<UI_flash>().StartFlash();
            }

        }
    }
}
