using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Game.Rulesets.Objects.Drawables;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Sentakki.Objects.Drawables.Pieces
{
    public class ShadowPiece : Container
    {
        public ShadowPiece()
        {
            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Padding = new MarginPadding(1);
        }

        private readonly IBindable<Color4> accentColour = new Bindable<Color4>();

        [BackgroundDependencyLoader(true)]
        private void load(DrawableHitObject drawableObject)
        {
            DrawableSentakkiHitObject drawableSenHitObj = (DrawableSentakkiHitObject)drawableObject;
            accentColour.BindTo(drawableObject.AccentColour);
            accentColour.BindValueChanged(colour =>
                Child = new CircularContainer
                {
                    Alpha = .5f,
                    Masking = true,
                    RelativeSizeAxes = Axes.Both,
                    EdgeEffect = new EdgeEffectParameters
                    {
                        Hollow = true,
                        Type = EdgeEffectType.Shadow,
                        Radius = 15,
                        Colour = (drawableSenHitObj.HitObject.IsExNote && !drawableSenHitObj.HitObject.IsBreak) ? colour.NewValue : Color4.Black,
                    }
                }
            , true);
        }
    }
}
