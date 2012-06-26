namespace Super.Appaltatore.Commands.Builders
{
    public static class Build
    {
        public static ConsuntivareAmbResoBuilder ConsuntivareAmbReso { get { return new ConsuntivareAmbResoBuilder(); } }

        public static ConsuntivareNonResoAmbBuilder ConsuntivareNonResoAmb { get { return new ConsuntivareNonResoAmbBuilder(); } }

        public static ConsuntivareNonResoRotBuilder ConsuntivareNonResoRot { get { return new ConsuntivareNonResoRotBuilder(); } }

        public static ConsuntivareNonResoRotManBuilder ConsuntivareNonResoRotMan { get { return new ConsuntivareNonResoRotManBuilder(); } }

        public static ConsuntivareNonResoTrenitaliaAmbBuilder ConsuntivareNonResoTrenitaliaAmb { get { return new ConsuntivareNonResoTrenitaliaAmbBuilder(); } }

        public static ConsuntivareNonResoTrenitaliaRotBuilder ConsuntivareNonResoTrenitaliaRot { get { return new ConsuntivareNonResoTrenitaliaRotBuilder(); } }

        public static ConsuntivareNonResoTrenitaliaRotManBuilder ConsuntivareNonResoTrenitaliaRotMan { get { return new ConsuntivareNonResoTrenitaliaRotManBuilder(); } }

        public static ConsuntivareRotManResoBuilder ConsuntivareRotManReso { get { return new ConsuntivareRotManResoBuilder(); } }

        public static ConsuntivareRotResoBuilder ConsuntivareRotReso { get { return new ConsuntivareRotResoBuilder(); } }

        public static ProgrammareInterventoAmbBuilder ProgrammareInterventoAmb { get { return new ProgrammareInterventoAmbBuilder(); } }

        public static ProgrammareInterventoRotBuilder ProgrammareInterventoRot { get { return new ProgrammareInterventoRotBuilder(); } }

        public static ProgrammareInterventoRotManBuilder ProgrammareInterventoRotMan { get { return new ProgrammareInterventoRotManBuilder(); } }
        
    }
}