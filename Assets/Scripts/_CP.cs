using UnityEngine;
using System.Collections;

public class _CP : MonoBehaviour
{
    public int bounces;
    public Material matBlue;

    private GUIText guiRewards;

	// Use this for initialization
	void Start ()
    {
        //Time.fixedDeltaTime = 0.02f;

        //guiRewards = GameObject.Find("GUI_Rewards").guiText;

        bounces = 0;
	}
	
    //// Update is called once per frame
    //void Update ()
    //{
        
    //}

    public void CheckBouncingReward()
    {
        //// 50: bigger duck
        //if (bounces == 50)
        //{
        //    GameObject.Find("Duck").transform.localScale *= 2;
        //    GameObject.Find("Duck").audio.pitch = 0.75f;
        //    guiRewards.text += "50 - Enlarge your Duck!\n";
        //}

        //// 100: blue duck
        //if (bounces == 100)
        //{
        //    GameObject.Find("Duck").transform.FindChild("Model").FindChild("body").renderer.material = matBlue;
        //    GameObject.Find("Duck").transform.FindChild("Model").FindChild("head").renderer.material = matBlue;
        //    guiRewards.text += "100 - Blue Duck?\n";
        //}

        //// 200: break the rules
        //if (bounces == 200)
        //{
        //    SpawnDuck();
        //    guiRewards.text += "200 - BREAK THE RULES!!!\n";
        //}

        //// 300: army
        //if (bounces == 300)
        //{
        //    Invoke("SpawnDuck", 0.0f);
        //    Invoke("SpawnDuck", 0.5f);
        //    Invoke("SpawnDuck", 1.0f);
        //    Invoke("SpawnDuck", 1.5f);
        //    guiRewards.text += "300 - I have an Army!\n";
        //}

        //// 500: crazy ducks
        //if (bounces == 500)
        //{
        //    Invoke("SpawnDuckCrazy", 0.0f);
        //    guiRewards.text += "500 - Insanity\n";
        //}

        //// 1000: break the game
        //if (bounces == 1000)
        //{
        //    InvokeRepeating("SpawnDuck", 0.0f, 0.5f);
        //    InvokeRepeating("SpawnDuckCrazy", 4.5f, 5.0f);
        //    guiRewards.text += "1000 - BREAK THE GAME!!!\n";
        //}

        //// 3000: break the game
        //if (bounces == 3000)
        //{
        //    Invoke("SpawnKing", 0.0f);
        //    guiRewards.text += "3000 - Hail to the KING!\n";
        //}

        //// 10000: break the game
        //if (bounces == 10000)
        //{
        //    guiRewards.text += "10000 - Are you still playing the game???\n";
        //}
    }

    private void SpawnDuck()
    {
        Instantiate(Resources.Load("Prefabs/Duck"), new Vector3(-7.5f, 19.5f, 7.5f), Quaternion.identity);
    }

    private void SpawnDuckCrazy()
    {
        Instantiate(Resources.Load("Prefabs/DuckCrazy"), new Vector3(-7.5f, 19.5f, 7.5f), Quaternion.identity);
    }

    private void SpawnKing()
    {
        GameObject king = Instantiate(Resources.Load("Prefabs/Duck"), new Vector3(-7.5f, 14.5f, 7.5f), Quaternion.identity) as GameObject;
        king.transform.localScale *= 12;
        king.audio.pitch = 0.5f;
    }
}
