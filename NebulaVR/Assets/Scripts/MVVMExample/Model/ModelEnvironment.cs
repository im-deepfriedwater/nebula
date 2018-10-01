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


using System;

public class ModelEnvironment
{
    readonly Random numberGenerator = new Random();
    string[] coolHipPhrases =
    {
        "This is a button",
        "Click here to be cool",
        "Uh, I think you broke it",
        "oh NO",
        "Please help me",
        "This might be it for me",
        "Ok fixed it sick, thanks"
    };

    float buttonRotation = 0;
    float buttonPositionOffset = 0;
    float buttonScale = 1.0f;

    int currentIndex = 0;

    public string CurrentValue
    {
        get
        {   if (currentIndex >= 1)
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

            if (currentIndex == coolHipPhrases.Length - 1)
            {
                ResetButton();
            }
            currentIndex += 1;
            return coolHipPhrases[currentIndex];
        }
    }

    void MoveButton()
    {
        buttonPositionOffset = numberGenerator.Next(-5, 5) * 10;
    }

    void RotateButton()
    {
        buttonPositionOffset = numberGenerator.Next(0, 360);
    }
	
    void GrowButton()
    {
        buttonScale = (float) numberGenerator.NextDouble() * 3;
    }

    void ResetButton()
    {
        buttonPositionOffset = 0;
        buttonScale = 1.0f;
        buttonRotation = 0;
    }
}
