using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Objects.Drawables;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Graphics.Effects;

namespace osu.Game.Rulesets.Sentakki.Objects.Drawables.Pieces
{
    public class TouchHoldCentrePiece : CompositeDrawable
    {
        private OsuColour colours = new OsuColour();
        public TouchHoldCentrePiece()
        {
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Size = new Vector2(60);
            Masking = true;
            BorderThickness = 2;
            BorderColour = Color4.Black;
            CornerRadius = 2.5f;
            CornerRadius = 15;
            Rotation = 45;
            InternalChildren = new Drawable[]{
                new Container {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(2),
                    Rotation = -45f,
                    Children = new Drawable[]{
                        new CircularProgress{
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            InnerRadius = 1,
                            Size = Vector2.One,
                            RelativeSizeAxes = Axes.Both,
                            Current = { Value = 1 },
                            Colour = colours.Blue
                        },
                        new CircularProgress{
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            InnerRadius = 1,
                            Size = Vector2.One,
                            RelativeSizeAxes = Axes.Both,
                            Current = { Value = .75 },
                            Colour = colours.Green
                        },
                        new CircularProgress{
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            InnerRadius = 1,
                            Size = Vector2.One,
                            RelativeSizeAxes = Axes.Both,
                            Current = { Value = .5 },
                            Colour = colours.Yellow,
                        },
                        new CircularProgress{
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            InnerRadius = 1,
                            Size = Vector2.One,
                            RelativeSizeAxes = Axes.Both,
                            Current = { Value = .25 },
                            Colour = colours.Red,
                        },
                    }
                }
            };
        }

    }
}
