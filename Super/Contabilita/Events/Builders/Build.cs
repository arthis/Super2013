namespace Super.Contabilita.Events.Builders
{
    public static class Build
    {
        public static ImpiantoCreatedBuilder ImpiantoCreated { get { return new ImpiantoCreatedBuilder(); } }

        public static ImpiantoUpdatedBuilder ImpiantoUpdated { get { return new ImpiantoUpdatedBuilder(); } }

        public static ImpiantoDeletedBuilder ImpiantoDeleted { get { return new ImpiantoDeletedBuilder(); } }

        public static LottoCreatedBuilder LottoCreated { get { return new LottoCreatedBuilder(); } }

        public static LottoUpdatedBuilder LottoUpdated { get { return new LottoUpdatedBuilder(); } }

        public static LottoDeletedBuilder LottoDeleted { get { return new LottoDeletedBuilder(); } }

       
    }
}