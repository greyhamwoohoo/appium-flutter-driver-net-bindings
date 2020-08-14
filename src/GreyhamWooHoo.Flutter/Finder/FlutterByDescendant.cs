namespace GreyhamWooHoo.Flutter.Finder
{
    public class FlutterByDescendant : FlutterByRelative
    {
        public FlutterByDescendant(FlutterBy of, FlutterBy matching, bool matchRoot) : base("Descendant", of, matching, matchRoot)
        {
        }
    }
}
