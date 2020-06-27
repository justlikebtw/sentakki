using System.Collections.Generic;
using osu.Game.Rulesets.Edit;
using osu.Game.Rulesets.Edit.Tools;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Framework.Input;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Input;
using osu.Game.Rulesets.Sentakki.Objects;
using osu.Game.Screens.Edit.Compose.Components;
using System;
using osu.Framework.Graphics;
using System.IO;

namespace osu.Game.Rulesets.Sentakki.Edit
{
    public class SentakkiHitObjectComposer : HitObjectComposer<SentakkiHitObject>
    {
        public SentakkiHitObjectComposer(SentakkiRuleset ruleset)
            : base(ruleset)
        {
        }

        protected override IReadOnlyList<HitObjectCompositionTool> CompositionTools => new HitObjectCompositionTool[]
        {
            new TapCompositionTool(),
            new HoldCompositionTool(),
            new TouchHoldCompositionTool(),
            new TouchCompositionTool(),
            new SlideCompositionTool(),
        };

        protected override ComposeBlueprintContainer CreateBlueprintContainer()
            => new SentakkiBlueprintContainer(this);

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.Key >= Key.S)
            {
                FileInfo file = new FileInfo(@"C:\Users\pertr\Documents\ma2edit\sentakki\output.txt");
                file.Directory.Create();
                file.Delete();
                using (StreamWriter sw = new StreamWriter(@"C:\Users\pertr\Documents\ma2edit\sentakki\output.txt"))
                {
                    foreach (SentakkiHitObject hitObject in EditorBeatmap.HitObjects)
                    {
                        switch (hitObject)
                        {
                            case Tap tap:
                                sw.WriteLine("TAP " + tap.Angle.GetNotePathFromDegrees() + " " + tap.StartTime.ToString());
                                break;
                            case Hold hold:
                                sw.WriteLine("HLD " + hold.Angle.GetNotePathFromDegrees() + " " + hold.StartTime.ToString() + " " + hold.Duration.ToString());
                                break;
                        }
                    }
                }
                return true;
            }
            return base.OnKeyDown(e);
        }
    }
}
