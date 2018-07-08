﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Beatmaps;
using System;

namespace osu.Game.Online.API.Requests
{
    public class DownloadBeatmapSetRequest : APIDownloadRequest
    {
        public readonly BeatmapSetInfo BeatmapSet;

        public Action<float> DownloadProgressed;

        private readonly bool noVideo;

        public DownloadBeatmapSetRequest(BeatmapSetInfo set, bool noVideo)
        {
            this.noVideo = noVideo;
            BeatmapSet = set;

            Progress += (current, total) => DownloadProgressed?.Invoke((float) current / total);
        }

	// TODO: Just overwrite `Uri` instead lol
        protected override string Target => $@"../../beatmapsets/{BeatmapSet.OnlineBeatmapSetID}/download{(noVideo ? "?noVideo=1" : "")}";

	// TODO: Investigate a better place for this or (even better) perform user logins on our own
	protected override string OsuSessionCookie => System.Environment.GetEnvironmentVariable("OSU_SESSION_KEY");
    }
}
