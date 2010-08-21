namespace Git
{
    public interface IObject
    {
        byte[] Digest { get; }
        ObjectType Type { get; }
        ulong Size { get; }        

        void Deflate(string outputPath);
        // no inflate method - inflate should be in constructor?
    }
}
