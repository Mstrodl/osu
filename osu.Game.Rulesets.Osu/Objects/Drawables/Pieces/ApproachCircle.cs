﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Game.Skinning;
using osuTK;

namespace osu.Game.Rulesets.Osu.Objects.Drawables.Pieces
{
    public class ApproachCircle : Container
    {
        public override bool RemoveWhenNotAlive => false;

        public ApproachCircle()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            RelativeSizeAxes = Axes.Both;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Child = new SkinnableApproachCircle();
        }

        private class SkinnableApproachCircle : SkinnableSprite
        {
            public SkinnableApproachCircle()
                : base("Play/osu/approachcircle")
            {
            }

            protected override Drawable CreateDefault(string name)
            {
                var drawable = base.CreateDefault(name);

                // account for the sprite being used for the default approach circle being taken from stable,
                // when hitcircles have 5px padding on each size. this should be removed if we update the sprite.
                drawable.Scale = new Vector2(128 / 118f);

                return drawable;
            }
        }
    }
}
