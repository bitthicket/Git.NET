namespace Git
{
    public enum ObjectType
    {
        None, Commit, Tree, Blob, Tag, _reserved_obj_type_, OffsetDelta, ReferenceDelta
    }
}