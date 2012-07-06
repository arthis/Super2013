namespace Super.Contabilita.Commands.Builders
{
    public static class Build
    {
        public static CreateImpiantoBuilder CreateImpianto { get { return new CreateImpiantoBuilder(); } }

        public static UpdateImpiantoBuilder UpdateImpianto { get { return new UpdateImpiantoBuilder(); } }

        public static DeleteImpiantoBuilder DeleteImpianto { get { return new DeleteImpiantoBuilder(); } }

        public static CreateLottoBuilder CreateLotto { get { return new CreateLottoBuilder(); } }

        public static UpdateLottoBuilder UpdateLotto { get { return new UpdateLottoBuilder(); } }

        public static DeleteLottoBuilder DeleteLotto { get { return new DeleteLottoBuilder(); } }

        
    }
}