namespace FootballLeague.Models
{
    public enum GameResult
    {
        //Results will be recorded like the betting platforms according to the home team - 
        //1(home team win), 0 instead of x(draw), 2(home team loss or away team win)
        Won = 1,
        Draw = 0, //x
        Lost = 2
    }
}
