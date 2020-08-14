namespace GreyhamWooHoo.Flutter.Finder
{
    public class FlutterByAncestor : FlutterByRelative
    {
        public FlutterByAncestor(FlutterBy of, FlutterBy matching, bool matchRoot) : base("Ancestor", of, matching, matchRoot)
        {
        }
    }
}
