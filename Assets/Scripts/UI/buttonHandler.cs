public partial class LevelHUD
{
    public class UpdateScoreCommand : ITeam
    {
       
        public int NewScore { get; }

        public UpdateScoreCommand(int newScore)
        {
            NewScore = newScore;
        }
    }
}