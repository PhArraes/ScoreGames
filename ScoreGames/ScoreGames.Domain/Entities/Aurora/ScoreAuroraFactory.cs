using ScoreGames.Domain.Entities.Dices;
using ScoreGames.Domain.Entities.Scores;
using ScoreGames.Domain.Interfaces.Factories;
using System.Collections.Generic;
using System.Linq;

namespace ScoreGames.Domain.Entities.Aurora
{
    public class ScoreAuroraFactory : ScoreFactory<Dice, int, int>, IScoreAuroraFactory
    {
        protected override void InitScoreClasses()
        {
            _scoreClasses = new List<ScoreClass<Dice, int, int>>() {
                new ScoreClass<Dice, int, int>(){
                    Description = "Aurora",
                    ScoreCalc = (move) => 50,
                    PossibleMoveFunc = move => {
                        var value = move.FirstOrDefault()?.Value;
                        return move.All(d => d.Value == value);
                    },
                    PlayFunc = (move) => move
                },
                new ScoreClass<Dice, int, int>(){
                    Description = "Full House",
                    ScoreCalc = move => move.Sum(s => s.Value),
                    PossibleMoveFunc = move => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Count() == 2 && (groups.First().Count() == 2 || groups.First().Count() == 3);
                    },
                    PlayFunc = (move) => move
                },
                new ScoreClass<Dice, int, int>(){
                    Description = "Sequência Maior",
                    ScoreCalc = move => 20,
                    PossibleMoveFunc = move => {
                        var moveList = move.GroupBy(d => d.Value).Select(g => g.First()).OrderBy(i=> i.Value).ToList();
                        var result = moveList.Count() == 5;
                        for (int i = 0; i < move.Count()-1 && result; i++)
                            result = result && moveList[i+1].Value - moveList[i].Value == 1;
                        return result;
                    },
                    PlayFunc = (move) => move
                },
                new ScoreClass<Dice, int, int>(){
                    Description = "Sequência Menor",
                    ScoreCalc = move => 15,
                    PossibleMoveFunc = move =>{
                        var moveList = move.GroupBy(d => d.Value).Select(g => g.First()).OrderBy(i=> i.Value).ToList();
                        var result = moveList.Count() >= 4;
                        if(!result) return result;
                        result = false;
                        for (int j = 0; j < 2; j++)
                        {
                            if(result) break;
                            result = true;
                            for (int i = j; i < move.Count()-1 && result; i++)
                                result = result && moveList[i+1].Value - moveList[i].Value == 1;
                         }
                        return result;
                    },
                    PlayFunc = (move) => {
                        var moveList = move.GroupBy(d => d.Value).Select(g => g.First()).OrderBy(i=> i.Value).ToList();
                        var result = false;
                        for (int j = 0; j < 2; j++)
                        {
                            result = true;
                            for (int i = j; i < move.Count()-1 && result; i++)
                                result = result && moveList[i+1].Value - moveList[i].Value == 1;
                            if(result) return moveList.Skip(j);
                         }
                        return null;
                    }
                },
                new ScoreClass<Dice, int, int>(){
                    Description = "Quadra",
                    ScoreCalc = move => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.First().Count() >= 4 ? groups.First().First().Value * 4 : groups.Last().First().Value * 4;
                    },
                    PossibleMoveFunc = move => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Count() <= 2 && (groups.First().Count() == 1 || groups.First().Count() >= 4);
                    },
                    PlayFunc = (move) =>{
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.First().Count() > 1 ? groups.First().Select(g => g).Take(4) : groups.Last().Select(g => g).Take(4);
                    }
                },
                new ScoreClass<Dice, int, int>(){
                    Description = "Trio",
                    ScoreCalc = move => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Where(g => g.Count() >= 3).First().First().Value * 3;
                    },
                    PossibleMoveFunc = move => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Any(g=>g.Count() >= 3);
                    },
                    PlayFunc = (move) => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Where(g => g.Count() >= 3).First().Select(d=>d).Take(3);
                    }
                },
                new ScoreClass<Dice, int, int>(){
                    Description = "Dois Pares",
                    ScoreCalc = move =>  {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Where(g => g.Count() >= 2).Sum(s => s.First().Value * 2);
                    },
                    PossibleMoveFunc = move => {
                        var groups = move.GroupBy(s=>s.Value);
                        return groups.Count() == 3 ;
                    },
                    PlayFunc = (move) => {
                        var groups = move.GroupBy(s=>s.Value).Where(g => g.Count() == 2);
                        var result= new List<Dice>();
                        groups.Select(g => g.ToList()).ToList().ForEach(l=> result.AddRange(l));
                        return result;
                    }
                },
            };
            var desc = new string[] { "Ums", "Dois", "Três", "Quatros", "Cincos", "Seis" };
            for (int i = 1; i < 7; i++)
            {
                var index = i;
                _scoreClasses.Add(new ScoreClass<Dice, int, int>()
                {
                    Description = desc[index - 1],
                    ScoreCalc = move => move.Sum(d => d.Value == index ? index : 0),
                    PossibleMoveFunc = move => move.Any(d => d.Value == index),
                    PlayFunc = (move) => move.Where(d => d.Value == index)
                });
                _scoreClasses.Add(new ScoreClass<Dice, int, int>()
                {
                    Description = "Par " + desc[index - 1],
                    ScoreCalc = move => index * 2,
                    PossibleMoveFunc = move => move.Count(d => d.Value == index) >= 2,
                    PlayFunc = (move) => move.Where(d => d.Value == index).Take(2)
                });
            }
        }
    }
}
