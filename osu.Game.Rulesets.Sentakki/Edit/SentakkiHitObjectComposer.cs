using osu.Framework.Bindables;
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
            isRunning.BindValueChanged(_ => writeTime());
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

        private Bindable<bool> isRunning = new Bindable<bool>(false);

        protected override void Update()
        {
            isRunning.Value = EditorClock.IsRunning;
        }

        private void writeTime()
        {
            FileInfo file = new FileInfo(@"C:\Users\pertr\Documents\ma2edit\sentakki\time.txt");
            file.Directory.Create();
            file.Delete();
            using (StreamWriter sw = new StreamWriter(@"C:\Users\pertr\Documents\ma2edit\sentakki\time.txt"))
            {
                if (!EditorClock.IsRunning) sw.WriteLine("null");
                else sw.WriteLine(EditorClock.CurrentTime);
            }
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if (e.Key == Key.S)
            {
                FileInfo file = new FileInfo(@"C:\Users\pertr\Documents\ma2edit\sentakki\output.txt");
                file.Delete();
                using (StreamWriter sw = new StreamWriter(@"C:\Users\pertr\Documents\ma2edit\sentakki\output.txt"))
                {
                    foreach (SentakkiHitObject hitObject in EditorBeatmap.HitObjects)
                    {
                        switch (hitObject)
                        {
                            case Tap tap:
                                sw.WriteLine("TAP\t" + tap.Angle.GetNotePathFromDegrees() + "\t" + tap.StartTime.ToString());
                                break;
                            case Hold hold:
                                sw.WriteLine("HLD\t" + hold.Angle.GetNotePathFromDegrees() + "\t" + hold.StartTime.ToString() + "\t" + hold.Duration.ToString());
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
