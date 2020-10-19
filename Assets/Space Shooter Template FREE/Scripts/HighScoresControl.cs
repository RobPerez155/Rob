using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HighScoresControl : Singleton<HighScoresControl>
{
    //Set the high score list to include 10 scores
   public long[] highscores = new long[10];


   public bool IsHighScore(long value)
   {
       return (value > highscores[0]);
   }

   //Here is the code to decide whether to add a score to the high score list. It assumes the high score array is sorted so that [0] will be the highest score.
   public bool AddHighScore(long value)
   {
       if (!IsHighScore(value))
           return false;

       for (int i = 9; i > 0; i--)
       {
           highscores[i] = highscores[i - 1];
       }

       highscores[0] = value;
       return true;
   }
}
