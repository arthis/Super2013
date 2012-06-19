namespace Super.Administration.Commands.Builders
{
    public static class Build
    {
        public static CreateAreaInterventoBuilder CreateAreaIntervento { get { return new CreateAreaInterventoBuilder(); } }

        public static UpdateAreaInterventoBuilder UpdateAreaIntervento { get { return new UpdateAreaInterventoBuilder(); } }
    }
}