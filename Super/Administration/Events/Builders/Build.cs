namespace Super.Administration.Events.Builders
{
    public static class Build
    {
        public static AreaInterventoCreatedBuilder AreaInterventoCreated { get { return new AreaInterventoCreatedBuilder(); } }

        public static AreaInterventoUpdatedBuilder AreaInterventoUpdated { get { return new AreaInterventoUpdatedBuilder(); } }

        public static AreaInterventoDeletedBuilder AreaInterventoDeleted { get { return new AreaInterventoDeletedBuilder(); } }

       
    }
}