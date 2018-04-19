using System;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Extensions
{
    public static class ArraySegmentExtensions
    {
        public static ArraySegment<T> SliceEx<T>(this ArraySegment<T> segment, int start, int count)
        {
            if (segment == default(ArraySegment<T>)) throw new ArgumentNullException(nameof(segment));
            if (start < 0 || start >= segment.Count) throw new ArgumentOutOfRangeException(nameof(start));
            if (count < 1 || start + count > segment.Count) throw new ArgumentOutOfRangeException(nameof(count));

            return new ArraySegment<T>(segment.Array, start, count);
        }
    }
}
