using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//statement for using unity ui
using UnityEngine.UI;
public class Highscores : MonoBehaviour {

    //displays the score
    public List<Text> highScoreDisplays = new List<Text>();

    private List<int> highScoreData = new List<int>();

	// Use this for initialization
	void Start () {

        //takes the high score from player prefs
        LoadHighScoreData();

        //looks to see if we got a new high score
        int currentScore = PlayerPrefs.GetInt("score", 0); 
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore == true)
        {
            //if it is a new high score add it to the list
            AddScoreToList(currentScore);
            //saves the score
            SaveHighScoreData();

        }

        //add new score to the data and save it 

        //update it visually
        UpdateVisualDisplay();
		
	}
    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index, get the name for our playerprefs key
            string prefsKey = "highScore" + i.ToString();

            // use this key ot get the high score value from playerprefs
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            // store this score value in our internal data list
            highScoreData.Add(highScoreValue);
        }

    }
    private void UpdateVisualDisplay()
    {

        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //find the specific text and numbers in the list
            //set the text to the numerical score
            highScoreDisplays[i].text = highScoreData[i].ToString();

        }

    }
    private bool IsNewHighScore(int scoreToCheck)
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // is our score higher than the high score we are checking this loop
            if (scoreToCheck > highScoreData[i])
            {
                //ojur score is higher
                //return ToString the calling code that we do have a new high score 
                return true;

            }
        }

        // default: false
        return false;

    }
    private void AddScoreToList(int newScore)
    {
        // ;pp[ tjrpigj tje jogj scpres amd find out where the new one goes
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {

            if (newScore > highScoreData[i])
            {

                // our score is higher
                // since were going from highest to lowest 
                // time our score is higher 

                //insert new score into the list 
                highScoreData.Insert(i, newScore);

                //trim the last item
                highScoreData.RemoveAt(highScoreData.Count - 1);

                //we need to exit early 
                return;
            }

        }


    }
    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index, get the name for our playerprefs key
            string prefsKey = "highScore" + i.ToString();

            // get the current high score entry from the data 
            int highScoreEntry = highScoreData[i];

            //save this data to the PlayerPrefs 
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
        }
        // save the player prefs to disk 
        PlayerPrefs.Save();
    }

    [ContextMenu("RESET ALL SCORES")]
    public void ResetScores()
    {

        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index, get the name for our playerprefs key
            string prefsKey = "highScore" + i.ToString();

            // use this key to delete
            PlayerPrefs.DeleteKey(prefsKey);
        }
    }
}


