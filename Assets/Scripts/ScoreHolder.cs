using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "AllScores", menuName = "AllScores")]

public class ScoreHolder : ScriptableObject
{
   public List<Highscore> scores;

   public void AddScore(Highscore highscore)
   {
      if (highscore == null) return;
      scores.Add(highscore);
   }

   public Highscore GetTopScore()
   {
       OrderScores();
      return scores[0];
      
   }

   public List<Highscore> GetTopScores(int amount)
   {
      var topScores = new List<Highscore>();
      for (var i = 0; i < amount && i<scores.Count; i++)
      {
         topScores.Add(scores[i]);
      }

      return topScores;
   }

   public void OrderScores()
   {
      scores.RemoveAll(item => item == null);
       scores.OrderBy(o=>o.GetTotalScore()).ToList();
   }

   public int GetRank(Highscore highscore)
   {
      if (highscore == null) return -1;
      OrderScores();
     return scores.FindIndex(x=>highscore)+1;
   }
}
