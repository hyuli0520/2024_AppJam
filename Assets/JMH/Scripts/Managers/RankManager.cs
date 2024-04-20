using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    public struct BestPlayer
    {
        public string _bestName;
        public int _bestScore;
        public BestPlayer(string bestName, int bestScore)
        {
            _bestName = bestName;
            _bestScore = bestScore;
        }
    };

    public string _name;
    public int _score = 1;  

    public List<BestPlayer> _ranks = new List<BestPlayer>()
    { 
        new BestPlayer("-", 0),
        new BestPlayer("-", 0),
        new BestPlayer("-", 0),
        new BestPlayer("-", 0),
        new BestPlayer("-", 0),
    };

    public void AddRank()
    {
        _ranks.Add(new BestPlayer(_name, _score));

        SortRank();
    }

    public void SortRank()
    {
        _ranks.Sort((a,b) => { return b._bestScore - a._bestScore; });
    }
}
