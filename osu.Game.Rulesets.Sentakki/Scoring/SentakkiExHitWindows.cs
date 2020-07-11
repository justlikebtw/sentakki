using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.Sentakki.Scoring
{
    public class SentakkiExHitWindows : SentakkiHitWindows
    {
        public override bool IsHitResultAllowed(HitResult result)
        {
            switch (result)
            {
                case HitResult.Perfect:
                case HitResult.Miss:
                    return true;
                default:
                    return false;
            }
        }

        protected override DifficultyRange[] GetRanges() => new DifficultyRange[]{
            new DifficultyRange(HitResult.Miss, 144, 144, 144),
            new DifficultyRange(HitResult.Perfect, 144, 144, 144),
        };
    }
}
