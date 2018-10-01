using System;
using UnityEngine;

// This class is a "Model" of the 
// environment. It keeps track
// of what the right string value
// is and also various aspects
// of the button.

// Note, it doesn't *care* about
// how to actually rotate/grow/move
// the button, just that the button
// should should have these attributes
// and the ViewModel handles
// telling the view how to
// achieve this. 

 
public class ModelEnvironment : MonoBehaviour
{
    readonly System.Random numberGenerator = new System.Random();
    string[] coolHipPhrases =
    {
        "This is a button",
        "Click here to be cool",
        "Uh, I think you broke it",
        "oh NO",
        "Please help me",
        "This might be it for me",
        "Still broken",
        "Probably more broken",
        "Ok fixed it sick, thanks"
    };

    private float buttonRotation = 0;
    public float ButtonRotation
    {
        get { return buttonRotation; }
    }

    private float buttonPositionOffset = 0;
    public float ButtonPositionOffset
    {
        get { return buttonPositionOffset; }
    }

    private float buttonScale = 1.0f;
    public float ButtonScale
    {
        get { return buttonScale; }
    }

    private bool reset = false;
    public bool Reset
    {
        get
        {
            return reset;
        }

        set
        {
            reset = value;
        }
    }

    private int currentIndex = 0;

    public string CurrentValue
    {
        get
        {
            string currentHipPhrase = coolHipPhrases[currentIndex];
            currentIndex += 1;

            if (currentIndex > 1)
            {
                MoveButton();
            }

            if (currentIndex == 3)
            {
                RotateButton();
            }

            if (currentIndex == 4)
            {
                GrowButton();
            }

            if (currentIndex > coolHipPhrases.Length - 1)
            {
                ResetButton();
                currentIndex = 0;
            }

            return currentHipPhrase;
        }
    }

   private void MoveButton()
    {
        buttonPositionOffset = numberGenerator.Next(-5, 5) * 10;
    }

   private void RotateButton()
    {
        buttonRotation = numberGenerator.Next(0, 360);
    }
	
    private void GrowButton()
    {
        buttonScale = (float) numberGenerator.NextDouble() + 1;
    }

   private void ResetButton()
    {
        buttonPositionOffset = 0;
        buttonScale = 1.0f;
        buttonRotation = 0;

        reset = true;
    }
}
