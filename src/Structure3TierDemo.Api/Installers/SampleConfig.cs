namespace Structure3TierDemo.Api.Installers
{
    public class SampleConfig
    {
        public string Prop1 { get; set; }

        public InnerConfig Inner1 { get; set; }


        public class InnerConfig
        {
            public string InnerProp { get; set; }
        }
    }
}