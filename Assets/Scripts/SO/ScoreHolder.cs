﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StuartH
{
   /// <summary>
   ///ScoreHolder - holds the scores for the game
   /// </summary>
   [CreateAssetMenu(fileName = "AllScores", menuName = "AllScores")]

   public class ScoreHolder : ScriptableObject
   {
      public ScoreSaveData currentScore;
      public List<ScoreSaveData> scores;

      public void AddScore()
      {
         var ns = new ScoreSaveData(currentScore);
         scores.Add(ns);
         currentScore.Clear();
      }

      public ScoreSaveData GetTopScore()
      {
         OrderScores();
         return scores[0];

      }

      public List<ScoreSaveData> GetTopScores(int amount)
      {
         var topScores = new List<ScoreSaveData>();
         for (var i = 0; i < amount && i < scores.Count; i++)
         {
            topScores.Add(scores[i]);
         }

         return topScores;
      }

      public void OrderScores()
      {
         scores.RemoveAll(p => p == null);
         scores = scores.OrderBy(o => o.GetTotalScore()).ToList();
      }

      public int GetRank(ScoreSaveData highscore)
      {
         if (highscore == null) return -1;
         OrderScores();
         return scores.FindIndex(x => highscore) + 1;
      }

      public void LoadScores(ScoreSaveDataList savedScores)
      {
         scores.Clear();
         scores = savedScores.scores;
      }
      
      [Serializable]
      public class ScoreSaveData
      {
         public int gold;
         public float time;

         public ScoreSaveData(int gold, float time)
         {
            this.gold = gold;
            this.time = time;
         }
         public ScoreSaveData(ScoreSaveData s)
         {
            gold = s.gold;
            time = s.time;
         }
         public int GetTotalScore() => (int) time * (gold / 4);

         public void Clear()
         {
            gold = 0;
            time = 0f;
         }
      }
	
      [Serializable]
      public class ScoreSaveDataList
      {
         public List<ScoreSaveData> scores = new List<ScoreSaveData>();
	
      }
   }
}
