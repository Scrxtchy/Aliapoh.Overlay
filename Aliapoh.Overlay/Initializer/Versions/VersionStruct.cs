namespace Aliapoh.Overlays
{
    public class VersionStruct
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public int Build { get; private set; }
        public int Revision { get; private set; }

        public override string ToString()
        {
            return Major + "." + Minor + "." + Build + "." + Revision;
        }

        public VersionStruct()
        {

        }

        public VersionStruct(string ver)
        {
            try
            {
                var version = ver.Split('.');
                if (version.Length == 4)
                {
                    Major = int.Parse(version[0]);
                    Minor = int.Parse(version[1]);
                    Build = int.Parse(version[2]);
                    Revision = int.Parse(version[3]);
                }
            }
            catch
            { }
        }

        public int Diff(VersionStruct vs)
        {
            if (vs.Major > Major) return -1;
            if (vs.Minor > Minor) return -1;
            if (vs.Build > Build) return -1;
            if (vs.Revision > Revision) return -1;

            return 0;
        }
    }
}