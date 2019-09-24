using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;


public class JasonTest : MonoBehaviour
{
    public Sprite[] AllImg;
    public List<Sprite> imgs = new List<Sprite>();
    int currIdx;
    Text txtAllot;
    public List<string> thisTt = new List<string>();

    private TextAsset msgText;

    int ni = 0;

    public Image showImg;
    public Text showTt;

    // Start is called before the first frame update
    void Start()
    {
        msgText = Resources.Load<TextAsset>("UI_Images/ImageText");
        //AllImg = Resources.LoadAll<Texture>("UI_Images");

        JsonData jsonText = JsonMapper.ToObject(msgText.text);

        for (int i = 0; i < 14; i++)
        {
            Debug.Log(jsonText["Images"][i]["picture"].ToString());
            Debug.Log(jsonText["Images"][i]["description"].ToString());

            imgs.Add(Resources.Load<Sprite>("UI_Images/" + jsonText["Images"][i]["picture"].ToString()));
            thisTt.Add(jsonText["Images"][i]["description"].ToString());
        }

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ni++;
            if (ni > 14)
            {
                ni = 0;
            }
        }

        showImg.sprite = imgs[ni];
        showTt.text = thisTt[ni];
    }

}
